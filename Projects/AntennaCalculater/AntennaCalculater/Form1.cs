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
using System.Xml;

namespace AntennaCalculator
{
    public partial class Form1 : Form
    {
        //DataSet txlines = new DataSet();
        ArrayList txlines = new ArrayList();

        public Form1()
        {
            InitializeComponent();
            rbERP.Checked = true;
            
            //txlines.ReadXml(@"C:\Users\e.Eng.001\Google Drive\Projects\AntennaCalculater\AntennaCalculater\txlines.xml");

            TxLine currTxLine = new TxLine();
            Curve currCurve = new Curve();

            using (XmlReader reader = XmlReader.Create(@"C:\Users\e.Eng.001\Google Drive\Projects\AntennaCalculater\AntennaCalculater\txlines.xml"))
            {

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:

                            if (reader.Name == "txline") 
                            {
                                
                                currTxLine = new TxLine();

                                string name = "";
                                int maxFreq = 0;

                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name == "name") { name = reader.Value; }
                                    else if (reader.Name == "maxfreq") { maxFreq = int.Parse(reader.Value); }
                                    
                                }

                                currTxLine.Name = name;
                                currTxLine.MaxFrequency = maxFreq;
                                txlines.Add(currTxLine);
                            }

                            else if (reader.Name == "curve")
                            {
                                currCurve = new Curve();

                                int lowf = 0;
                                int highf = 0;
                                CurveType type = new CurveType();
                                double[] coeffs = {0.0, 0.0, 0.0, 0.0};

                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name == "lowf") { lowf = int.Parse(reader.Value); }
                                    else if (reader.Name == "highf") 
                                    {
                                        if (reader.Value == "max") { highf = currTxLine.MaxFrequency; }
                                        else { highf = int.Parse(reader.Value); }
                                    }
                                    else if (reader.Name == "type") { type = (CurveType) Enum.Parse(typeof(CurveType), reader.Value); }
                                    else if (reader.Name == "a") { coeffs[0] = double.Parse(reader.Value); }
                                    else if (reader.Name == "b") { coeffs[1] = double.Parse(reader.Value); }
                                    else if (reader.Name == "c") { coeffs[2] = double.Parse(reader.Value); }
                                    else if (reader.Name == "p") { coeffs[3] = double.Parse(reader.Value); }

                                    
                                }
                                currCurve = new Curve();
                                currCurve.Lowf = lowf;
                                currCurve.Highf = highf;
                                currCurve.type = type;

