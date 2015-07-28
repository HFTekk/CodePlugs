using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGLogicSim
{
    public partial class Form1 : Form
    {

        ArrayList objectList = new ArrayList();
        ArrayList selectedObjects = new ArrayList();
        Point mousePosition;
        public const int PROX = 30;

        public Form1()
        {
            InitializeComponent();

            // additional handlers:
            dbpMainViewPort.Paint += dbpMainViewPort_Paint;
        }

        void dbpMainViewPort_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(dbpMainViewPort.Width, dbpMainViewPort.Height);
            Graphics g = Graphics.FromImage(bmp);

            foreach (DrawableObject drawObj in this.objectList)
            {
                drawObj.draw(g);
            }

            dbpMainViewPort.CreateGraphics().DrawImage(bmp, 0, 0);
        }

        private void nORToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        void pnlMainViewPort_MouseHover(object sender, System.EventArgs e)
        {
            
        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DrawableObject drawObj in this.selectedObjects)
            {
               
                objectList.Remove(drawObj);
                this.Refresh();
            }
        }

        private void aNDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point p = this.mousePosition;
            objectList.Add(new AndGate(p.X,p.Y));
            this.Refresh();
        }

        private void ctxtMainViewPortContextMenu_Opening(object sender, CancelEventArgs e)
        {
            this.mousePosition = dbpMainViewPort.PointToClient(MousePosition);
        }

        private void dbpMainViewPort_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = dbpMainViewPort.PointToClient(MousePosition);
            this.mousePosition = p;
            int i = 0;
            double minDist = 0.0;

            // Find the closest object within PROX px
            DrawableObject curClosest = null;
            foreach (DrawableObject drawObj in this.objectList)
            {
                
                double dist = drawObj.calcDistance(p);

                if (dist < PROX)
                {
                    if (i++ == 0)
                    {
                        minDist = dist;
                        curClosest = drawObj;
                    }
                    else if (dist < minDist)
                    {
                        minDist = dist;
                        curClosest = drawObj;
                    }
                }

                if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
                {
                    drawObj.unselect();
                    selectedObjects.Remove(drawObj);
                    this.Refresh();
                }

            }

            

            if (curClosest != null)
            {
                curClosest.select();
                if (!selectedObjects.Contains(curClosest)) selectedObjects.Add(curClosest);
                this.Refresh();
                foreach (DrawableObject obj in this.selectedObjects)
                {
                    obj.setDrag(true);
                    
                }
            }
        }

        private void dbpMainViewPort_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (DrawableObject drawObj in this.objectList)
            {
                drawObj.setDrag(false);
            }
        }

        private void dbpMainViewPort_MouseMove(object sender, MouseEventArgs e)
        {
            stsMousePosition.Text = "X: " + e.X + ", Y: " + e.Y;

            Point diff = e.Location - (Size)this.mousePosition;
            this.mousePosition = e.Location;

            /*Point p = dbpMainViewPort.PointToClient(MousePosition);
            this.mousePosition = p;*/
            int i = 0;
            double minDist = 0.0;


            // Find the closest object within PROX px
            DrawableObject curClosest = null;
            foreach (DrawableObject drawObj in this.selectedObjects)
            {
                double dist = drawObj.calcDistance(e.Location);

                if (dist < PROX)
                {
                    if (i++ == 0)
                    {
                        minDist = dist;
                        curClosest = drawObj;
                    }
                    else if (dist < minDist)
                    {
                        minDist = dist;
                        curClosest = drawObj;
                    }
                }

            }

            if (e.Button == MouseButtons.Left && curClosest != null)
            {
                bool refresh = false;
                foreach (DrawableObject drawObj in this.selectedObjects)
                {
                    if (drawObj.isDragging())
                    {
                        Point newP = new Point(drawObj.p1.X + diff.X, drawObj.p1.Y + diff.Y);
                        drawObj.p1 = newP;
                        refresh = true;
                    }
                }
                if (refresh) this.Refresh();
            }
        }

        private void dbpMainViewPort_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
