using System;
using BLL.TestServerForPLC;

namespace ServerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.MainFlow();
            server.StartServer("10000");

            Console.Read();

        }
    }
}
