using CoinMarketCap.Application.Common.Exceptions;
using CoinMarketCap.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace CoinMarketCap.Application.Cryptocurrency.Queries.GetCryptocurrencyQuotes
{
    public class GetCryptocurrencyQuotesQuery : IRequest<IEnumerable<CryptocurrencyInfoDto>>
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
    }

    public class GetCryptocurrencyQuotesQueryHandler
        : IRequestHandler<GetCryptocurrencyQuotesQuery, IEnumerable<CryptocurrencyInfoDto>>
    {
        private readonly HttpClient _httpClient;

        public GetCryptocurrencyQuotesQueryHandler(ICoinMarketCapService coinMarketCapService)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", coinMarketCapService.ApiKey);
            _httpClient.DefaultRequestHeaders.Add("Accepts", "application/json");
        }

        public async Task<IEnumerable<CryptocurrencyInfoDto>> Handle(GetCryptocurrencyQuotesQuery request,
            CancellationToken cancellationToken)
        {
            var listingsLatest = await GetListingsLatestDto(request, cancellationToken);
            var metadata = await GetMetadata(listingsLatest.Data.Select(i => i.Id), cancellationToken);

            return listingsLatest.Data.Select(i => Map(i, metadata)).ToList();
        }

        private async Task<ListingsLatestDto> GetListingsLatestDto(GetCryptocurrencyQuotesQuery request,
            CancellationToken cancellationToken)
        {
            var uriBuilder = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = (request.Offset + 1).ToString();
            queryString["limit"] = request.Limit.ToString();
            queryString["convert"] = "USD";

            uriBuilder.Query = queryString.ToString();

            var json = await MakeApiCall(uriBuilder.ToString(), cancellationToken);

            return JsonSerializer.Deserialize<ListingsLatestDto>(json);
        }

        private async Task<MetadataDto> GetMetadata(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            var uriBuilder = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/info");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["id"] = string.Join(',', ids);

            uriBuilder.Query = queryString.ToString();

            var json = await MakeApiCall(uriBuilder.ToString(), cancellationToken);

            return JsonSerializer.Deserialize<MetadataDto>(json);
        }

        private async Task<string> MakeApiCall(string requestUri, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(requestUri, cancellationToken);
            if (!response.IsSuccessStatusCode)
                throw new BadRequestException();

            return await response.Content.ReadAsStringAsync(cancellationToken);
        }

        private static CryptocurrencyInfoDto Map(ListingsLatestInfoDto listingsLatestInfoDto, MetadataDto metadataDto)
            => new()
            {
                Name = listingsLatestInfoDto.Name,
                Symbol = listingsLatestInfoDto.Symbol,
                Logo = metadataDto.Data[listingsLatestInfoDto.Id].Logo,
                Price = listingsLatestInfoDto.Quote.USD.Price,
                MarketCap = listingsLatestInfoDto.Quote.USD.MarketCap,
                PercentChange1h = listingsLatestInfoDto.Quote.USD.PercentChange1h,
                PercentChange24h = listingsLatestInfoDto.Quote.USD.PercentChange24h,
                LastUpdated = listingsLatestInfoDto.LastUpdated
            };
    }
}
