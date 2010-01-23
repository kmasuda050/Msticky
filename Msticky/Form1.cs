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
        private Bitmap bitmap;
        private SimplePsd.CPSD psd;
        private Point mousePoint;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = null;
            psd = null;
            this.TopMost = true;
        }

        private void SetImagePsd(String file)
        {
            psd = new SimplePsd.CPSD();
            int nResult = psd.Load(file);
            if (nResult == 0)
            {
                //int nCompression = psd.GetCompression();
                pictureBox1.Image = Image.FromHbitmap(psd.GetHBitmap());
                pictureBox1.Size = pictureBox1.Image.Size;
                this.ClientSize = pictureBox1.Image.Size;
            }
            else if (nResult == -1)
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
        }

        private void SetImage(String file)
        {
            pictureBox1.Location = new Point(0, 0);

            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }
            if (psd != null)
                psd = null;

            if (file.EndsWith("psd"))
            {
                SetImagePsd(file);
            }
            else
            {
                bitmap = new Bitmap(file);
                pictureBox1.Image = bitmap;
                pictureBox1.Size = bitmap.Size;
                this.ClientSize = bitmap.Size;
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
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
                return;

            mousePoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
                return;
            this.Left += e.X - mousePoint.X;
            this.Top += e.Y - mousePoint.Y;
        }
    }
}
