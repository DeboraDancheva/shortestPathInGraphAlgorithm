using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortestPathInGraphAlgorithm
{
    public class Node : Shape
    {
        public List<Arc> Arcs = new List<Arc>();

        public Node(int index, Point location)
        {
            Index = index;
            Location = location;
            Color = Color.Blue;
        }

        public int ShortestPath { get; set; }
        public Point Location { get; set; }
        public Color InnerFillColor { get; set; }
        public int Weight { get; set; }
        public int Index { get; set; }
        public int Radius { get; set; } = 20;
        public Node PreviousNode { get; set; }
       
        public Node AddArc(Arc arc)
        {
            Arcs.Add(arc);

            if (!arc.Child.Arcs.Exists(a => a.Parent == arc.Child && a.Child == arc.Parent))
            {
                List<Point> endPoints = new List<Point> { arc.Еndpoints.Last(), arc.Еndpoints.First() };
                arc.Child.AddArc(new Arc(arc.Child, arc.Parent, arc.Color, endPoints, arc.Weigth));
            }

            return this;
        }

        public override void Paint(Graphics graphics)
        {
             this.Color = IsChecked ? Color.Red : Color.Blue;

            Pen pen = new Pen(this.Color, 2);
            Brush br = new SolidBrush(Color.Red);
            graphics.DrawEllipse(pen, Location.X - Radius, Location.Y - Radius, Radius * 2, Radius * 2);
            Font font = new Font("Times New Roman", 14);

            if (InnerFillColor == Color.Red)
                graphics.FillEllipse(br, Location.X - Radius, Location.Y - Radius, Radius * 2, Radius * 2);

            using (StringFormat format = new StringFormat())
            {
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                graphics.DrawString(Index.ToString(), font, new SolidBrush(Color.Blue), Location.X, Location.Y, format);
            }
        }

        public override bool Contains(Point point)
        {
            return (point.X - Location.X) * (point.X - Location.X) + (point.Y - Location.Y) * (point.Y - Location.Y) < Radius * Radius;
        }
    }
}
