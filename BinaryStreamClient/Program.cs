using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStreamClient
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
                Console.WriteLine("Enter data!");
                Console.Write("Name: ");
                string userName = Console.ReadLine();

                Console.Write("Money: ");
                decimal sum = Decimal.Parse(Console.ReadLine());

                Console.Write("Period: ");
                int period = Int32.Parse(Console.ReadLine());

                client = new TcpClient(ADDRESS, PORT);
                NetworkStream stream = client.GetStream();

                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(userName);
                writer.Write(sum);
                writer.Write(period);
                writer.Flush();

                BinaryReader reader = new BinaryReader(stream);
                string accountNumber = reader.ReadString();
                Console.WriteLine("Your number " + accountNumber);

                reader.Close();
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
            Console.Read();
        }
    }
}
