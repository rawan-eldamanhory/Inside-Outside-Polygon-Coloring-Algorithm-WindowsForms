using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Inside-Outside Polygon Coloring Algorithm
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Point[] polygonPoints = new Point[] {
                new Point(170, 250),
                new Point(200, 220),
                new Point(270, 240),
                new Point(300, 170),
                new Point(280, 130),
                new Point(210, 150),
                new Point(220, 100),
                new Point(190, 80),
                new Point(140, 100),
                new Point(170, 130),
                new Point(160, 200),
                new Point(150, 160),
                new Point(130, 130),
                new Point(100, 180)    
        };

        private Pen outlinePen = new Pen(Color.DarkGray, 2);
        private Brush insideBrush = new SolidBrush(Color.Black);
        private Brush outsideBrush = new SolidBrush(Color.LightGray);
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true; 
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.DrawPolygon(outlinePen, polygonPoints);

            int minX = polygonPoints[0].X;
            int maxX = polygonPoints[0].X;
            int minY = polygonPoints[0].Y;
            int maxY = polygonPoints[0].Y;
            foreach (Point point in polygonPoints)
            {
                if (point.X < minX) minX = point.X;
                if (point.X > maxX) maxX = point.X;
                if (point.Y < minY) minY = point.Y;
                if (point.Y > maxY) maxY = point.Y;
            }
            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    Point testPoint = new Point(x, y);
                    if (IsInsidePolygon(testPoint))
                    {
                        g.FillRectangle(insideBrush, x, y, 1, 1);
                    }
                    else
                    {
                        g.FillRectangle(outsideBrush, x, y, 1, 1);
                    }
                }
            }
        }

        private bool IsInsidePolygon(Point testPoint)
        {
            bool result = false;
            for (int i = 0, j = polygonPoints.Length - 1; i < polygonPoints.Length; j = i++)
            {
                if ((polygonPoints[i].Y > testPoint.Y) != (polygonPoints[j].Y > testPoint.Y) &&
                    (testPoint.X < (polygonPoints[j].X - polygonPoints[i].X) * (testPoint.Y - polygonPoints[i].Y) / (polygonPoints[j].Y - polygonPoints[i].Y) + polygonPoints[i].X))
                {
                    result = !result;
                }
            }
            return result;
        }
    }
}
