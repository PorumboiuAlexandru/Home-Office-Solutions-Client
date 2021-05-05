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
            Console.ReadLine();
        }
        private static async Task GetstationaryItems()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://homeofficesolution.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync("api/StationaryItemsAPI");
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<StationaryItems> statItems = await response.Content.ReadAsAsync<IEnumerable<StationaryItems>>();
                    var sorted = statItems.OrderBy(s => s.Name);

                    Console.WriteLine("\t Order List By Name");
                    foreach (StationaryItems st in sorted)
                    {
                        Console.WriteLine(st);
                    }
                }
                else
                {
                    Console.WriteLine(response.StatusCode + " Resone Phrease:" + response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
}   }
