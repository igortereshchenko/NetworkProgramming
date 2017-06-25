using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStreamServer
{
   class Program
    {
        const int PORT = 5006; // порт для прослушивания подключений
        static TcpListener listener;
        static void Main(string[] args)
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), PORT);
                listener.Start();
                Console.WriteLine("waiting...");
 
                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Client clientObject = new Client(client);
 
                    // создаем новый поток для обслуживания нового клиента
                    Task clientTask = new Task(clientObject.Process);
                    clientTask.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }
    }
}
