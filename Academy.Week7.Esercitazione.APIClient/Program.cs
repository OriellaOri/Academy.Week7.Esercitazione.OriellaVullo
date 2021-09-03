using Academy.Week7.Esercitazione.APIClient.EntitiesContract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week7.Esercitazione.APIClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== TEST API - CLIENT ===");

            Console.WriteLine("Premi un tasto quando le API sono partite.");
            Console.ReadKey();

            HttpClient client = new HttpClient();

            #region CRUD Order

            #region GET

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://localhost:44379/api/order")
            };

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<OrderContract>>(jsonResponse);

                foreach (OrderContract order in data)
                {
                    Console.WriteLine($"\n[{order.Id} || {order.OrderCode}] - {order.DateOrder} - euro {order.Amount} - IdClient: {order.IdClient}");
                }
                    
            }
            #endregion

            #region POST 

            request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://localhost:44379/api/order")
            };

            // nuovo ordine da aggiugnere 
            OrderContract newO = new OrderContract
            {
                DateOrder = DateTime.Today,
                OrderCode = "CODE_TEST",
                ProductCode = "PC_TEST",
                Amount = 6,
                IdClient = 4
            };

            string jsonBody = JsonConvert.SerializeObject(newO);
            request.Content = new StringContent(
                jsonBody,
                Encoding.UTF8,
                "application/json"
            );
            response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var order = JsonConvert.DeserializeObject<OrderContract>(jsonResponse);

                Console.WriteLine($"\nNEW ORDER INSERT >> [{order.OrderCode}] " +
                    $"- {order.DateOrder} - Euro {order.Amount} - IdClient: {order.IdClient}");
            }
            #endregion

            #region PUT

            Console.Write("\n\n>>> Inserire ID del ordine da modificare: ");
            string idVal = Console.ReadLine();
            int.TryParse(idVal, out int id);

            request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:44379/api/order/{id}")
            };

            OrderContract editO = new OrderContract
            {
                Id = id,
                DateOrder = DateTime.Today,
                OrderCode = "CODE_TESTUPDATE",
                ProductCode = "PC_UPDATE",
                Amount = 60,
                IdClient = 4
            };

            jsonBody = JsonConvert.SerializeObject(editO);
            request.Content = new StringContent(
                jsonBody,
                Encoding.UTF8,
                "application/json"
            );

            response = await client.SendAsync(request);
          
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var order = JsonConvert.DeserializeObject<OrderContract>(jsonResponse);

                // NOTE: sistamre > order lo da null
                //Console.WriteLine($"\nEDIT ORDER  >> [{order.OrderCode}] " +
                //   $"- {order.DateOrder} - Euro {order.Amount} - IdClient: {order.IdClient}");
            }
            #endregion

            #region DELETE

            Console.Write("\n>>>Inserire ID del ordine da cancellare: ");
            idVal = Console.ReadLine();
            int.TryParse(idVal, out id);

            request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"https://localhost:44379/api/order/{id}")
            };

            response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"=!!= Order {id} successfully deleted =!!=");
            }
            #endregion

            #endregion


        }
    }
}
