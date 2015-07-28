using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KWVirtualRadio
{
    public partial class Form1 : Form
    {

        delegate void OutputUpdateDelegate(string data);

        public Form1()
        {
            InitializeComponent();
            sp_radio1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceivedHandler);
            sp_radio1.Open();
        }

        
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            UpdateTextBox(sp.ReadExisting());

        }

        public void UpdateTextBox(string data)
        {
            if (txt_output.InvokeRequired)
                txt_output.Invoke(new OutputUpdateDelegate(OutputUpdateCallback),
                new object[] { data });
            else
                OutputUpdateCallback(data); //call directly
        }

        private void OutputUpdateCallback(string data)
        {
            txt_output.Text += data;
            if ((char)data[data.Length-1] == 0x03 ) txt_output.Text += "\r\n";

        }

    }
}
