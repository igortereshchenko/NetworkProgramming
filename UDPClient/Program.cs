using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDPClient
{
    class Program
    {
        static string remoteAddress; // хост для отправки данных
        static int remotePort; // порт для отправки данных
        static int localPort; // локальный порт для прослушивания входящих подключений

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите порт для прослушивания: "); // локальный порт
                localPort = Int32.Parse(Console.ReadLine());
                Console.Write("Введите удаленный адрес для подключения: ");
                remoteAddress = Console.ReadLine(); // адрес, к которому мы подключаемся
                Console.Write("Введите порт для подключения: ");
                remotePort = Int32.Parse(Console.ReadLine()); // порт, к которому мы подключаемся

                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start();
                SendMessage(); // отправляем сообщение
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SendMessage()
        {
            UdpClient sender = new UdpClient(); // создаем UdpClient для отправки сообщений
            try
            {
                while (true)
                {
                    string message = Console.ReadLine(); // сообщение для отправки
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    sender.Send(data, data.Length, remoteAddress, remotePort); // отправка
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sender.Close();
            }
        }

        private static void ReceiveMessage()
        {
            UdpClient receiver = new UdpClient(localPort); // UdpClient для получения данных
            IPEndPoint remoteIp = null; // адрес входящего подключения
            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteIp); // получаем данные
                    string message = Encoding.Unicode.GetString(data);
                    Console.WriteLine("Собеседник: {0}", message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                receiver.Close();
            }
        }
    }
}
