using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnmpSharpNet;
using System.Net;

namespace SNMP_Poller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            string ip = "192.168.1.100";
            //string oid = ".1.3.6.1.4.1.2682.1.4.2.1.5.99.1.10";
            string oid = ".1.3.6.1.4.1.2682.1.4.5";

            Dictionary<String, Dictionary<uint, AsnType>> result = new Dictionary<String, Dictionary<uint, AsnType>>();
            // Not every row has a value for every column so keep track of all columns available in the table
            List<uint> tableColumns = new List<uint>();
            // Prepare agent information
            AgentParameters param = new AgentParameters(SnmpVersion.Ver2, new OctetString("dps_public"));

            IpAddress peer = new IpAddress(ip);
            if (!peer.Valid)
            {
                textBox1.Text += "Unable to resolve name or error in address for peer: " + ip + "\r\n";
                return;
            }
            UdpTarget target = new UdpTarget((IPAddress)peer);
            // This is the table OID supplied on the command line
            Oid startOid = new Oid(oid);
            // Each table OID is followed by .1 for the entry OID. Add it to the table OID
            startOid.Add(1); // Add Entry OID to the end of the table OID
            // Prepare the request PDU
            Pdu bulkPdu = Pdu.GetBulkPdu();
            bulkPdu.VbList.Add(startOid);
            // We don't need any NonRepeaters
            bulkPdu.NonRepeaters = 0;
            // Tune MaxRepetitions to the number best suited to retrive the data
            bulkPdu.MaxRepetitions = 100;
            // Current OID will keep track of the last retrieved OID and be used as 
            //  indication that we have reached end of table
            Oid curOid = (Oid)startOid.Clone();
            // Keep looping through results until end of table
            while (startOid.IsRootOf(curOid))
            {
                SnmpPacket res = null;
                try
                {
                    res = target.Request(bulkPdu, param);
                }
                catch (Exception ex)
                {
                    textBox1.Text += "Request failed: " + ex.Message + "\r\n";
                    target.Close();
                    return;
                }
                // For GetBulk request response has to be version 2
                if (res.Version != SnmpVersion.Ver2)
                {
                    textBox1.Text += "Received wrong SNMP version response packet." + "\r\n";
                    target.Close();
                    return;
                }
                // Check if there is an agent error returned in the reply
                if (res.Pdu.ErrorStatus != 0)
                {
                    textBox1.Text += "SNMP agent returned error " + res.Pdu.ErrorStatus + " for request Vb index " + res.Pdu.ErrorIndex + "\r\n";
                    target.Close();
                    return;
                }
                // Go through the VbList and check all replies
                foreach (Vb v in res.Pdu.VbList)
                {
                    curOid = (Oid)v.Oid.Clone();
                    // VbList could contain items that are past the end of the requested table.
                    // Make sure we are dealing with an OID that is part of the table
                    if (startOid.IsRootOf(v.Oid))
                    {
                        // Get child Id's from the OID (past the table.entry sequence)
                        uint[] childOids = Oid.GetChildIdentifiers(startOid, v.Oid);
                        // Get the value instance and converted it to a dotted decimal
                        //  string to use as key in result dictionary
                        uint[] instance = new uint[childOids.Length - 1];
                        Array.Copy(childOids, 1, instance, 0, childOids.Length - 1);
                        String strInst = InstanceToString(instance);
                        // Column id is the first value past <table oid>.entry in the response OID
                        uint column = childOids[0];
                        if (!tableColumns.Contains(column))
                            tableColumns.Add(column);
                        if (result.ContainsKey(strInst))
                        {
                            result[strInst][column] = (AsnType)v.Value.Clone();
                        }
                        else
                        {
                            result[strInst] = new Dictionary<uint, AsnType>();
                            result[strInst][column] = (AsnType)v.Value.Clone();
                        }
                    }
                    else
                    {
                        // We've reached the end of the table. No point continuing the loop
                        break;
                    }
                }
                // If last received OID is within the table, build next request
                if (startOid.IsRootOf(curOid))
                {
                    bulkPdu.VbList.Clear();
                    bulkPdu.VbList.Add(curOid);
                    bulkPdu.NonRepeaters = 0;
                    bulkPdu.MaxRepetitions = 100;
                }
            }
            target.Close();
            if (result.Count <= 0)
            {
                textBox1.Text += "No results returned.\r\n";
            }
            else
            {
                textBox1.Text += "Instance";
                foreach (uint column in tableColumns)
                {
                    textBox1.Text += "\tColumn id " + column;
                }
                textBox1.Text += "\r\n";
                foreach (KeyValuePair<string, Dictionary<uint, AsnType>> kvp in result)
                {
                    textBox1.Text += kvp.Key;
                    foreach (uint column in tableColumns)
                    {
                        if (kvp.Value.ContainsKey(column))
                        {
                            textBox1.Text += "\t" + kvp.Value[column].ToString() + " ("+  SnmpConstants.GetTypeName(kvp.Value[column].Type) + ")";
                        }
                        else
                        {
                            textBox1.Text += "\t-";
                        }
                    }
                    textBox1.Text += "\r\n";
                }
            }
        }

        public string InstanceToString(uint[] instance)
        {
            StringBuilder str = new StringBuilder();
            foreach (uint v in instance)
            {
                if (str.Length == 0)
                    str.Append(v);
                else
                    str.AppendFormat(".{0}", v);
            }
            return str.ToString();
        }
    }
}



			
	
	