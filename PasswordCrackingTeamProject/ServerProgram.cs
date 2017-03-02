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
    public class ServerProgram
    {
        public static List<UserInfo> UserInfo; 
        public static int count = 20;

        public static List<string> Dictionary;
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(6789);
            listener.Start();
            Console.WriteLine("Server started!");
            Console.WriteLine();

            Dictionary = new List<string>();
            LoadDictionary();
            

            Console.WriteLine();
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

        private static void LoadDictionary()
        {
            Console.WriteLine("Loading Password File");
            UserInfo = PasswordHandler.ReadPasswordFile("password.txt");
            Console.WriteLine("Password File Loaded.....");
            Console.WriteLine();
            Console.WriteLine("Loading dictionary...");
            Dictionary = DictionaryHandler.ReadDictionary("webster-dictionary.txt");
            Console.WriteLine("Dictionary count: " + Dictionary.Count);
            Console.WriteLine("Dictionary loaded sucessful!");

        }
    }
}
