using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient
{
    class Program
    {
        static void Main(string[] args)
        {


            ServerFiles("ftp://speedtest.tele2.net");

            DownloadFtpFile("ftp://speedtest.tele2.net/1MB.zip", "C://Users//Igor//Downloads//my.txt");


            UploadFtpFile("ftp://speedtest.tele2.net/upload/my.txt", "C://Users//Igor//Downloads//my.txt");


        }

        public static void ServerFiles(string server)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server);

            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine("Server files:");
            Console.WriteLine();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());

            reader.Close();
            responseStream.Close();
            response.Close();

            Console.ReadKey();
        }

        public static void DownloadFtpFile(string serverFile, string fileName)
        {

            // Создаем объект FtpWebRequest
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverFile);
            // устанавливаем метод на загрузку файлов
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // если требуется логин и пароль, устанавливаем их
            //request.Credentials = new NetworkCredential("login", "password");
            //request.EnableSsl = true; // если используется ssl

            // получаем ответ от сервера в виде объекта FtpWebResponse
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            // получаем поток ответа
            Stream responseStream = response.GetResponseStream();
            // сохраняем файл в дисковой системе
            // создаем поток для сохранения файла
            FileStream fs = new FileStream(fileName, FileMode.Create);

            //Буфер для считываемых данных
            byte[] buffer = new byte[64];
            int size = 0;

            while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fs.Write(buffer, 0, size);

            }
            fs.Close();
            response.Close();

            Console.WriteLine("Finish downloading");
            Console.ReadKey();
        }

        public static void UploadFtpFile(string serverFile, string fileName)
        {

            FtpWebRequest request;



            request = WebRequest.Create(serverFile) as FtpWebRequest;
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.UseBinary = true;
            request.UsePassive = true;
            request.KeepAlive = true;


            using (FileStream fs = File.OpenRead(fileName))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(buffer, 0, buffer.Length);

                Console.WriteLine("Look at site");
                ServerFiles("ftp://speedtest.tele2.net/upload");


                requestStream.Flush();
                requestStream.Close();
            }

            Console.ReadKey();
        }
    }



}