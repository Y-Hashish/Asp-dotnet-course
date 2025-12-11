namespace StocksApp.Services
{
    public interface IFinnHub
    {
        public Task<Dictionary<string,object>> GetData(string type);
    }
}
