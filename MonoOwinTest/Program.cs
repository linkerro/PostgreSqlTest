using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace MonoOwinTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var hostUrl = "http://localhost:9000/";

            using (WebApp.Start<Startup>(hostUrl))
            {
                HttpClient client=new HttpClient();

                var response = client.GetAsync(hostUrl + "api/contacts").Result;
                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.ReadLine();
            }
        }
    }
}
