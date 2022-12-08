using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HNUDIP;
using ImageProcess2;

namespace IS_DIP_Cuizon
{
    public partial class Form1 : Form
    {
        private Bitmap loaded, processed;
        public Form1()
        {
            InitializeComponent();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            loaded = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image= loaded;
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcess.copyImage(ref loaded, ref processed);
            pictureBox2.Image = processed;
            BitmapFilter.GrayScale(processed);
        }

        private void basicCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcess.copyImage(ref loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void colorInversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcess.copyImage(ref loaded, ref processed);
            pictureBox2.Image = processed;
            BitmapFilter.Invert(processed);
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    Color pixel = loaded.GetPixel(x, y);
                    int  r, g, b;
                    r = (int)(0.393 * pixel.R + 0.769 * pixel.G + 0.189 * pixel.B);
                    g = (int)(0.349 * pixel.R + 0.686 * pixel.G + 0.168 * pixel.B);
                    b = (int)(0.272 * pixel.R + 0.534 * pixel.G + 0.131 * pixel.B);
                    if (r > 255) { r = 255; }
                    if(g > 255) { g = 255; }
                    if (b > 255) { b = 255; }
                    processed.SetPixel(x, y, Color.FromArgb(r,g,b));
                }
            }
            pictureBox2.Image = processed;
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcess.Histogram(ref loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
    }
}
