using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace SocketProgramming
{
    /// <summary>
    /// crate ServerDemo1 class
    /// </summary>
    class ServerDemo1
    {
        /// <summary>
        /// craete log
        /// </summary>
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// create main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            TcpListener listen = new TcpListener(IPAddress.Parse("192.168.1.40"),8888);
            log.Info("---connecting---");
            listen.Start();
            TcpClient client = listen.AcceptTcpClient();
            log.Info("client connected");
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];
            int data = stream.Read(buffer, 0, client.ReceiveBufferSize);
            string ch = Encoding.Unicode.GetString(buffer, 0, data);
            log.Info("message received:" + ch);
            client.Close();
            Console.ReadKey();
        }
    }
}
