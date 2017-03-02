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

                }

            }
        }

        public string GetPasswordString()
        {
            string result = ""; 

            foreach(var v in ServerProgram.UserInfo)
            {
                result += v.ToString() + "_"; 
            }

            return result; 
        }



    }
}
