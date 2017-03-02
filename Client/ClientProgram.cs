using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class ClientProgram
    {
        public static List<UserInfo> userInfo = new List<UserInfo>(); 

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
            Console.WriteLine();
            Console.WriteLine("Recieving passwords...");
            string password = sr.ReadLine();
            Console.WriteLine("Passwords recieved!");
            var passSplit = password.Split('_'); 

            foreach(var v in passSplit)
            {
                if (!string.IsNullOrEmpty(v))
                {
                    var temp = v.Split(':');
                    userInfo.Add(new UserInfo(temp[0], temp[1])); 

                }
            }

            Console.WriteLine("Passwords count: " + userInfo.Count);

            while (true)
            {
                var msg = Console.ReadLine();
                sw.WriteLine(msg);

                var response = sr.ReadLine(); 


            }

        }
    }
}
