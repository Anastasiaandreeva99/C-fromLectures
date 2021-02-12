using ServerTest.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerTest.Server
{
    class Program
    {
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public static void StartListening()
        { 
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);
            
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);
  
                while (true)
                {
                    allDone.Reset();

                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    allDone.WaitOne();

                    Console.WriteLine("aaaaaa");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void AcceptCallback(IAsyncResult ar)
        { 
            allDone.Set();  
            Socket listener = (Socket)ar.AsyncState;
            Socket socket = listener.EndAccept(ar);

            string data = socket.ReceiveText();
            if (data == "request")
            {
                string fileName = socket.ReceiveText();
                if (File.Exists(fileName))
                {
                    byte[] fileData = File.ReadAllBytes(fileName);
                    socket.Send(fileData);
                }
                else
                {
                    socket.Send(Encoding.ASCII.GetBytes("There is no such file!"));
                }
            }
            else if (data == "save")
            {
                string fileName = socket.ReceiveText();

                string fileData = socket.ReceiveText();
                try
                {
                    File.WriteAllText(fileName, fileData);
                    socket.Send(Encoding.ASCII.GetBytes("Successfull saving of file"));
                }
                catch (Exception)
                {
                    socket.Send(Encoding.ASCII.GetBytes("Failed to save file"));
                }

            }

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        public static int Main(String[] args)
        {
            StartListening();
            return 0;
        }
    }
}
