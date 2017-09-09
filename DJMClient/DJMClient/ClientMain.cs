using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Repository.Hierarchy;

namespace DJMClient
{
    class ClientMain
    {       
        private static void Main(string[] args)
        {
            #region Logger
            log4net.Config.BasicConfigurator.Configure();
            ILog logger = LogManager.GetLogger(typeof(ClientMain));
            #endregion
           
            Console.WriteLine("Please Enter Server IP (default 127.0.0.1): ");
            String saLine = Console.ReadLine();
            IPAddress serverAddress;
            try
            {
                serverAddress = IPAddress.Parse(saLine);
            }
            catch (Exception e)
            {
                logger.Error($"Error: Invalid Server IP '{e}'");
                throw;
            }

            // Read Port in
            String pLine = Console.ReadLine();
            Int32 port;
            try
            {
                port = Int32.Parse(pLine);
            }
            catch (Exception e)
            {
                logger.Error($"Error: Invalid Port '{e}'");
                throw;
            }
            // TODO allow address and port to pass through if using defaults
            if (serverAddress == null)
            {
                logger.Error("Bad server address");
                return;
            }
            else if (port == null)
            {
                logger.Error($"Bad port");
                return;
            }
            DJMClient client = new DJMClient(serverAddress, port);
            client.Connect();
            Console.ReadLine();
        }
    }
}
