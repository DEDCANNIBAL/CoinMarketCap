using CoinMarketCap.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CoinMarketCap.Application.Common.Behaviors
{
    public class UnhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentUserService _currentUserService;

        public UnhandledExceptionBehavior(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                var userId = _currentUserService.UserId ?? string.Empty;
                var message = ex.Message;
                var stackTrace = ex.StackTrace ?? string.Empty;
                var innerExceptionMessage = ex.InnerException?.Message ?? string.Empty;

                _logger.LogError($"Unhandled Exception: {requestName};{userId};{message};{stackTrace};" +
                    $"{innerExceptionMessage}");

                throw;
            }
        }
    }
}
