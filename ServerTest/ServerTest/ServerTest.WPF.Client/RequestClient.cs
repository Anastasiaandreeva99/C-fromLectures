using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerTest.WPF.Client
{
    public static class RequestClient
    {
        public static string SendRequest(string fileName)
        {
            byte[] bytes = new byte[1024];

            try
            {
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, 11000);

                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                sender.Connect(remoteEndPoint);

                byte[] msg = Encoding.ASCII.GetBytes("request");

                int bytesSent = sender.Send(msg);

                Thread.Sleep(3000);

                msg = Encoding.ASCII.GetBytes(fileName);

                bytesSent = sender.Send(msg);

                int bytesRec = sender.Receive(bytes);
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();

                return Encoding.ASCII.GetString(bytes, 0, bytesRec);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
        }
    }
}
