using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Home_Office_Solutions_Client.Models;

namespace Home_Office_Solutions_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            GetstationaryItems().Wait();
        }
        private static async Task GetstationaryItems()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:43483/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/StationaryItemsAPI");
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<StationaryItems> statItems = await response.Content.ReadAsAsync<IEnumerable<StationaryItems>>();

                foreach (StationaryItems st in statItems)
                {
                    Console.WriteLine(st);
                }
            }
            else
            {
                Console.WriteLine(response.StatusCode + " Resone Phrease:" + response.ReasonPhrase);
            }
        }
}   }
