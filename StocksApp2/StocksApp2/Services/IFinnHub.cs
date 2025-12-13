namespace StocksApp2.Services
{
    public interface IFinnHub
    {
       Task< Dictionary<string, object> > GetData();
    }
}
