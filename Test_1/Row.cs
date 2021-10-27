using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1
{
    class Row : StructElement
    {
        public Size Size { get; }

        public Row()
        {
            Elements = new List<Element>();
        }

        public override Bitmap ToBitmap()
        {
            Bitmap[] bitmaps = new Bitmap[Elements.Count];
            for (int i = 0; i < Elements.Count; i++)
                bitmaps[i] = Elements[i].ToBitmap();
            Bitmap widestPicture = bitmaps[0];
            int maxWidth = bitmaps[0].Width;
            foreach (Bitmap e in bitmaps)
            {
                if (e.Width > maxWidth)
                {
                    maxWidth = e.Width;
                    widestPicture = e;
                }
            }

            Bitmap finalBitmap = ResizeBitmap(bitmaps[0], maxWidth);
            for (int i = 1; i < Elements.Count; i++)
            {
                finalBitmap = CombineBitmap(finalBitmap, ResizeBitmap(bitmaps[i], maxWidth));
            }

            return finalBitmap;
        }

        private Bitmap CombineBitmap(Bitmap first, Bitmap second)
        {
            Bitmap finalBitmap = new Bitmap(first.Width + second.Width, first.Height);
            using (Graphics g = Graphics.FromImage(finalBitmap))
            {
                g.DrawImage(first, new Rectangle(0, 0, first.Width, first.Height));
                g.DrawImage(second, new Rectangle(first.Width, 0, second.Width, second.Height));
            }
            return finalBitmap;
        }

        private Bitmap ResizeBitmap(Bitmap bitmap, int height)
        {
            int sourceWidth = bitmap.Width;
            int sourceHeight = bitmap.Height;

            float nPercent = 0;

            nPercent = ((float)height / (float)sourceHeight);

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);


            return new Bitmap(bitmap, new Size(destWidth, destHeight));
        }
    }
}
