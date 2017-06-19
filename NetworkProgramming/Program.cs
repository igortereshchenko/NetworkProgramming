using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetworkProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
          
            //getHostInfo("www.google.com");
            //webClient("http://www.textfiles.com/100/ad.txt");
            //WebRequestWebResponse("http://www.textfiles.com/100/ad.txt");
            HttpWebRequestWebResponseAsync("http://www.textfiles.com/100/ad.txt");

        }


        static void getHostInfo(String hostName)
        {
            Console.WriteLine("getHostInfo...");

            IPHostEntry host1 = Dns.GetHostEntry("www.microsoft.com");
            Console.WriteLine(host1.HostName);
            foreach (IPAddress ip in host1.AddressList)
                Console.WriteLine(ip.ToString());

            Console.ReadKey();
        }

        //---------------------------------------------------------

        static void webClient(String address)
        {
            Console.WriteLine("webClient...");

            WebClient client = new WebClient();

            using (Stream stream = client.OpenRead(address))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }

            downloadFileAsync(address, "myfile.txt").GetAwaiter();

            Console.WriteLine("Upload finished");
            Console.Read();
        }


        private static async Task downloadFileAsync(String address, String fileName)
        {
            WebClient client = new WebClient();
            await client.DownloadFileTaskAsync(new Uri(address), fileName);
        }

        //---------------------------------------------------------


        private static  void webRequestWebResponse(String address)
        {
            Console.WriteLine("WebRequestWebResponse...");

            WebRequest request = WebRequest.Create(address);
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            response.Close();
            Console.WriteLine("Request finished");
            Console.Read();
        }

        //---------------------------------------------------------

        private static void HttpWebRequestWebResponseAsync(String address)
        {
            Console.WriteLine("WebRequestWebResponseAsync...");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            WebHeaderCollection headers = response.Headers;
            for (int i = 0; i < headers.Count; i++)
            {
                Console.WriteLine("{0}: {1}", headers.GetKey(i), headers[i]);
            }

            Console.WriteLine("---------------------------------------------------------------");

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            response.Close();

            Console.Read();
        }
    }
}
