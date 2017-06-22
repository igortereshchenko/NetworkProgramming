﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDPMulticastClient
{
    class Program
    {
        static IPAddress remoteAddress; // хост для отправки данных
        const int remotePort = 8001; // порт для отправки данных
        const int localPort = 8001; // локальный порт для прослушивания входящих подключений
        static string username; 
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите свое имя:");
                username = Console.ReadLine();
                remoteAddress = IPAddress.Parse("235.5.5.111");
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
            UdpClient sender = new UdpClient(); // создаем UdpClient для отправки
            IPEndPoint endPoint = new IPEndPoint(remoteAddress, remotePort);
            try
            {
                while (true)
                {
                    string message = Console.ReadLine(); // сообщение для отправки
                    message = String.Format("{0}: {1}", username, message);
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    sender.Send(data, data.Length, endPoint); // отправка
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
            receiver.JoinMulticastGroup(remoteAddress, 20);
            IPEndPoint remoteIp = null;
            string localAddress = LocalIPAddress();
            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteIp); // получаем данные
                    if (remoteIp.Address.ToString().Equals(localAddress))
                        continue;
                    string message = Encoding.Unicode.GetString(data);
                    Console.WriteLine(message);
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
        private static string LocalIPAddress()
        {
            string localIP = "";
            IPHostEntry  host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }
    }
}

