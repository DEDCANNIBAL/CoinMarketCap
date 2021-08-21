using CoinMarketCap.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CoinMarketCap.Infrastructure.Services
{
    public class CoinMarketCapService : ICoinMarketCapService
    {
        private readonly IConfiguration _configuration;

        public CoinMarketCapService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ApiKey => _configuration["CoinMarketCapApiKey"];
    }
}
