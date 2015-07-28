using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitCounting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int bitCount(byte[] data)
        {
            int c = 0;

            foreach (byte b in data)
            {
                for (int i = 0; i < 8; i++)
                {
                    if ((b & (1 << i)) > 0) c++;
                }
            }

            return c;
        }


        private void btnGo_Click(object sender, EventArgs e)
        {
            int data = int.Parse(txtInput.Text);
            byte[] output = BitConverter.GetBytes(data);
            MessageBox.Show(bitCount(output).ToString() + "\r\nsizeof(int)=" + sizeof(int));
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            //int pattern = int.Parse(txtPattern.Text,IFormatProvider

            int pattern = Convert.ToInt32(txtPattern.Text, 16);
            int data = Convert.ToInt32(txtData.Text, 16);

            int xor = pattern ^ data;

            byte[] bytes = BitConverter.GetBytes(xor);
            MessageBox.Show(bitCount(bytes).ToString());
        }

    }
}
