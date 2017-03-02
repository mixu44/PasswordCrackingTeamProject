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

            var password = "asdad98123adasd";

            sw.WriteLine(Program.count.ToString());
            sw.WriteLine(password);


            while (true)
            {

                var msg = sr.ReadLine();

                if (msg == "/crack")
                {

                }

            }
        }



    }
}
