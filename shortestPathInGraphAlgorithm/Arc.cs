using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortestPathInGraphAlgorithm
{
    public class Arc : Shape
    {
        public int Weigth { get; set; }
        public Node Parent { get; set; }
        public Node Child { get; set; }
        public Point Center { get; set; }
        public List<Point> Еndpoints { get; set; } = new List<Point>();
        public List<Point> Points { get; set; } = new List<Point>();

        public Arc(Node parent, Node child, Color color, List<Point> points, int weight)
        {
            this.Parent = parent;
            this.Child = child;
            this.Color = color;
            foreach (Point point in points)
                Еndpoints.Add(point);
            Center = new Point(((Еndpoints[0].X + Еndpoints[1].X) / 2), ((Еndpoints[0].Y + Еndpoints[1].Y) / 2));
            this.Weigth = weight;
        }

        public Arc()
        {

        }
        public override bool Contains(Point point)
        {
            return false;
        }

        public override void Paint(Graphics graphics)
        {
            this.Color = IsChecked ? Color.Green : Color.Yellow;

            Pen pen = new Pen(Color, 6);
            graphics.DrawLine(pen, Еndpoints[0], Еndpoints[1]);
            Font font = new Font("Times New Roman", 17);
            if (this.Weigth > 0)
            {
                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    graphics.DrawString(this.Weigth.ToString(), font, new SolidBrush(Color.Black), Center.X, Center.Y, format);
                }
            }
        }
    }
}
