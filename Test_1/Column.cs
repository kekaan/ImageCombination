using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1
{
    class Column : StructElement
    {
        public Column()
        {
            Elements = new List<Element>();
        }

        public override Bitmap ToBitmap()
        {
            Bitmap[] bitmaps = new Bitmap[Elements.Count];
            for (int i = 0; i < Elements.Count; i++)
                bitmaps[i] = Elements[i].ToBitmap();

            Bitmap highestPicture = bitmaps[0];
            int maxHeight = bitmaps[0].Height;
            foreach (Bitmap e in bitmaps)
            {
                if (e.Height > maxHeight)
                {
                    maxHeight = e.Height;
                    highestPicture = e;
                }
            }

            Bitmap finalBitmap = ResizeBitmap(bitmaps[0], maxHeight);
            for (int i = 1; i < Elements.Count; i++)
                finalBitmap = CombineBitmap(finalBitmap, ResizeBitmap(bitmaps[i], maxHeight));

            return finalBitmap;
        }

        private Bitmap CombineBitmap(Bitmap first, Bitmap second)
        {
            Bitmap finalBitmap = new Bitmap(first.Width, first.Height + second.Height);

            using (Graphics g = Graphics.FromImage(finalBitmap))
            {
                g.DrawImage(first, new Rectangle(0, 0, first.Width, first.Height));
                g.DrawImage(second, new Rectangle(0, first.Height, second.Width, second.Height));
            }

            return finalBitmap;
        }

        private Bitmap ResizeBitmap(Bitmap bitmap, int width)
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
