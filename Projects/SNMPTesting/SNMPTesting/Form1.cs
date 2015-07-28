using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections;

namespace SNMPTesting
{
    public partial class Form1 : Form
    {
        SNMPMessage snmpMessage = new SNMPMessage();

        Socket newSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        public delegate void ReceiveDataDelegate(byte[] data);

        ReceiveDataDelegate rxDataDel;

        public Form1()
        {

            InitializeComponent();


            startListening();
        }

        void startListening()
        {

            byte[] data = new byte[1024];

            try
            {
                this.rxDataDel = new ReceiveDataDelegate(processData);

                IPEndPoint snmpRxEndpoint = new IPEndPoint(IPAddress.Any, 161);

                newSocket.Bind(snmpRxEndpoint);

                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint tmpRemote = (EndPoint)sender;

                newSocket.BeginReceiveFrom(data, 0, 1024, SocketFlags.None, ref tmpRemote, new AsyncCallback(ReceiveData), tmpRemote);

                int i = 0;
                i++;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void ReceiveData(IAsyncResult asyncResult)
        {
            try
            {
                byte[] data = new byte[1024];

                // Initialise the IPEndPoint for the clients
                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

                // Initialise the EndPoint for the clients
                EndPoint epSender = (EndPoint)sender;

                // Receive all data
                newSocket.EndReceiveFrom(asyncResult, ref epSender);

                // Listen for more connections again...
                newSocket.BeginReceiveFrom(data, 0, 1024, SocketFlags.None, ref epSender, new AsyncCallback(this.ReceiveData), epSender);

                // Update status through a delegate
                this.Invoke(this.rxDataDel, new object[] { data });
            }
            catch (Exception ex)
            {
                MessageBox.Show("ReceiveData Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void processData(byte[] data)
        {
            //txtConsole.Text += "Message received...\r\n";
            //txtConsole.Text += ASCIIEncoding.ASCII.GetString(data) + "\r\n";

            this.snmpMessage = new SNMPMessage();

            Queue<byte> dataQueue = new Queue<byte>(data);
            data = new byte[1024];
            if (!SNMPMessage.isQueueEmpty(dataQueue))
            {
                this.snmpMessage.parseMessage(dataQueue);

                //txtConsole.Text += "\tDataType: " + snmpMessage.dataType.ToString() + "\r\n";
                //txtConsole.Text += "\t" + snmpMessage.snmpCommString.value + " | " + snmpMessage.snmpPdu.pduType.ToString() + "\r\n";

                switch (this.snmpMessage.snmpPdu.pduType)
                {
                    case PDU_TYPE.GET_REQUEST:
                        txtConsole.AppendText("GET_REQUEST Received:\r\n");
                        txtConsole.AppendText("\tReq ID: " + this.snmpMessage.snmpPdu.requestID.value + "\r\n");
                        txtConsole.AppendText("\tCommunity String: " + this.snmpMessage.snmpCommString.value + "\r\n");
                        foreach (SNMPVariableBinding bind in snmpMessage.snmpPdu.varBindList)
                        {
                            
                            txtConsole.AppendText("\tOID: " + bind.oid.oid + "\r\n");
                        }
                        txtConsole.AppendText("\r\n");
                        
                        break;

                    default:
                        txtConsole.AppendText("UNKNOWN PDU TYPE\r\n");
                        break;

                }
            }
            else
            {
                txtConsole.AppendText("\r\n******EMPTY PACKET RECEIVED********\r\n\r\n");
            }
        }


    }

    

    #region SNMPMessageClasses

    public enum SNMP_DATA_TYPE { BOOLEAN = 1, INTEGER = 2, BIT_STRING = 3, OCTET_STR = 4, NULL = 5, SEQUENCE = 48, OID = 6 }
    public enum PDU_TYPE { GET_REQUEST = 160, GET_NEXT_REQUEST = 161, GET_RESPONSE = 162, SET_REQUEST = 163, TRAP = 164, GET_BULK_REQUEST = 165, INFORM = 166, V2TRAP = 167, REPORT = 168 }

    public class SNMPMessage
    {
        public SNMP_DATA_TYPE dataType = SNMP_DATA_TYPE.SEQUENCE;
        public int length;

        public SNMPVersion snmpVersion = new SNMPVersion();
        public SNMPCommunityString snmpCommString = new SNMPCommunityString();
        public SNMP_PDU snmpPdu = new SNMP_PDU();

        public void parseMessage(Queue<byte> data)
        {
            data.Dequeue(); // type
            this.length = data.Dequeue();
            this.snmpVersion.parseVersion(data);
            this.snmpCommString.parseCommunityString(data);
            this.snmpPdu.parsePdu(data);
        }

        public static bool isQueueEmpty(Queue<byte> data)
        {
            foreach (byte b in data)
            {
                if (b != 0) return false;
            }

            return true;
        }
    }

    public class SNMPVersion
    {
        public SNMP_DATA_TYPE dataType = SNMP_DATA_TYPE.INTEGER;
        public int length;
        public int value;

        public void parseVersion(Queue<byte> data)
        {
            data.Dequeue(); // type
            this.length = data.Dequeue();
            this.value = data.Dequeue();
        }

    }

    public class SNMPCommunityString
    {
        public SNMP_DATA_TYPE dataType = SNMP_DATA_TYPE.OCTET_STR;
        public int length;
        public string value;

        public void parseCommunityString(Queue<byte> data)
        {
            data.Dequeue();
            this.length = data.Dequeue();

            for (int i = 0; i < this.length; i++)
            {
                this.value += Convert.ToChar(data.Dequeue());
            }

        }

    }


    public class SNMP_PDU
    {
        public PDU_TYPE pduType;
        public int length;
        public SNMPRequestID requestID = new SNMPRequestID();
        public SNMPErrorStatus errorStatus = new SNMPErrorStatus();
        public SNMPErrorIndex errorIndex = new SNMPErrorIndex();
        public SNMPVariableBindingList varBindList = new SNMPVariableBindingList();

        public void parsePdu(Queue<byte> data)
        {
            this.pduType = (PDU_TYPE)data.Dequeue();
            this.length = data.Dequeue();

            this.requestID.parseRequestID(data);
            this.errorStatus.parseErrorStatus(data);
            this.errorIndex.parseErrorIndex(data);
            this.varBindList.parseVarBindList(data);
        }
    }

    #region SNMP_PDUClasses

    public class SNMPRequestID
    {
        public SNMP_DATA_TYPE dataType = SNMP_DATA_TYPE.INTEGER;
        public int length;
        public int value;

        public void parseRequestID(Queue<byte> data)
        {
            data.Dequeue();
            this.length = data.Dequeue();
            this.value = data.Dequeue();
        }
    }

    public class SNMPErrorStatus
    {
        public SNMP_DATA_TYPE dataType = SNMP_DATA_TYPE.INTEGER;
        public int length;
        public int value;

        public void parseErrorStatus(Queue<byte> data)
        {
            data.Dequeue();
            this.length = data.Dequeue();
            this.value = data.Dequeue();
        }
    }

    public class SNMPErrorIndex
    {
        public SNMP_DATA_TYPE dataType = SNMP_DATA_TYPE.INTEGER;
        public int length;
        public int value;

        public void parseErrorIndex(Queue<byte> data)
        {
            data.Dequeue();
            this.length = data.Dequeue();
            this.value = data.Dequeue();
        }
    }

    public class SNMPVariableBindingList : ArrayList
    {
        public SNMP_DATA_TYPE dataType = SNMP_DATA_TYPE.SEQUENCE;
        public int length;

        public override int Add(object value)
        {
            if (value.GetType() == typeof(SNMPVariableBinding))
                return base.Add(value);
            else
            {
                return 0;
            }
        }

        internal void parseVarBindList(Queue<byte> data)
        {
            data.Dequeue(); // type
            this.length = data.Dequeue();
            
            while (!SNMPMessage.isQueueEmpty(data))
            {
                SNMPVariableBinding newVarBind = new SNMPVariableBinding();
                newVarBind.parseVariableBinding(data);
                this.Add(newVarBind);
            }

        }
    }

    

    public class SNMPVariableBinding
    {
        public SNMP_DATA_TYPE dataType = SNMP_DATA_TYPE.SEQUENCE;
        public int length;
        public SNMPVarBindOID oid = new SNMPVarBindOID();
        public SNMPVarBindValue value = new SNMPVarBindValue();

        internal void parseVariableBinding(Queue<byte> data)
        {
            data.Dequeue(); // type
            this.length = data.Dequeue();

            this.oid.parseVarBindOid(data);
            this.value.parseVarBindValue(data);
        }
    }

    #region VariableBinding classes

    public class SNMPVarBindOID
    {
        public SNMP_DATA_TYPE dataType = SNMP_DATA_TYPE.OID;
        public int length;
        public string oid;

        internal void parseVarBindOid(Queue<byte> data)
        {
            bool readingMultiByteValue = false;
            this.oid = "";
            ArrayList multiByte = new ArrayList();
            int multiByteValue = 0;

            if (data.Count > 0)
            {
                data.Dequeue(); // type
                this.length = data.Dequeue();
                
                for (int i = 0; i < this.length; i++)
                {
                    byte b = data.Dequeue();
                    if ((i == 0) && (b == 0x2b)) // if the first byte == 0x2b then add "1.3" to the OID string
                    {
                        this.oid += "1.3";
                    }
                    else
                    {
                        
                        if (((b & 0x80) == 0x00) && !readingMultiByteValue) // if the first bit is 0 and we are not reading a multibyte value, convert the byte to a string representation of an integer, and add it to the OID String
                        {
                            
                            this.oid += "." + b.ToString();
                            
                        }
                        else // first bit is 1, means a multiple byte number
                        {
                            multiByte.Add(b);
                            readingMultiByteValue = true;
                            if ((b & 0x80) == 0x00) // if the first bit is 0, we are done with the multibyte value
                            {
                                readingMultiByteValue = false;
                                for (int j = multiByte.Count - 1; j >= 0; j--)
                                {
                                    if (((byte)multiByte[j] & 0x80) == 0x00) // this is the LSB, add it to the value integer
                                    {
                                        multiByteValue += (byte) multiByte[j];
                                    }
                                    else
                                    {
                                        int working = (byte)multiByte[j] & 0x7f; // mask the first bit
                                        working <<= (7 * (multiByte.Count - 1 - j)); // shift the value to align the bits
                                        multiByteValue += working;
                                    }
                                }
                                // add the multiByteValue to the OID string
                                this.oid += "." + multiByteValue;
                                multiByteValue = 0;
                            }
                        }
                    }

                }
            }
        }
    }

    public class SNMPVarBindValue
    {
        public SNMP_DATA_TYPE dataType = SNMP_DATA_TYPE.NULL;
        public int length;
        public object value = null;
        internal void parseVarBindValue(Queue<byte> data)
        {
            this.length = data.Dequeue();

        }
    }

    #endregion

    #endregion

    #endregion


}
