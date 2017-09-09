using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Reflection;
using log4net;
using log4net.Core;
using log4net.Repository.Hierarchy;

namespace DJMClient
{
    class DJMClient : IClient
    {
        #region Logger
        private static Logger logger = new RootLogger(Level.All);
        #endregion
        #region Privates
        private TcpClient TcpClient;
        private IPAddress ServerAddress;
        private int Port;
        #endregion

        #region Constructor
        public DJMClient(string serverAddress = "127.0.0.1", string port = "8080") : this(IPAddress.Parse(serverAddress), Int32.Parse(port))
        {
//            IPAddress ipServerAddress;
//            try
//            {
//                ipServerAddress = IPAddress.Parse(serverAddress);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("Invalid IP");
//                throw;
//            }
        }

        public DJMClient(IPAddress serverAddress, int port)
        {
            ServerAddress = serverAddress;
            Port = port;
        }
        #endregion

        public void Connect()
        {
            TcpClient.Connect(ServerAddress, Port);
        }

        public void Send()
        {
            if (!TcpClient.Connected)
            {
                logger.Log(typeof(DJMClient), Level.Warn, "Error during sending: Cannot connect to server.", new SocketException());
                return;
            }
            throw new NotImplementedException();
        }

        public void Receive()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            TcpClient.Close();
        }
    }
}
