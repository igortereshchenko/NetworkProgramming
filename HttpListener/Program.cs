using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

using System.Text;
using System.Threading.Tasks;

namespace HttpListener
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.HttpListener listener = new System.Net.HttpListener();
            // установка адресов прослушки
            listener.Prefixes.Add("http://localhost:8888/connection/");
            listener.Start();
            Console.WriteLine("waiting...");
            // метод GetContext блокирует текущий поток, ожидая получение запроса 


            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;

            string name = "unknown";
            string text;
            using (var reader = new StreamReader(request.InputStream,
                                                 request.ContentEncoding))
            {
                text = reader.ReadToEnd();

                Console.WriteLine(text);

                string[] pairs = text.Split('&');

                for (int i = 0; i < pairs.Length; i++)

                {

                    string[] item = pairs[i].Split('=');

                    Console.WriteLine(item[1]);
                    if (item[0].Equals("name") )
                    {
                        name = item[1];
                    }

                }
            }

            foreach (var item in request.QueryString)
            {
                Console.WriteLine("QueryString:" +item);
            }

            
            if (request.QueryString["name"] != null)
            {
                Console.WriteLine("param1 value=" + request.QueryString["name"]);
                name = request.QueryString["name"];
            }
            if (request.QueryString["age"] != null)
                Console.WriteLine("param2 value=" + request.QueryString["age"]);


            //http://localhost:8888/connection/?name=ferret&age=12

            // получаем объект ответа
            HttpListenerResponse response = context.Response;
            // создаем ответ в виде кода html
            string responseStr = "<html><head><meta charset='utf8'></head><body>Hello! " + name + "</body></html>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseStr);
            // получаем поток ответа и пишем в него ответ
            response.ContentLength64 = buffer.Length;

            response.StatusCode = (int)HttpStatusCode.Accepted;

            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // закрываем поток

            Console.WriteLine("Done");
            Console.Read();

            output.Close();
            // останавливаем прослушивание подключений
            listener.Stop();
        }
    }
}
