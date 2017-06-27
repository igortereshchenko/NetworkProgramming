using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkStreamClient
{
    class Program
    {
        const int PORT = 5006;
        const string ADDRESS = "127.0.0.1";
        static void Main(string[] args)
        {
            TcpClient client = null;
            try
            {
                Console.Write("Enter message: ");
                string message = Console.ReadLine();
                client = new TcpClient(ADDRESS, PORT);
                NetworkStream stream = client.GetStream();

                // отправляем сообщение
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine(message);
                writer.Flush();

                // BinaryReader reader = new BinaryReader(new BufferedStream(stream));
                StreamReader reader = new StreamReader(stream);
                message = reader.ReadLine();
                Console.WriteLine("Answer: " + message);

                Console.ReadKey();

                reader.Close();
                writer.Close();
                stream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (client != null)
                    client.Close();
            }
        }
    }
}
