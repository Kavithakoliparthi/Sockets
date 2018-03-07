using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace ConsoleApplication2
{
    /// <summary>
    /// create single client request 
    /// </summary>
    class ClientDemo1
    {
        /// <summary>
        /// create log
        /// </summary>
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// create main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("192.168.1.40", 8888);
            log.Info("try to connect to server");
            NetworkStream n = client.GetStream();
            log.Info("[connected]");
            string ch = Console.ReadLine();
            byte[] message = Encoding.Unicode.GetBytes(ch);
            n.Write(message, 0, message.Length);
            log.Info("-----------------sent------------");
            client.Close();
            Console.ReadKey();
        }
    }
}
