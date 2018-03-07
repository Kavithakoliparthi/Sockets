using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace SocketProgramming
{
    /// <summary>
    /// craete ClientDemo class 
    /// </summary>
    class ClientDemo
    {
        /// <summary>
        /// create log4net
        /// </summary>
        static readonly log4net.ILog log =log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// create main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Execute();
            Console.ReadLine();
        }
        /// <summary>
        /// create Execute method
        /// </summary>
        public static void Execute()
        { 
            //if any error occur go to catch block
            try
            {
                TcpClient clnt = new TcpClient();
//TcpClient class inherits from IDisposable
                log.Info("-----connecting---");
                clnt.Connect("192.168.1.40", 8888);
                log.Info("connected");
                log.Info("enter the one string to be transmitted:");
                string str = Console.ReadLine();
                Stream s = clnt.GetStream();
//GetStream is a method in TcpClient.
                ASCIIEncoding asen = new ASCIIEncoding();
//ASCIIEncoding is a clss inherits from Encoding
                byte[] b = asen.GetBytes(str);
                log.Info("-----transmitting-----");
                s.Write(b, 0, b.Length);
                byte[] bb = new byte[100];
                int k = s.Read(bb, 0, 100);
                for (int i = 0; i < k; i++)
                {
                    log.Info(Convert.ToChar(bb[i]));
                }
                Console.ReadKey();
                clnt.Close();
            }
            catch (Exception ex)
            {
                log.Info("Error----" + ex.StackTrace);
            }
        }
    }
}

