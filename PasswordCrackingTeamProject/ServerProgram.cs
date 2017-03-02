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
        public static int count = 0;

        public static List<string> Dictionary;
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(6789);
            listener.Start();
            Console.WriteLine("Server started!");
            Console.WriteLine();

            Dictionary = new List<string>();
            LoadDictionary();
            DivideDictionary();

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
            Console.WriteLine("Loading dictionary...");
            Dictionary = DictionaryHandler.ReadDictionary("webster-dictionary.txt");
            Console.WriteLine("Dictionary count: " + Dictionary.Count);
            Console.WriteLine("Dictionary loaded sucessful!");
        }

        private static IEnumerable<List<string>> DivideDictionary()
        {
            Console.WriteLine("Dividing dictionary into chunks...");
            int i = 0;
            var chunks = from dic in Dictionary
                         group dic by i++ % 20 into part
                         select part.ToList();

            Console.WriteLine("Dividing completed!");
            Console.WriteLine("Numbers of chunks: " + chunks.Count());

            return chunks; 
        }
    }
}
