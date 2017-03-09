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
        public static List<string> Dictionary;
        public static List<UserInfoClearText> Result = new List<UserInfoClearText>();

        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("192.168.6.212", 6789);
            Stream ns = client.GetStream();

            Dictionary = new List<string>();

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

            foreach (var v in passSplit)
            {
                if (!string.IsNullOrEmpty(v))
                {
                    var temp = v.Split(':');
                    userInfo.Add(new UserInfo(temp[0], temp[1]));

                }
            }

            Console.WriteLine("Passwords count: " + userInfo.Count);

            Console.WriteLine("Ready to crack. Type /crack to crack");

            bool cont = true;

            while (true)
            {
                var msg = Console.ReadLine();
                sw.WriteLine(msg);

                while (cont)
                {
                    var response = sr.ReadLine();

                    if (response == "crack")
                    {
                        var dic = sr.ReadLine();
                        var splitDdic = dic.Split('_');

                        foreach (var v in splitDdic)
                        {
                            if (!string.IsNullOrEmpty(v))
                            {
                                Dictionary.Add(v);
                            }
                        }

                        Console.WriteLine("Dictionary count: " + Dictionary.Count);

                        Cracking crack = new Cracking();
                        crack.RunCracking(userInfo, Dictionary);

                        string cracketPasswords = ""; 

                        if (Result.Count == 0)
                        {
                            cracketPasswords = "null";
                        }

                        foreach (var v in Result)
                        {
                            cracketPasswords += v + "_";
                        }

                        sw.WriteLine(cracketPasswords);

                        Dictionary.Clear();
                        Result.Clear();

                        Console.WriteLine(sr.ReadLine());

                        Console.WriteLine();
                        Console.WriteLine("Continue? y / n");

                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            sw.WriteLine("/crack");
                            Console.WriteLine();

                            continue;

                        }
                        else if (Console.ReadKey().Key == ConsoleKey.N)
                        {

                        }
                        else
                        {
                            Console.WriteLine("Y = Continue. N = Dont continue");
                        }
                    }

                }
            }

        }
    }
}
