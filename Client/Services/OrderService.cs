using Client.Model;
using Client.Models;
using InfluencerApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    public class OrderService : IOrderService
    {
        public async Task<List<Product>> CheckoutOrderById(string id)
        {
            var returnResponse = new List<Product>();
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"{APIs._baseUrl}{APIs.CheckoutOrderById}{id}";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var response = await apiResponse.Content.ReadAsStringAsync();
                        var deserializeResponse = JsonConvert.DeserializeObject<MainResponseModel>(response);
                        if (deserializeResponse.IsSuccess)
                        {
                            returnResponse = JsonConvert.DeserializeObject<List<Product>>(deserializeResponse.Content.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return returnResponse;
        }

    }
}
