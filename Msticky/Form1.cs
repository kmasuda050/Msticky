using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimplePsd;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Msticky
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

        private Bitmap bitmapBase = null;
        private Bitmap bitmap = null;
        private SimplePsd.CPSD psd;
        private Point mousePoint;
        private Size BeforeSize;
        private Point BeforeLocation;
        private float zoom;
        private float rotate;
        private Boolean doubleClick;
        private Boolean icon;

        [DllImport("user32.dll")]
        private static extern bool InsertMenuItem(IntPtr hMenu, UInt32 uItem, bool fByPosition, ref MENUITEMINFO mii);
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, UInt32 bRevert);

        [StructLayout(LayoutKind.Sequential)]
        private struct MENUITEMINFO
        {
            internal UInt32 cbSize;
            internal UInt32 fMask;
            internal UInt32 fType;
            internal UInt32 fState;
            internal UInt32 wID;
            internal IntPtr hSubMenu;
            internal IntPtr hbmpChecked;
            internal IntPtr hbmpUnchecked;
            internal UInt32 dwItemData;
            internal string dwTypeData;
            internal UInt32 cch;
            internal IntPtr hbmpItem;
        };

        const int MIIM_ID = 0x00000002;
        const int MIIM_STRING = 0x00000040;

        public Form1()
        {
            InitializeComponent();

            // add menu
            IntPtr hMenu = GetSystemMenu(this.Handle, 0);

            MENUITEMINFO mii = new MENUITEMINFO
            {
                cbSize = (uint)Marshal.SizeOf(typeof(MENUITEMINFO)),
                fMask = MIIM_ID | MIIM_STRING,

                fState = 0,
                wID = (uint)500,
                hSubMenu = IntPtr.Zero,
                hbmpChecked = IntPtr.Zero,
                hbmpUnchecked = IntPtr.Zero,
                dwItemData = 0,
                dwTypeData = "Change Freeze",
                cch = 0,
                hbmpItem = IntPtr.Zero
            };

            unchecked { InsertMenuItem(hMenu, 0, false, ref mii); }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            bitmapBase = null;
            bitmap = null;
            psd = new SimplePsd.CPSD();
            this.TopMost = true;
            icon = false;

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                SetImage(args[1]);
            }
        }

        private Bitmap GetImagePsd(String file)
        {
            int nResult = psd.Load(file);
            if (nResult == 0)
                return Image.FromHbitmap(psd.GetHBitmap());

            if (nResult == -1)
                MessageBox.Show("Cannot open the File");
            else if (nResult == -2)
                MessageBox.Show("Invalid (or unknown) File Header");
            else if (nResult == -3)
                MessageBox.Show("Invalid (or unknown) ColourMode Data block");
            else if (nResult == -4)
                MessageBox.Show("Invalid (or unknown) Image Resource block");
            else if (nResult == -5)
                MessageBox.Show("Invalid (or unknown) Layer and Mask Information section");
            else if (nResult == -6)
                MessageBox.Show("Invalid (or unknown) Image Data block");
            return null;
        }

        private void UpdateBitmap(Bitmap bitmap, Bitmap original)
        {
            if (bitmap == null || original == null)
                return;

            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.Empty);
            g.ResetTransform();
            g.TranslateTransform(bitmapBase.Width / 2, bitmapBase.Height / 2);
            g.RotateTransform(rotate);
            g.TranslateTransform(-bitmapBase.Width / 2, -bitmapBase.Height / 2);
            g.DrawImage(bitmapBase, 0, 0);
            g.Dispose();
        }

        private void SetImage(String file)
        {
            pictureBox1.Location = new Point(0, 0);

            if (bitmapBase != null)
            {
                bitmapBase.Dispose();
                bitmapBase = null;
            }
            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }

            bitmapBase = (file.EndsWith("psd")) ? GetImagePsd(file) : new Bitmap(file);

            if (bitmapBase != null)
            {
                zoom = 1.0f;
                rotate = 0.0f;
                bitmap = new Bitmap(bitmapBase.Width, bitmapBase.Height);
                UpdateBitmap(bitmap, bitmapBase);
                pictureBox1.Image = bitmap;
                this.ClientSize = bitmap.Size;

                SetPictureBox1Size();
            }
        }

        private void SetPictureBox1Size()
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Width = (int)(pictureBox1.Image.Width * zoom);
                pictureBox1.Height = (int)(pictureBox1.Image.Height * zoom);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image(*.bmp;*.png;*.gif;*.jpg;*.jpeg;*.psd)|*.bmp;*.png;*.gif;*.jpg;*.jpeg;*.psd";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SetImage(ofd.FileName);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        this.Opacity = 1.0;
                        this.freezeToolStripMenuItem.Visible = false;
                        break;
                    case Keys.S:
                        this.Opacity = 0.0;
                        break;
                }
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.A:
                    this.Opacity += 0.2;
                    if (this.Opacity >= 1.0)
                    {
                        this.freezeToolStripMenuItem.Visible = false;
                    }
                    break;
                case Keys.S:
                    this.Opacity -= 0.2;
                    this.freezeToolStripMenuItem.Visible = true;
                    break;
                case Keys.Right:
                    this.Left += 1;
                    break;
                case Keys.Left:
                    this.Left -= 1;
                    break;
                case Keys.Up:
                    this.Top -= 1;
                    break;
                case Keys.Down:
                    this.Top += 1;
                    break;
                case Keys.Z:
                    pictureBox1.Left = 0;
                    pictureBox1.Top = 0;
                    this.ClientSize = pictureBox1.Size;
                    break;
            }
        }

        private void topToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        // http://www.atmarkit.co.jp/fdotnet/dotnettips/676dragdrop/dragdrop.html
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            SetImage(files[0]);
        }

        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown(e);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(e);
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                if (e.Delta < 0)
                {
                    rotate -= 2.0f;
                }
                else
                {
                    rotate += 2.0f;
                }

                UpdateBitmap(bitmap, bitmapBase);

                pictureBox1.Invalidate();
            }
            else
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                if (e.Delta < 0)
                {
                    zoom += 0.1f;
                    if (zoom > 3.0f)
                        zoom = 3.0f;
                }
                else
                {
                    zoom -= 0.1f;
                    if (zoom < 0.2f)
                        zoom = 0.2f;
                }

                SetPictureBox1Size();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown(e);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(e);
        }

        private void mouseDown(MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
                return;

            mousePoint = new Point(e.X, e.Y);
            doubleClick = false;

            if (e.Clicks == 2)
            {
                doubleClick = true;

                if (!icon)
                {
                    BeforeSize = this.ClientSize;
                    BeforeLocation = pictureBox1.Location;

                    this.ClientSize = new Size(32,32);
                    pictureBox1.Location = new Point(0, 0);
                    pictureBox1.Size = this.ClientSize;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    Point p = PointToClient(Location);
                    Rectangle r = ClientRectangle;
                    r.Offset(-p.X, -p.Y);
                    Region = new Region(r);

                    icon = true;
                }
                else
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                    this.ClientSize = BeforeSize;
                    pictureBox1.Location = BeforeLocation;

                    Region = null;

                    SetPictureBox1Size();

                    icon = false;
                }
            }
        }

        private void mouseMove(MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
                return;

            if (doubleClick)
                return;

            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                pictureBox1.Left += e.X - mousePoint.X;
                pictureBox1.Top += e.Y - mousePoint.Y;
            }
            else
            {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;
            }
        }

        private Boolean UpdateFreeze()
        {
            const int GWL_EXSTYLE = -20;
            const int WS_EX_TRANSPARENT = 0x00000020;
            const int WS_EX_LAYERED = 0x00080000;

            int style = (int)GetWindowLong(this.Handle, GWL_EXSTYLE);

            if ((style & WS_EX_LAYERED) != WS_EX_LAYERED)
                return false;

            if ((style & WS_EX_TRANSPARENT) == WS_EX_TRANSPARENT)
            {
                style &= ~WS_EX_TRANSPARENT;
            }
            else
            {
                style |= WS_EX_TRANSPARENT;
            }
            SetWindowLong(this.Handle, GWL_EXSTYLE, (IntPtr)style);

            return true;
        }

        private void freezeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            if (!UpdateFreeze())
            {
                item.Checked = false;
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x112;

            long param = 0;

            if (IntPtr.Size == 4)
            {
                param = m.WParam.ToInt32();
            }
            else if (IntPtr.Size == 8)
            {
                param = m.WParam.ToInt64();
            }

            if (m.Msg == WM_SYSCOMMAND && param == 500)
            {
                if (UpdateFreeze())
                {
                    freezeToolStripMenuItem.Checked = !freezeToolStripMenuItem.Checked;
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}
