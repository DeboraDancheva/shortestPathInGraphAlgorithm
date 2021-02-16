using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortestPathInGraphAlgorithm
{
    public abstract class Shape
    {
        public Color Color { get; set; }
        public bool IsChecked { get; set; } = false;

        public abstract void Paint(Graphics graphics);
        public abstract bool Contains(Point point);
    }
}
