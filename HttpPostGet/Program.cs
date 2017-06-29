using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HttpPostGet
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetRequest("http://www.google.com");

            PostRequest("http://localhost:8888/connection/");
           Console.ReadKey();
        }

        async static void GetRequest(string uri)
        {

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(uri))
                {
                    using (HttpContent content = response.Content)
                    {

                        string mycontent = await content.ReadAsStringAsync();

                        Console.WriteLine(mycontent);

                        Console.WriteLine("____________________________________________");

                        HttpContentHeaders headers = content.Headers;

                        Console.WriteLine(headers);
                    }
                }
            }
        }


        async static void PostRequest(string uri)
        {
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("name","igor"),
                new KeyValuePair<string, string>("age","12")
            };

            HttpContent contentQuery = new FormUrlEncodedContent(queries);

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync(uri,contentQuery))
                {
                    using (HttpContent content = response.Content)
                    {

                        string mycontent = await content.ReadAsStringAsync();

                        Console.WriteLine(mycontent);
                        Console.WriteLine(response.StatusCode);

                        Console.WriteLine("____________________________________________");

                        HttpContentHeaders headers = content.Headers;

                        Console.WriteLine(headers);
                    }
                }
            }
        }
    }
}
