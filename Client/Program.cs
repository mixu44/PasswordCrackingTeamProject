using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("localhost", 6789);
            Stream ns = client.GetStream();

            Console.WriteLine("Connected to server...");

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;
            string count = sr.ReadLine();
            Console.WriteLine("You are client number: " + count);
            string password = sr.ReadLine();
            Console.WriteLine(password);

            while (true)
            {
                var msg = Console.ReadLine();
                sw.WriteLine(msg);
            }

        }
    }
}
