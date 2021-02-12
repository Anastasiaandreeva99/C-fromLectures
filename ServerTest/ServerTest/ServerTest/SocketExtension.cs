using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerTest.Server
{
    public static class SocketExtension
    {
        public static string ReceiveText(this Socket socket)
        {
            byte[] bytes = new Byte[1024];
            int bytesRec = socket.Receive(bytes);
            return Encoding.ASCII.GetString(bytes, 0, bytesRec);
        }
    }
}
