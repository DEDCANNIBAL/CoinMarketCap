using System;

namespace CoinMarketCap.Application.Cryptocurrency.Queries.GetCryptocurrencyQuotes
{
    public class CryptocurrencyInfoDto
    {
        [SortPropertyName("name")]
        public string Name { get; set; }

        [SortPropertyName("symbol")]
        public string Symbol { get; set; }

        public string Logo { get; set; }

        [SortPropertyName("price")]
        public decimal Price { get; set; }

        [SortPropertyName("market_cap")]
        public decimal MarketCap { get; set; }

        [SortPropertyName("percent_change_1h")]
        public double PercentChange1h { get; set; }

        [SortPropertyName("percent_change_24h")]
        public double PercentChange24h { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
