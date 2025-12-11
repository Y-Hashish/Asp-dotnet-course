using System.Text.Json;

namespace StocksApp.Services
{
    public class FinnHubService : IFinnHub
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _config;
        public FinnHubService(IHttpClientFactory httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }
        public async Task<Dictionary<string,object>> GetData(string type)
        {
            using(HttpClient Client = _httpClient.CreateClient())
            {
                HttpRequestMessage requestmessage = new HttpRequestMessage
                    (HttpMethod.Get, new Uri($"https://finnhub.io/api/v1/quote?symbol={type}&token={_config["finnhub"]}"));

                HttpResponseMessage responseMessage = await Client.SendAsync(requestmessage);

                Stream stream = responseMessage.Content.ReadAsStream();
                StreamReader reader = new StreamReader(stream);
                string response = reader.ReadToEnd();
                
                Dictionary<string, object>? data = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

                if (data == null)
                    throw new NullReferenceException();
                if (data.ContainsKey("error"))
                    throw new Exception(data["error"].ToString());

                return data;
            }
        }
    }
}
