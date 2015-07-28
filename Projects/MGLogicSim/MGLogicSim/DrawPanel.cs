using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace MGLogicSim
{
    public partial class DrawPanel : Panel
    {

        public ArrayList objectList = new ArrayList();

        public DrawPanel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // add stuff here
            foreach (DrawableObject obj in objectList)
            {
                obj.draw(e.Graphics);
            }

        }
    }
}
