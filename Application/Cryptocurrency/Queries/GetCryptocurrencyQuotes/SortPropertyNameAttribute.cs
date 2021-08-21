using System;

namespace CoinMarketCap.Application.Cryptocurrency.Queries.GetCryptocurrencyQuotes
{
    public class SortPropertyNameAttribute : Attribute
    {
        public string Name { get; }

        public SortPropertyNameAttribute(string name)
        {
            Name = name;
        }
    }
}
