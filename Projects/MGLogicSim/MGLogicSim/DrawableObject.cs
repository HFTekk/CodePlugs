using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGLogicSim
{
    
    public abstract class DrawableObject
    {
        public abstract void draw(Graphics g);
        public abstract double calcDistance(Point p);
        public abstract void select();
        public abstract void unselect();
        public abstract bool isSelected();
        public abstract bool isDragging();
        public abstract void setDrag(bool drag);
        public abstract bool checkHover(Point p);

        public abstract Point p1
        { get; set; }
    }

    public class Line : DrawableObject
    {
        //public Point p1 = new Point(0, 0);
        public Point p2 = new Point(0, 0);

        public Pen defaultPen = new Pen(Color.Black, 1.0f);
        public Pen selectedPen = new Pen(Color.Red, 2.0f);
        private bool drag = false;
        private Point _p1;

        public override Point p1
        {
            get
            {
                return _p1;
            }

            set
            {
                _p1 = value;
            }
        }

        public override bool isDragging()
        {
            return drag;
        }

        public override void setDrag(bool drag)
        {
            this.drag = drag;
        }

        private ArrayList distanceCalcPoints = new ArrayList();

        private bool selected = false;

        public Line()
        {

        }

        public Line(int x1, int y1, int x2, int y2)
        {
            this.p1 = new Point(x1, y1);
            this.p2 = new Point(x2, y2);

            setDistanceCalcPoints(50);
        }

        private void setDistanceCalcPoints(int numPoints)
        {
            //float m = (this.p2.Y - this.p1.Y) / (this.p2.X - this.p1.X);

            double xStep = (this.p2.X - this.p1.X) / (numPoints - 1.0d);
            double yStep = (this.p2.Y - this.p1.Y) / (numPoints - 1.0d);

            for (int i = 0; i < numPoints; i++)
            {
                this.distanceCalcPoints.Add(new Point((int)(this.p1.X + xStep * i), (int)(this.p1.Y + yStep * i)));
            }

        }

        public override void draw(Graphics g)
        {
            Pen pen = this.selected ? this.selectedPen : this.defaultPen;
            g.DrawLine(pen, p1, p2);
        }

        public override void select()
        {
            this.selected = true;
        }

        public override void unselect()
        {
            this.selected = false;
        }

        public override bool isSelected()
        {
            return this.selected;
        }

        private double dist(Point p1, Point p2)
        {
            float dx = (p2.X - p1.X);
            float dy = (p2.Y - p1.Y);

            return Math.Abs(Math.Sqrt(dx * dx + dy * dy));
        }

        public override double calcDistance(Point p)
        {
            double distance = 0;
            int i = 0;

            foreach (Point pt in distanceCalcPoints)
            {
                double lDist = dist(p, pt);

                if (i++ == 0)
                {
                    distance = lDist;
                }

                else if (lDist < distance)
                {
                    distance = lDist;
                }
            }

            return distance;
        }

        public override bool checkHover(Point p)
        {
            return (dist(p, p1) < 10 || dist(p, p2) < 10);
        }
    }


    public class AndGate : DrawableObject
    {
        private int gateSizeX = 107;
        private int gateSizeY = 75;
        private Point _p1;

        public override Point p1
        {
            get
            {
                return _p1;
            }

            set
            {
                _p1 = value;
            }
        }
        
        public Pen defaultPen = new Pen(Color.Black, 2.0f);
        public Pen selectedPen = new Pen(Color.Red, 2.5f);

        private bool selected = false;
        private bool dragging = false;

        public AndGate()
        {

        }

        public AndGate(int x, int y)
        {
            p1 = new Point(x, y);
        }

        public override void draw(Graphics g)
        {
            // create pens and brushes
            Pen pen = this.selected ? this.selectedPen : this.defaultPen;
            SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Beige);
            Pen narrPen = new Pen(Color.Black, 1.0f);
            
            // Create rectangle to bound ellipse.
            Rectangle rect = new Rectangle(p1.X + 32, p1.Y, 75, 75);
            
            // Draw the Fill Areas
            g.FillRectangle(myBrush, p1.X, p1.Y, 75, 75);
            g.FillEllipse(myBrush, rect);
            
            // Define the points that make the "box"
            Point[] points = { new Point(p1.X + 75, p1.Y + 75), 
                               new Point(p1.X, p1.Y + 75),  
                               new Point(p1.X, p1.Y), 
                               new Point(p1.X + 75, p1.Y) 
                             };

            //Draw the "box"
            g.DrawLines(pen, points);

            // Create start and sweep angles on ellipse. 
            float startAngle = 270.0F; // north
            float sweepAngle = 180.0F;

            // Draw arc
            g.DrawArc(pen, rect, startAngle, sweepAngle);
            

        }

        public override void select()
        {
            this.selected = true;
        }

        public override void unselect()
        {
            this.selected = false;
        }

        public override bool isSelected()
        {
            return this.selected;
        }

        public override bool isDragging()
        {
            return dragging;
        }

        public override void setDrag(bool drag)
        {
            this.dragging = drag;
        }

        public override double calcDistance(Point p)
        {
            double dist;

            Point c = new Point(p1.X + gateSizeX / 2, p1.Y + gateSizeY / 2);

            if ((p.X > p1.X && p.X < p1.X + gateSizeX) && (p.Y > p1.Y && p.Y < p1.Y + gateSizeY))
            {
                dist = 0.0;
            }
            else
            {
                double dx = p.X - p1.X;
                double dy = p.Y - p1.Y;

                dist = Math.Abs(Math.Sqrt(dx * dx + dy * dy));
            }

            return dist;
        }

        public override bool checkHover(Point p)
        {
            return (calcDistance(p) == 0.0);
        }
    }
}
