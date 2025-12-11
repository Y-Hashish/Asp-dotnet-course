namespace StocksApp.Models
{
    public class Stock
    {
        public string? StockSympol { get; set; }
        public double CurrentPrice { get; set; }
        public double lowestPrice { get; set; } 
        public double highestPrice { get; set; }
        public double openPrice { get; set; }
    }
}
