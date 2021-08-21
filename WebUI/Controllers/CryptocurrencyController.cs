using CoinMarketCap.Application.Cryptocurrency.Queries.GetCryptocurrencyQuotes;
using CoinMarketCap.WebUI.Controllers.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoinMarketCap.WebUI.Controllers
{
    [Authorize]
    public class CryptocurrencyController : MediatorController
    {
        [HttpGet]
        public async Task<IEnumerable<CryptocurrencyInfoDto>> GetCryptocurrencyQuotes()
            => await Mediator.Send(new GetCryptocurrencyQuotesQuery());
    }
}
