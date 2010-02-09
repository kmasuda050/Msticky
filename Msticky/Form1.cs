using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimplePsd;

namespace Msticky
{
    public partial class Form1 : Form
    {
        private Bitmap bitmap = null;
        private SimplePsd.CPSD psd;
        private Point mousePoint;
        private Size BeforeSize;
        private Point BeforeLocation;
        private float zoom;
        private Boolean doubleClick;
        private Boolean icon;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
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

        private void SetImage(String file)
        {
            pictureBox1.Location = new Point(0, 0);

            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }

            bitmap = (file.EndsWith("psd")) ? GetImagePsd(file) : new Bitmap(file);

            if (bitmap != null)
            {
                zoom = 1.0f;
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
                    break;
                case Keys.S:
                    this.Opacity -= 0.2;
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
    }
}
