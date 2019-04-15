using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

namespace CaroGame
{

    
    class SocketConection
    {
        #region Variable
        public string IP = "192.168.1.4";
        public int PORT = 9999;
        public Socket client, server;
        private const int BUFFER = 1024;
        #endregion

        #region client
        public bool conectServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), PORT);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
            try
            {
                client.Connect(iep);
            }catch
            {

                return false;
            }
            return true;
        }
        #endregion

        #region Server
        public void createServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP),PORT);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(iep);
            server.Listen(10);
            Thread threadAcceptClient = new Thread(() => { acceptClient(); });
            threadAcceptClient.IsBackground = true;
            threadAcceptClient.Start();
        }
        #endregion

        private void acceptClient()
        {
            server.Accept();
        }

        #region GetIp
        public string getLocalIpV4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
        #endregion

        #region send and receive
        public bool send(object o)
        {
            byte[] arrData = SerializeData(o);
            return sendData(client, arrData);
        }

        private bool sendData(Socket tagret, byte[] arrByte)
        {
            return tagret.Send(arrByte) == 1 ? true : false;
        }

        private bool receiveData(Socket tagret, byte[] arrByte)
        {
            return tagret.Receive(arrByte) == 1 ? true : false;
        }
        #endregion

        public object receive()
        {
            byte[] byteData = new byte[BUFFER];
            bool isRec = receiveData(client,byteData);
            return DeserializeData(byteData);
        }
        #region Convert_Object_To_Byte_Array
        private byte[] SerializeData(Object o)
        {
           MemoryStream ms = new MemoryStream();
           BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
            
        }
        #endregion

        #region Byte To Object
        private Object DeserializeData(byte[] arrByte)
        {
            MemoryStream ms = new MemoryStream(arrByte);
            BinaryFormatter bf = new BinaryFormatter();
            ms.Position = 0;
            return bf.Deserialize(ms);
        }
        #endregion 


    }
}
