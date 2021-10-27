using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1
{
    abstract class Element
    {
        public Point ElementLocation { get; protected set; }
        public Size ElementSize { get; protected set; }

        public abstract Bitmap ToBitmap();
    }
}
