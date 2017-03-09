using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCrackingTeamProject
{
    public class TcpService
    {
        TcpListener listener;
        TcpClient client;

        public TcpService(TcpListener _listener, TcpClient _client)
        {
            listener = _listener;
            client = _client;
        }


        public void Run()
        {
            Stream ns = client.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            sw.WriteLine(ServerProgram.count.ToString());
            sw.WriteLine(GetPasswordString());


            while (true)
            {
                var msg = sr.ReadLine();

                if (msg == "/crack")
                {
                    sw.WriteLine("crack");
                    sw.WriteLine(GetChunk());

                    var res = sr.ReadLine();

                    if (res == "null")
                    {
                        Console.WriteLine("Client found no passwords...");
                    }
                    else
                    {
                        var splitRes = res.Split('_');

                        foreach (var v in splitRes)
                        {
                            var result = v.Split(':');

                            if (!string.IsNullOrEmpty(v))
                            {
                                ServerProgram.EndResult.Add(new UserInfoClearText(result[0], result[1]));
                            }
                        }

                        Console.WriteLine("Result so far: ");

                        foreach(var v in ServerProgram.EndResult)
                        {
                            Console.WriteLine(v);
                        }

                    }
                    sw.WriteLine("Chunks count: " + (20 - ServerProgram.Index));
                }
                else
                {
                    sw.WriteLine("Unkown Command");
                }

            }
        }

        public string GetPasswordString()
        {
            string result = "";

            foreach (var v in ServerProgram.UserInfo)
            {
                result += v.ToString() + "_";
            }

            return result;
        }

        public string GetChunk()
        {
            var index = ServerProgram.Index;
            ServerProgram.Index++;

            var list = ServerProgram.DictionaryChunks.ToList()[index];
            string result = "";

            foreach (var v in list)
            {
                result += v + "_";
            }

            return result;
        }


    }
}
