using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_1
{
    public partial class ImageCombinationForm : Form
    {
        public ImageCombinationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var r1 = new Row();
            var c1 = new Column();
            var r2 = new Row();
            var c2 = new Column();
            var r3 = new Row();

            r1.Add(Img("12.jpg")).Add(c1).Add(Img("13.jpg"));
            c1.Add(r2).Add(Img("7.jpg"));
            r2.Add(Img("4.jpg")).Add(c2);
            c2.Add(r3).Add(Img("5.jpg"));
            r3.Add(Img("3.jpg")).Add(Img("6.jpg"));

            drawStoryboard(r1, 800);
        }

        private Picture Img(string name)
        {
            return new Picture(name);
        }

        private void drawStoryboard(StructElement r, int width)
        {
            Bitmap img = SetWidthToBitmap(r.ToBitmap(), width);
            button1.Visible = false;
            pictureBox1.Size = img.Size;
            pictureBox1.Image = (Image)img;
            this.ClientSize = pictureBox1.Size;
        }

        public Bitmap SetWidthToBitmap(Bitmap bitmap, int width)
        {
            int sourceWidth = bitmap.Width;
            int sourceHeight = bitmap.Height;

            float nPercent = 0;

            nPercent = ((float)width / (float)sourceWidth);

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);


            return new Bitmap(bitmap, new Size(destWidth, destHeight));
        }
    }
}
