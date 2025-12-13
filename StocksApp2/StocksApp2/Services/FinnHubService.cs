
using System.Text.Json;

namespace StocksApp2.Services
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

        public async Task< Dictionary<string, object> >GetData()
        {
            using (HttpClient client = _httpClient.CreateClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage
                    (HttpMethod.Get, new Uri($"https://finnhub.io/api/v1/quote?symbol=AAPL&token={_config["finnhub"]}"));
                HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);
                
                Stream stream = responseMessage.Content.ReadAsStream();
                StreamReader streamReader = new StreamReader(stream);
                
                string response = streamReader.ReadToEnd();
                
                Dictionary<string,object>? data = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

                if (data == null)
                    throw new NullReferenceException();
                if (data.ContainsKey("error"))
                    throw new Exception(data["error"].ToString());
                return data;
            }
            
        }
    }
}
