using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkStream
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
                Console.WriteLine("Waiting connection...");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    System.Net.Sockets.NetworkStream stream = client.GetStream();

                    StreamReader reader = new StreamReader(stream);
                    // считываем строку из потока
                    string message = reader.ReadLine();
                    Console.WriteLine("Get: " + message);

                    // отправляем ответ
                    StreamWriter writer = new StreamWriter(stream);
                    message = message.ToUpper();
                    Console.WriteLine("Send: " + message);
                    writer.WriteLine(message);

                    writer.Close();
                    reader.Close();
                    stream.Close();
                    client.Close();
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
