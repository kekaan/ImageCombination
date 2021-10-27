using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1
{
    class Picture : Element
    {
        private Bitmap image;

        public Picture(string name)
        {
            image = new Bitmap(name);
        }

        public Picture(Picture picture, Size size, Point location)
        {
            image = picture.image;
            ElementSize = size;
            ElementLocation = location;
        }

        public override Bitmap ToBitmap()
        {
            return image;
        }
    }
}
