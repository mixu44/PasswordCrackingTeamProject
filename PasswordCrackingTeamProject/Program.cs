using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCrackingTeamProject
{
    public class Program
    {
        public static int count = 0; 
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(6789);
            listener.Start();

            Console.WriteLine("Server started...");
            Console.WriteLine("Waiting for clients to connect...");

         

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                count++;

                Console.WriteLine("Client accepted...");

                TcpService s = new TcpService(listener, client);
                Task.Factory.StartNew(s.Run);

                Console.WriteLine("Client number: " + count);


            }
        }
    }
}