                                currCurve.SetA(coeffs[0]);
                                currCurve.SetB(coeffs[1]);
                                currCurve.SetC(coeffs[2]);
                                currCurve.SetP(coeffs[3]);
                                currTxLine.addCurve(currCurve);

                            }


                            //txtSchema.Text += reader.Name + " attributes: " + reader.AttributeCount + "\r\n";
                           
                            break;
                        
                    }

                }
               

            }

            cbLineType.Items.Add("");
            foreach (TxLine line in this.txlines)
            {
                cbLineType.Items.Add(line);
            }
        }

        private void rbCombinerIL_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCombinerIL.Checked)
            {
                foreach (object obj in this.gbStraightCalc.Controls)
                {
                    if (obj.GetType() == typeof(TextBox))
                    {
                        ((TextBox)obj).Enabled = true;
                    }
                }
                txtCombinerIL.Enabled = false;
            }
        }

        private void rbPolyphaserIL_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPolyphaserIL.Checked)
            {
                foreach (object obj in this.gbStraightCalc.Controls)
                {
                    if (obj.GetType() == typeof(TextBox))
                    {
                        ((TextBox)obj).Enabled = true;
                    }
                }
                txtPolyphaserIL.Enabled = false;
            }
        }

        private void rbLineLoss_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLineLoss.Checked)
            {
                foreach (object obj in this.gbStraightCalc.Controls)
                {
                    if (obj.GetType() == typeof(TextBox))
                    {
                        ((TextBox)obj).Enabled = true;
                    }
                }
                txtLineLoss.Enabled = false;
            }
        }

        private void rbLineLength_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLineLength.Checked)
            {
                foreach (object obj in this.gbStraightCalc.Controls)
                {
                    if (obj.GetType() == typeof(TextBox))
                    {
                        ((TextBox)obj).Enabled = true;
                    }
                }
                txtLineLength.Enabled = false;
            }
        }

        private void rbAntennaGain_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAntennaGain.Checked)
            {
                foreach (object obj in this.gbStraightCalc.Controls)
                {
                    if (obj.GetType() == typeof(TextBox))
                    {
                        ((TextBox)obj).Enabled = true;
                    }
                }

                txtAntennaGain.Enabled = false;
            }
        }

        private void rbERP_CheckedChanged(object sender, EventArgs e)
        {
            if (rbERP.Checked)
            {
                foreach (object obj in this.gbStraightCalc.Controls)
                {
                    if (obj.GetType() == typeof(TextBox))
                    {
                        ((TextBox)obj).Enabled = true;
                    }
                }
                txtERP.Enabled = false;
            }
        }

        private void rbTXPower_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTXPower.Checked)
            {
                foreach (object obj in this.gbStraightCalc.Controls)
                {
                    if (obj.GetType() == typeof(TextBox))
                    {
                        ((TextBox)obj).Enabled = true;
                    }
                }
                txtTXPower.Enabled = false;
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbLineType.SelectedItem != null && cbLineType.SelectedItem != "")
                {
                    TxLine line = (TxLine)cbLineType.SelectedItem;
                    txtLineLoss.ReadOnly = true;
                    int freq = int.Parse(txtFrequency.Text);
                    txtLineLoss.Text = line.calcLoss(freq).ToString();
                }

                if (rbERP.Checked)
                {
                    FloatError res = calcERP();
                    if (res.Success)
                    {
                        txtERP.Text = res.Value.ToString();
                    }
                    else
                    {
                        txtERP.Text = "Invalid";
                    }
                }
                else if (rbTXPower.Checked)
                {
                    FloatError res = calcTXPower();
                    if (res.Success)
                    {
                        txtTXPower.Text = res.Value.ToString();
                    }
                    else
                    {
                        txtTXPower.Text = "Invalid";
                    }

                }
                else if (rbAntennaGain.Checked)
                {
                    

                    FloatError res = calcAntGain();
                    if (res.Success)
                    {
                        txtAntennaGain.Text = res.Value.ToString();
                    }
                    else
                    {
                        txtAntennaGain.Text = "Invalid";
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private FloatError calcAntGain()
        {
            FloatError result = new FloatError();
            try
            {

                float combIL = float.Parse(txtCombinerIL.Text);
                float polyIL = float.Parse(txtPolyphaserIL.Text);
                float lineLoss = float.Parse(txtLineLength.Text) * float.Parse(txtLineLoss.Text) / 100;
                float erp_dBW = float.Parse(txtERP.Text);
                float tx_P = float.Parse(txtTXPower.Text);
                float systemLoss = combIL + polyIL + lineLoss;
                float erp_W = (float)Math.Pow(10, erp_dBW / 10);

                float antGain = (float)(10 * Math.Log10(erp_W / tx_P) + systemLoss);

                result.Value = antGain;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
            }
            return result;
        }

        private FloatError calcTXPower()
        {
            FloatError result = new FloatError();
            try
            {

                float antGain = float.Parse(txtAntennaGain.Text);
                float combIL = float.Parse(txtCombinerIL.Text);
                float polyIL = float.Parse(txtPolyphaserIL.Text);
                float lineLoss = float.Parse(txtLineLength.Text) * float.Parse(txtLineLoss.Text) / 100;
                float erp_dBW = float.Parse(txtERP.Text);
                float systemGain = antGain - combIL - polyIL - lineLoss;

                float erp_W = (float)Math.Pow(10, erp_dBW / 10);

                float tx_P = (float)(erp_W / Math.Pow(10, systemGain / 10));

                result.Value = tx_P;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
            }
            return result;

        }

        private FloatError calcERP()
        {
            FloatError result = new FloatError();
            try
            {
                float antGain = float.Parse(txtAntennaGain.Text);
                float combIL = float.Parse(txtCombinerIL.Text);
                float polyIL = float.Parse(txtPolyphaserIL.Text);
                float lineLoss = float.Parse(txtLineLength.Text) * float.Parse(txtLineLoss.Text) / 100;

                float systemGain = antGain - combIL - polyIL - lineLoss;

                float tx_P = float.Parse(txtTXPower.Text);

                float erp_W = (float)(tx_P * Math.Pow(10, (systemGain / 10)));

                float erp_dBW = (float)(10 * Math.Log10(erp_W));

                result.Value = erp_dBW;
                result.Success = true;

            }
            catch (Exception ex)
            {
                result.Success = false;
            }
            return result;
        }

        private void cbLineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLineType.SelectedItem != "")
            {
                TxLine line = (TxLine)cbLineType.SelectedItem;
                txtLineLoss.ReadOnly = true;
                int freq;

                try { freq = int.Parse(txtFrequency.Text); }
                catch (Exception ex) 
                { 
                    freq = line.MaxFrequency / 2;
                    txtFrequency.Text = freq.ToString();
                }
               
                txtLineLoss.Text = line.calcLoss(freq).ToString();
            }
        }

        private void txtFrequency_TextChanged(object sender, EventArgs e)
        {   
            int freq = 0;
            
            if (cbLineType.SelectedItem != null && cbLineType.SelectedItem != "")
            {
                TxLine line = (TxLine)cbLineType.SelectedItem;
                txtLineLoss.ReadOnly = true;
                

                try { freq = int.Parse(txtFrequency.Text); }
                catch (Exception ex)
                {
                   
                }

                txtLineLoss.Text = line.calcLoss(freq).ToString();
            }
        }

        private void txtBoxes_TextChanged(object sender, EventArgs e)
        {
            btnCalc_Click(this, new EventArgs());
        }

        
    }

    class FloatError
    {
        public bool Success { get; set; }
        public float Value { get; set; }
    }
}
