using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace SocketProgramming
{
    /// <summary>
    /// create ServerDemo class
    /// </summary>
    class ServerDemo
    {
        /// <summary>
        /// create log4net
        /// </summary>
        static readonly log4net.ILog log =log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// create main method
        /// It is the starting point of program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Process();
            Console.ReadLine();
        }
        /// <summary>
        /// craeting process()
        /// </summary>
        public static void Process()
        { 
            //if any error occur go to catch block
            try
            {
                IPAddress add = IPAddress.Parse("192.168.1.40");
                    //Initialize the listener
                TcpListener list = new TcpListener(add, 8888);
           
                    //start listening at the specified port
                list.Start();
                log.Info("The server is running at port 8888");
                log.Info("The local End point is:" + list.LocalEndpoint);
   //public EndPoint LocalEndpoint  -->gets the current endpoint of TcpListener
                log.Info("waiting for connection");
                //accepts the connection
                Socket s = list.AcceptSocket();
                //TcpListener class method AcceptSocket()
//public Socket AcceptSocket--> Accepts pending client connection and return socket for communication
                log.Info("connection accepted from" + s.RemoteEndPoint);
//RemoteEndPoint, Receive methods are in Socket class inherts from IDisposable
                //get the date
                byte[] b = new byte[100];
                int k = s.Receive(b);
                log.Info("message received");
                for(int i=0;i<k;i++)
                {
                    log.Info(Convert.ToChar(b[i]));
                }
                //send the reply
                ASCIIEncoding asen = new ASCIIEncoding();
//AsciiEncoding is a class inherits from Encoding. it initializes a new instance of ASCIIEncoding
                s.Send(asen.GetBytes("the string was received by the server"));
//Socket is a class in that send() -->send data to the connected socket
//Encoding is a class inherits from ICloneable in that
//GetBytes()-->overriden in a derived class encodes all characters inthe specified string into sequence of bytes.
                log.Info("sent acknowledgement");
                Console.ReadLine();
                s.Close();
                list.Stop();
            }
            catch(Exception e)
            {
                log.Info("error:"+e.StackTrace); 
            }
        }
    }
}
