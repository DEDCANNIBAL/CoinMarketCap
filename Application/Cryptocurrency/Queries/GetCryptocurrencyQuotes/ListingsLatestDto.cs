using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CoinMarketCap.Application.Cryptocurrency.Queries.GetCryptocurrencyQuotes
{
    public class ListingsLatestDto
    {
        [JsonPropertyName("data")]
        public IEnumerable<ListingsLatestInfoDto> Data { get; set; }
    }

    public class ListingsLatestInfoDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonPropertyName("quote")]
        public QuoteDto Quote { get; set; }
    }

    public class QuoteDto
    {
        [JsonPropertyName("USD")]
        public UsdQuoteDto USD { get; set; }
    }

    public class UsdQuoteDto
    {
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("market_cap")]
        public decimal MarketCap { get; set; }

        [JsonPropertyName("percent_change_1h")]
        public double PercentChange1h { get; set; }

        [JsonPropertyName("percent_change_24h")]
        public double PercentChange24h { get; set; }
    }
}
