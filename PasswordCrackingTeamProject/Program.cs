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


            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                TcpService s = new TcpService(listener, client);


                Task.Factory.StartNew(s.Run); 


            }
        }
    }
}
