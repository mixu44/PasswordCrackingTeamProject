using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
            _listener = listener;
            _client = client;
        }


        public void Run()
        {
            Stream ns = client.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            Console.WriteLine("Ready");
        }



    }
}
