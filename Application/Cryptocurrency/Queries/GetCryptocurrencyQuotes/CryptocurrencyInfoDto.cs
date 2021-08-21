using System;

namespace CoinMarketCap.Application.Cryptocurrency.Queries.GetCryptocurrencyQuotes
{
    public class CryptocurrencyInfoDto
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Logo { get; set; }
        public decimal Price { get; set; }
        public decimal MarketCap { get; set; }
        public double PercentChange1h { get; set; }
        public double PercentChange24h { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
