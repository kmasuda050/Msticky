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
                case Keys.Right:
                    this.Opacity += 0.1;
                    break;
                case Keys.Left:
                    this.Opacity -= 0.1;
                    break;
            }
        }

        private void topToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }
    }
}
