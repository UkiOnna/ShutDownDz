using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerShutUp
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient sender = new UdpClient();
            sender.JoinMulticastGroup(IPAddress.Parse("224.0.0.0"), 50);


            IPAddress remoteAddress = IPAddress.Parse("224.0.0.0");
            IPEndPoint endPoint = new IPEndPoint(remoteAddress, 161);

            while (true)
            {
                Console.WriteLine("Для выключения введите 1");
                string command = Console.ReadLine();
                if (command == "1")
                {
                    byte[] data = Encoding.Default.GetBytes("t");
                    sender.Send(data, data.Length, endPoint);

                }
            }
            
        }
    }
}
