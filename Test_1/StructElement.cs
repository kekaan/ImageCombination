using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1
{
    abstract class StructElement : Element
    {
        public List<Element> Elements { get; protected set; }

        public StructElement Add(Element element)
        {
            if (element.Equals(this))
                throw new ArgumentException();
            Elements.Add(element);
            return this;
        }
    }    
}
