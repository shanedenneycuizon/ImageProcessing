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
        private Bitmap loaded, imageA, imageB, processed,resultImage;
        public Form1()
        {
            InitializeComponent();
            imageButton.Hide();
            bgButton.Hide();
            subtractButton.Hide();

        }

        private void Reset()
        {
            imageButton.Hide();
            bgButton.Hide();
            subtractButton.Hide();
            pictureBox1.Image = null;
            pictureBox2.Image=null;
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

            processed = new Bitmap(loaded.Width, loaded.Height);

            
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    Color data = loaded.GetPixel(x, y);
                    int grey = (data.R+data.G+data.B)/3;
                    processed.SetPixel(x, y, Color.FromArgb(grey,grey,grey));
                }
            }
            pictureBox2.Image = processed;
        }

        private void basicCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);

            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    Color data = loaded.GetPixel(x, y);
                    processed.SetPixel(x, y, data);
                }

            }
            pictureBox2.Image = processed;
        }

        private void colorInversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);

            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    Color data = loaded.GetPixel(x, y);
                    processed.SetPixel(x, y, Color.FromArgb(255-data.R,255-data.G,255-data.B));
                }

            }
            pictureBox2.Image = processed;
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
            
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            imageB = new Bitmap(openFileDialog2.FileName);
            pictureBox1.Image= imageB;
        }

        private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
        {
            imageA = new Bitmap(openFileDialog3.FileName);
            pictureBox2.Image= imageA;
        }

        private void bgButton_Click(object sender, EventArgs e)
        {
            openFileDialog3.ShowDialog();
        }

        private void subtractButton_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(imageB.Width, imageB.Height);
            Color mygreen = Color.FromArgb(0, 255, 0);
            int greygreen = (mygreen.R + mygreen.G + mygreen.B)/3;
            int threshold = 5;

            for (int x = 0; x<imageB.Width;x++)
            {
                for (int y = 0; y <imageB.Height; y++)
                {
                    Color pixel = imageB.GetPixel(x, y);
                    Color backpixel = imageA.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    int subtractvalue = Math.Abs(grey - greygreen);
                    if(subtractvalue < threshold)
                        processed.SetPixel(x, y, backpixel);
                    else
                        processed.SetPixel(x, y, pixel);
                }
            }
            pictureBox3.Image = processed;
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void subtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
            imageButton.Show();
            bgButton.Show();
            subtractButton.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
            openFileDialog1.ShowDialog();
        }
    }
}
