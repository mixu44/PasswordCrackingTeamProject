using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCrackingTeamProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(6789);
            listener.Start();

            Console.WriteLine("Server started...");

            int count = 1; 

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();

                Console.WriteLine("Client accepted...");

                TcpService s = new TcpService(listener, client);
                Task.Factory.StartNew(s.Run);

                Console.WriteLine("Client number: " + count++);


            }
        }
    }
}
