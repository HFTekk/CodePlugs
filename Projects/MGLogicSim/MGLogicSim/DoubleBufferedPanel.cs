using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGLogicSim
{
    

        public partial class DoubleBufferedPanel : Panel
        {
            [DefaultValue(true)]
            public new bool DoubleBuffered
            {
                get
                {
                    return base.DoubleBuffered;
                }
                set
                {
                    base.DoubleBuffered = value;
                }
            }
        }
    
}
