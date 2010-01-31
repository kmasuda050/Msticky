using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FreeImageAPI;
using FreeImageAPI.Plugins;

namespace Msticky
{
    public partial class Form1 : Form
    {
        private FreeImageBitmap bitmap = null;
        private Point mousePoint;
        private Boolean isPictureBoxLocationRest;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = null;
            isPictureBoxLocationRest = false;
            this.TopMost = true;

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                SetImage(args[1]);
            }
        }

        private void SetImage(String file)
        {
            pictureBox1.Location = new Point(0, 0);

            try
            {
                FreeImageBitmap fib = new FreeImageBitmap(file);
                FreeImagePlugin plug = PluginRepository.Plugin(fib.ImageFormat);

                if (fib == null || fib.IsDisposed)
                {
                    MessageBox.Show("Unexpected error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (fib.ImageType != FREE_IMAGE_TYPE.FIT_BITMAP)
                {
                    if (!fib.ConvertType(FREE_IMAGE_TYPE.FIT_BITMAP, true))
                    {
                        MessageBox.Show("Error converting bitmap to standard type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if ((bitmap != null) && !object.ReferenceEquals(bitmap, fib))
                {
                    bitmap.Dispose();
                }
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                }

                pictureBox1.Image = (Bitmap)(bitmap = fib);
                pictureBox1.Size = bitmap.Size;
                this.ClientSize = bitmap.Size;
            }
            catch
            {
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

            if (e.Clicks == 2)
                isPictureBoxLocationRest = true;
        }

        private void mouseMove(MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
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

        private void mouseUp()
        {
            if (isPictureBoxLocationRest)
            {
                pictureBox1.Left = 0;
                pictureBox1.Top = 0;
                isPictureBoxLocationRest = false;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseUp();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseUp();
        }
    }
}
