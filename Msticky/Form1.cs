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
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(@"C:\tmp\a.bmp");

            pictureBox1.Image = bitmap;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Size = bitmap.Size;

            this.ClientSize = bitmap.Size;
        }
    }
}
