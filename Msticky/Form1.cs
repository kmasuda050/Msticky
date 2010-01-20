using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Msticky
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = null;
            this.TopMost = true;
        }

        private void SetImage(String file)
        {
            if (bitmap != null)
                bitmap.Dispose();
            bitmap = new Bitmap(file);

            pictureBox1.Image = bitmap;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Size = bitmap.Size;

            this.ClientSize = bitmap.Size;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image(*.bmp;*.png;*.gif;*.jpg;*.jpeg)|*.bmp;*.png;*.gif;*.jpg;*.jpeg";
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
    }
}
