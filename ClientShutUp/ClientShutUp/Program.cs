using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientShutUp
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient reciever = new UdpClient(161);
            reciever.JoinMulticastGroup(IPAddress.Parse("224.0.0.0"), 50);
            IPEndPoint endPoint = null;
            try
            {
                while (true)
                {
                    byte[] data = reciever.Receive(ref endPoint);
                    if (Encoding.UTF8.GetString(data)=="t")
                    {
                        System.Diagnostics.Process.Start("cmd", "/c shutdown -s -f -t 00");
                    }
                }
            }
            catch(SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                reciever.DropMulticastGroup(IPAddress.Parse("224.0.0.0"));
                reciever.Close();
            }
        }
    }
}
