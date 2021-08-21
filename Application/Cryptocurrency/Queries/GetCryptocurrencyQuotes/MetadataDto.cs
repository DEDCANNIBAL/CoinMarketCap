using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CoinMarketCap.Application.Cryptocurrency.Queries.GetCryptocurrencyQuotes
{
    public class MetadataDto
    {
        [JsonPropertyName("data")]
        public IDictionary<int, MetadataInfoDto> Data { get; set; }
    }

    public class MetadataInfoDto
    {
        [JsonPropertyName("logo")]
        public string Logo { get; set; }
    }
}
