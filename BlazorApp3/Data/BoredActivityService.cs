using static BlazorApp3.Data.BoredActivityService;
using System.Text.Json;

namespace BlazorApp3.Data
{
    public class BoredActivityService
    {
            private readonly IHttpClientFactory _httpClientfactory;

            public BoredActivityService(IHttpClientFactory httpClientFactory)
            {
                _httpClientfactory = httpClientFactory;
            }

            public async Task<BoredActivity?> GetRandomActivityAsync()
            {

                var client = _httpClientfactory.CreateClient("boredapi");
                try
                {
                    BoredActivity? response = await client.GetFromJsonAsync<BoredActivity>("activity/",
                                                                                           new JsonSerializerOptions(JsonSerializerDefaults.Web));
                    return response;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }


            }
    }
}
