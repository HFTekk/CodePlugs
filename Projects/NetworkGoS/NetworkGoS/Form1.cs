using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkGoS
{
    public partial class Form1 : Form
    {

        private double GoS = 0.010;

        public Form1()
        {
            InitializeComponent();
            tmr_updateGoS.Interval = 1000;
            tmr_updateGoS.Tick += tmr_updateGoS_Tick;
            tmr_updateGoS.Start();
        }

        void tmr_updateGoS_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            double num = rnd.Next(-2, 2) * 0.001;
            lbl_test.Text = num.ToString();
            GoS = Math.Abs(GoS + num);

            lbl_GoS.Text = GoS.ToString("N3");
            //SystemSounds.Beep.Play();
            SystemSounds.Hand.Play();

        }
    }
}
