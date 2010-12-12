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
using System.Diagnostics;
using System.IO;

using QTOControlLib;

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
        private Point BeforePictureBoxLocation;
        private int zoom;
        private float rotate;
        private Boolean doubleClick;
        private Boolean icon;
        private Boolean hide;
        private String title;
        private String openFile;
        private Size movieMargin;

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

        private void UpdateTitle()
        {
            this.Text = title + " @ " + zoom * 10 + "%";
        }

        private void AddHistory(String file)
        {
            bool duplicate = false;

            if (Properties.Settings.Default.Setting == null)
                Properties.Settings.Default.Setting = new System.Collections.Specialized.StringCollection();
            for (int i = 0; i < Properties.Settings.Default.Setting.Count; i++)
            {
                if (Properties.Settings.Default.Setting[i] == file)
                {
                    duplicate = true;
                    break;
                }
            }
            if (!duplicate)
            {
                Properties.Settings.Default.Setting.Insert(0, file);
                if (Properties.Settings.Default.Setting.Count > 10)
                {
                    Properties.Settings.Default.Setting.RemoveAt(10);
                }
                Properties.Settings.Default.Save();

                UpdateHistoryToolStripMenuItem();
            }
        }

        private void UpdateHistoryToolStripMenuItem()
        {
            if (Properties.Settings.Default.Setting == null)
                return;

            ToolStripMenuItem[] histories = { historyToolStripMenuItem, mhistoryToolStripMenuItem };

            foreach (ToolStripMenuItem history in histories)
            {
                history.DropDownItems.Clear();

                for (int i = 0; i < Properties.Settings.Default.Setting.Count; i++)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = Properties.Settings.Default.Setting[i];
                    history.DropDownItems.Add(item);
                    item.Click += delegate
                    {
                        SetImage(item.Text);
                    };
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmapBase = null;
            bitmap = null;
            psd = new SimplePsd.CPSD();
            this.TopMost = true;
            icon = false;
            hide = false;
            title = "Msticky";
            openFile = null;
            zoom = 10;

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            
            setMenuVisible(Properties.Settings.Default.MenuVisible);
            UpdateHistoryToolStripMenuItem();

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                SetImage(args[1]);
            }
        }

        // http://tfcduke.developpez.com/tutoriel/format/tga/fichiers/tga_specs.pdf
        class Tga
        {
            enum ImageType : byte
            {
                NoImageData = 0,
                UncompressedColorMappedImage = 1,
                UncompressedTrueColorImage = 2,
                UncompressedBlackAndWhiteImage = 3,
                RLEColorMappedImage = 9,
                RLETrueColorImage = 10,
                RLEBalackAndWhiteImage = 11,
            };

            struct Header
            {
                public byte id;
                public byte colorMapType;
                public byte imageType;
                public ColorMapSpecification colorMapSpecification;
                public ImageSpecification imageSpecification;

                public override string ToString()
                {
                    return id + "," + colorMapType + "," + imageType + "," + colorMapSpecification + "," + imageSpecification;
                }
            };

            struct ColorMapSpecification
            {
                public short firstEntryIndex;
                public short colorMapLength;
                public byte colorMapEntrySize;

                public override string ToString()
                {
                    return firstEntryIndex + "," + colorMapLength + "," + colorMapEntrySize;
                }
            };
            struct ImageSpecification
            {
                public short xOriginOfImage;
                public short yOriginOfImage;
                public short imageWidth;
                public short imageHeight;
                public byte pixelDepth;
                public byte imageDescriptor;

                public override string ToString()
                {
                    return xOriginOfImage + "," + yOriginOfImage + "," + imageWidth + "," + imageHeight + "," + pixelDepth + "," + imageDescriptor;
                }
            };

            Header header;

            abstract class Indexer
            {
                public int Index;
                private int Increment;

                public Indexer(int Increment)
                {
                    Index = 18;
                    this.Increment = Increment;
                }

                public void Next()
                {
                    BeforeIncrement();

                    if (IsIncrement())
                    {
                        Index += Increment;

                        AfterIncrement();
                    }
                }

                protected abstract bool IsIncrement();
                protected abstract void BeforeIncrement();
                protected abstract void AfterIncrement();
            }

            class UncompressedIndexer : Indexer
            {
                public UncompressedIndexer(int Increment) : base(Increment) { }

                protected override bool IsIncrement() { return true; }
                protected override void BeforeIncrement() { }
                protected override void AfterIncrement() { }
            }

            class RLEIndexer : Indexer
            {
                bool raw;
                int count;
                int num;
                byte[] Data;

                public RLEIndexer(int Increment, byte[] Data) : base(Increment) { this.Data = Data; SetCount(); }

                void SetCount()
                {
                    num = 0;

                    if ((Data[Index] & 0x80) != 0)
                    {
                        count = (Data[Index++] & 0x7F) + 1;
                        raw = false;
                    }
                    else
                    {
                        count = Data[Index++] + 1;
                        raw = true;
                    }
                }

                protected override bool IsIncrement()
                {
                    if (num >= count) { return true; }

                    if (raw) { return true; }

                    return false;
                }
                protected override void BeforeIncrement() { num++; }
                protected override void AfterIncrement() { if (num >= count) SetCount(); }
            }

            abstract class PixelReader
            {
                public int X { get; protected set; }
                public int Y { get; protected set; }
                protected byte[] Data { get; private set; }
                public Indexer Indexer { get; protected set; }

                protected int Height { get; private set; }
                protected int Width { get; private set; }

                public PixelReader(byte[] Data, int Width, int Height, Indexer Indexer)
                {
                    this.X = 0;
                    this.Y = Height - 1; ;
                    this.Data = Data;
                    this.Indexer = Indexer;

                    this.Height = Height;
                    this.Width = Width;
                }

                public bool Next()
                {
                    Indexer.Next();

                    X = X + 1;
                    if (X >= Width)
                    {
                        X = 0;
                        Y--;
                    }
                    return (Y != -1);
                }

                public abstract System.Drawing.Color GetColor();
            };

            class PixelReader16 : PixelReader
            {
                public PixelReader16(byte[] Data, int Width, int Height, Indexer Indexer)
                    : base(Data, Width, Height, Indexer) { }

                public override System.Drawing.Color GetColor()
                {
                    byte one = Data[Indexer.Index];
                    byte two = Data[Indexer.Index + 1];

                    int blue = (one & 0x1F) * 8;
                    int green = (((one >> 5) & 0x07) + (two & 0x03)) * 8;
                    int red = ((two >> 2) & 0x1F) * 8;
                    int alpha = ((two & 0x80) != 0) ? 255 : 0;

                    return System.Drawing.Color.FromArgb(alpha, red, green, blue);
                }
            }

            class PixelReader24 : PixelReader
            {
                public PixelReader24(byte[] Data, int Width, int Height, Indexer Indexer)
                    : base(Data, Width, Height, Indexer) { }

                public override System.Drawing.Color GetColor()
                {
                    int blue = Data[Indexer.Index];
                    int green = Data[Indexer.Index + 1];
                    int red = Data[Indexer.Index + 2];
                    int alpha = 255;

                    return System.Drawing.Color.FromArgb(alpha, red, green, blue);
                }
            }

            class PixelReader32 : PixelReader
            {
                public PixelReader32(byte[] Data, int Width, int Height, Indexer Indexer)
                    : base(Data, Width, Height, Indexer) { }

                public override System.Drawing.Color GetColor()
                {
                    int blue = Data[Indexer.Index];
                    int green = Data[Indexer.Index + 1];
                    int red = Data[Indexer.Index + 2];
                    int alpha = Data[Indexer.Index + 3];

                    return System.Drawing.Color.FromArgb(alpha, red, green, blue);
                }
            }

            PixelReader GetPixelReader(byte[] bs)
            {
                Indexer indexer = null;

                switch (header.imageSpecification.pixelDepth)
                {
                    case 16:
                        if (header.imageSpecification.imageDescriptor != 1)
                        {
                            MessageBox.Show("Not support TGA alpha. " + header.imageSpecification);
                            return null;
                        }
                        indexer = (header.imageType == (byte)ImageType.RLETrueColorImage) ? new RLEIndexer(2, bs) : indexer = new UncompressedIndexer(2);
                        return new PixelReader16(bs, header.imageSpecification.imageWidth, header.imageSpecification.imageHeight, indexer);
                    case 24:
                        if (header.imageSpecification.imageDescriptor != 0)
                        {
                            MessageBox.Show("Not support TGA alpha. " + header.imageSpecification);
                            return null;
                        }
                        indexer = (header.imageType == (byte)ImageType.RLETrueColorImage) ? new RLEIndexer(3, bs) : indexer = new UncompressedIndexer(3);
                        return new PixelReader24(bs, header.imageSpecification.imageWidth, header.imageSpecification.imageHeight, indexer);
                    case 32:
                        if (header.imageSpecification.imageDescriptor != 8)
                        {
                            MessageBox.Show("Not support TGA alpha. " + header.imageSpecification);
                            return null;
                        }
                        indexer = (header.imageType == (byte)ImageType.RLETrueColorImage) ? new RLEIndexer(4, bs) : indexer = new UncompressedIndexer(4);
                        return new PixelReader32(bs, header.imageSpecification.imageWidth, header.imageSpecification.imageHeight, indexer);
                }
                MessageBox.Show("Not support TGA pixel depth. " + header.imageSpecification);
                return null;
            }

            public static Bitmap Read(String file)
            {
                Bitmap bitmap;

                FileStream fs = new FileStream(file,FileMode.Open,FileAccess.Read);
                byte[] bs = new byte[fs.Length];
                fs.Read(bs, 0, bs.Length);
                fs.Close();

                Tga tga = new Tga();
                tga.header.id = bs[0];
                tga.header.colorMapType = bs[1];
                tga.header.imageType = bs[2];

                tga.header.colorMapSpecification.firstEntryIndex = (short)((short)bs[3] + (short)bs[4] * 256);
                tga.header.colorMapSpecification.colorMapLength = (short)((short)bs[5] + (short)bs[6] * 256);
                tga.header.colorMapSpecification.colorMapEntrySize = bs[7];

                tga.header.imageSpecification.xOriginOfImage = (short)((short)bs[8] + (short)bs[9] * 256);
                tga.header.imageSpecification.yOriginOfImage = (short)((short)bs[10] + (short)bs[11] * 256);
                tga.header.imageSpecification.imageWidth = (short)((short)bs[12] + (short)bs[13] * 256);
                tga.header.imageSpecification.imageHeight = (short)((short)bs[14] + (short)bs[15] * 256);
                tga.header.imageSpecification.pixelDepth = bs[16];
                tga.header.imageSpecification.imageDescriptor = bs[17];

                bitmap = new Bitmap(tga.header.imageSpecification.imageWidth, tga.header.imageSpecification.imageHeight);

                switch (tga.header.imageType)
                {
                    case (byte)ImageType.UncompressedTrueColorImage:
                        break;
                    case (byte)ImageType.RLETrueColorImage:
                        break;
                    default:
                        MessageBox.Show("Not implemented TGA Format. imageType:" + tga.header.imageType);
                        return null;
                }

                if (tga.header.colorMapSpecification.firstEntryIndex != 0 ||
                    tga.header.colorMapSpecification.colorMapLength != 0 ||
                    tga.header.colorMapSpecification.colorMapEntrySize != 0)
                {
                    MessageBox.Show("Not support TGA ColorMap. " + tga.header.colorMapSpecification);
                    return null;
                }

                if (tga.header.imageSpecification.xOriginOfImage != 0 ||
                    tga.header.imageSpecification.yOriginOfImage != 0)
                {
                    MessageBox.Show("Not support TGA origin. " + tga.header.imageSpecification);
                    return null;
                }

                PixelReader reader = tga.GetPixelReader(bs);
                if (reader == null)
                {
                    return null;
                }

                do
                {
                    bitmap.SetPixel(reader.X, reader.Y, reader.GetColor());
                } while (reader.Next());

                return bitmap;
            }
        }

        private Bitmap GetImageTga(String file)
        {
            return Tga.Read(file);
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
            g.DrawImage(bitmapBase, 0, 0, bitmapBase.Width, bitmapBase.Height);
            g.Dispose();
        }

        private void SetImage(String file)
        {
            if (!System.IO.File.Exists(file))
            {
                MessageBox.Show("file not found :-( " + file);
                return;
            }

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
            pictureBox1.Image = null;
            zoom = 10;
            rotate = 0.0f;

            title = "Msticky";
            openFile = null;

            if (file.EndsWith("mov"))
            {
                axQTControl1.Visible = true;
                axQTControl1.SetScale(1);
                axQTControl1.Sizing = QTSizingModeEnum.qtControlFitsMovie;
                axQTControl1.FileName = file;
                axQTControl1.Sizing = QTSizingModeEnum.qtManualSizing;
                this.ClientSize = axQTControl1.Size;
                axQTControl1.FileName = file;
                axQTControl1.Movie.Loop = true;
                title = System.IO.Path.GetFileName(file);
                openFile = file;

                movieMargin = new Size(axQTControl1.Width - axQTControl1.Movie.Width, axQTControl1.Height - axQTControl1.Movie.Height);

                AddHistory(file);
            }
            else
            {
                axQTControl1.Visible = false;
                if (file.EndsWith("psd"))
                {
                    bitmapBase = GetImagePsd(file);
                }
                else if (file.EndsWith("tga"))
                {
                    bitmapBase = GetImageTga(file);
                }
                else
                {
                    bitmapBase = new Bitmap(file);
                }

                if (bitmapBase != null)
                {
                    AddHistory(file);

                    bitmap = new Bitmap(bitmapBase.Width, bitmapBase.Height);
                    UpdateBitmap(bitmap, bitmapBase);
                    pictureBox1.Image = bitmap;
                    this.ClientSize = bitmap.Size;

                    title = System.IO.Path.GetFileName(file);
                    openFile = file;
                    SetPictureBox1Size();
                }
            }

            UpdateTitle();
        }

        private void SetPictureBox1Size()
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Width = (int)(pictureBox1.Image.Width * zoom * 0.1f);
                pictureBox1.Height = (int)(pictureBox1.Image.Height * zoom * 0.1f);
            }

            if (axQTControl1.Visible)
            {
                axQTControl1.SetScale(zoom * 0.1f);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image(*.bmp;*.png;*.gif;*.jpg;*.jpeg;*.psd;*.tiff;*.tga)|*.bmp;*.png;*.gif;*.jpg;*.jpeg;*.psd;*.tiff;*.tga|Movie(*.mov)|*.mov";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SetImage(ofd.FileName);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        UpdateOpacity(1.0);
                        break;
                    case Keys.S:
                        UpdateOpacity(0.0);
                        break;
                    case Keys.R:
                        resetRotation();
                        break;
                    case Keys.H:
                        FlipHorizontal();
                        break;
                }
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.A:
                    UpdateOpacity(this.Opacity + 0.2);
                    break;
                case Keys.S:
                    UpdateOpacity(this.Opacity - 0.2);
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
                    fit();
                    break;
                case Keys.C:
                    UpdateZoom(false, 0, 0);
                    break;
                case Keys.X:
                    UpdateZoom(true, 0, 0);
                    break;
                case Keys.W:
                    UpdateRotate(true);
                    break;
                case Keys.E:
                    UpdateRotate(false);
                    break;
            }
        }

        private void topToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
            this.topToolStripMenuItem.Checked = this.TopMost;
            this.topToolStripMenuItem1.Checked = this.TopMost;
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
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
                return;

            mouseDown(e.X, e.Y, e.Clicks);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
                return;

            mouseMove(e.X, e.Y);
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                UpdateRotate(e.Delta >= 0);
            }
            else
            {
                UpdateZoom(e.Delta > 0, e.X, e.Y);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
                return;

            mouseDown(e.X, e.Y, e.Clicks);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
                return;

            mouseMove(e.X, e.Y);
        }

        private void mouseDown(int x, int y, int clicks)
        {
            mousePoint = new Point(x, y);
            doubleClick = false;

            if (clicks == 2)
            {
                doubleClick = true;

                iconize(mousePoint);
            }
        }

        private void mouseMove(int x, int y)
        {
            if (doubleClick)
                return;

            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                pictureBox1.Left += x - mousePoint.X;
                pictureBox1.Top += y - mousePoint.Y;
            }
            else
            {
                this.Left += x - mousePoint.X;
                this.Top += y - mousePoint.Y;
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
            UpdateFreeze();
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
                UpdateFreeze();
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            axQTControl1.Size = this.ClientSize;
        }

        private void axQTControl1_MouseUpEvent(object sender, AxQTOControlLib._IQTControlEvents_MouseUpEvent e)
        {
            if (e.button != 2)
                return;

            this.contextMenuStrip1.Show(this, e.x, e.y);
        }

        private void axQTControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    axQTControl1.Movie.StepFwd();
                    break;
                case Keys.Left:
                    axQTControl1.Movie.StepRev();
                    break;
            }
        }

        private void hideMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setMenuVisible(false);
            saveMenuVisible();
        }

        private void showMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setMenuVisible(true);
            saveMenuVisible();
        }

        private void saveMenuVisible()
        {
            Properties.Settings.Default.MenuVisible = menuStrip1.Visible;
            Properties.Settings.Default.Save();
        }

        private void setMenuVisible(Boolean visible)
        {
            menuStrip1.Visible = visible;
            showMenuToolStripMenuItem.Visible = !visible;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://mononoco.hobby-site.org/pukiwiki/index.php?Msticky");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateOpacity(double value)
        {
            this.Opacity = value;
            if (value >= 1.0)
            {
                this.freezeToolStripMenuItem.Visible = false;
                this.freezeToolStripMenuItem1.Visible = false;
            }
            else
            {
                this.freezeToolStripMenuItem.Visible = true;
                this.freezeToolStripMenuItem1.Visible = true;
            }
        }

        private void FlipHorizontal()
        {
            if (pictureBox1.Image == null)
                return;
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            pictureBox1.Invalidate();
        }

        private void UpdateZoom(Boolean zoomIn, int mouseX, int mouseY)
        {
            bool adjust = true;
            int beforeZoom = zoom;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            if (zoomIn)
            {
                zoom += 1;
                if (zoom > 30)
                {
                    zoom = 30;
                    adjust = false;
                }
            }
            else
            {
                zoom -= 1;
                if (zoom < 2)
                {
                    zoom = 2;
                    adjust = false;
                }
            }

            SetPictureBox1Size();
            UpdateTitle();

            if (adjust)
            {
                int x = mouseX - pictureBox1.Left;
                int y = mouseY - pictureBox1.Top;

                this.pictureBox1.Left -= (int)Math.Floor(x * ((float)zoom / beforeZoom - 1));
                this.pictureBox1.Top -= (int)Math.Floor(y * ((float)zoom / beforeZoom - 1));
            }

            if (axQTControl1.Visible || ((Control.ModifierKeys & Keys.Control) == Keys.Control))
            {
                fit();
            }
        }

        private void fit()
        {
            if (pictureBox1.Image != null)
            {
                this.Top += pictureBox1.Top;
                this.Left += pictureBox1.Left;
                pictureBox1.Left = 0;
                pictureBox1.Top = 0;
                this.ClientSize = pictureBox1.Size;
            }

            if (axQTControl1.Visible)
            {
                this.Top += axQTControl1.Top;
                this.Left += axQTControl1.Left;
                axQTControl1.Top = 0;
                axQTControl1.Left = 0;
                this.ClientSize = new Size(axQTControl1.Movie.Width + movieMargin.Width, axQTControl1.Movie.Height + movieMargin.Height);
            }
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateZoom(true, 0, 0);
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateZoom(false, 0, 0);
        }

        private void fitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fit();
        }

        private void increaseOpacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateOpacity(this.Opacity + 0.2);
        }

        private void decreaseOpacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateOpacity(this.Opacity - 0.2);
        }

        private void opacityMaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateOpacity(1.0);
        }

        private void opacityMinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateOpacity(0.0);
        }

        private void resetRotation()
        {
            rotate = 0;
            UpdateBitmap(bitmap, bitmapBase);
            pictureBox1.Invalidate();
        }

        private void resetRotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetRotation();
        }

        private void UpdateRotate(Boolean cw)
        {
            if (cw)
            {
                rotate += 2.0f;
            }
            else
            {
                rotate -= 2.0f;
            }

            UpdateBitmap(bitmap, bitmapBase);

            pictureBox1.Invalidate();
        }

        private void cWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateRotate(true);
        }

        private void cCWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateRotate(false);
        }

        private void iconize(Point point)
        {
            if (!icon)
            {
                BeforeSize = this.ClientSize;
                BeforeLocation = this.Location;
                BeforePictureBoxLocation = pictureBox1.Location;

                this.ClientSize = new Size(32, 32);
                pictureBox1.Location = new Point(0, 0);
                pictureBox1.Size = this.ClientSize;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                Point p = PointToClient(Location);
                Rectangle r = ClientRectangle;
                r.Offset(-p.X, -p.Y);
                Region = new Region(r);

                Point l = this.PointToScreen(point);
                l.Offset(new Point(0, -32)); // appropriate
                this.Location = l;

                icon = true;

                hide = menuStrip1.Visible;
                setMenuVisible(false);
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                this.ClientSize = BeforeSize;
                this.Location = BeforeLocation;
                pictureBox1.Location = BeforePictureBoxLocation;

                Region = null;

                SetPictureBox1Size();

                icon = false;
                setMenuVisible(hide);
            }
        }

        private void iconizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iconize(new Point(0, 0));
        }

        private void moveWindowLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Left -= 1;
        }

        private void moveWindowRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Left += 1;
        }

        private void moveWindowUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Top -= 1;
        }

        private void moveWindowDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Top += 1;
        }

        private void moveImageLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Left -= 1;
        }

        private void moveImageRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Left += 1;
        }

        private void moveImageUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Top -= 1;
        }

        private void moveImageDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Top += 1;
        }

        private void axQTControl1_MouseDownEvent(object sender, AxQTOControlLib._IQTControlEvents_MouseDownEvent e)
        {
            // left button
            if( e.button == 1 )
                mouseDown(e.x, e.y, 1);
        }

        private void axQTControl1_MouseMoveEvent(object sender, AxQTOControlLib._IQTControlEvents_MouseMoveEvent e)
        {
            if (e.button == 1)
                mouseMove(e.x, e.y);
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFile == null)
            {
                Process.Start(System.Windows.Forms.Application.ExecutablePath);
            }
            else
            {
                Process.Start(System.Windows.Forms.Application.ExecutablePath, "\""+openFile + "\"");
            }
        }

        private void flipHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlipHorizontal();
        }
    }
}
