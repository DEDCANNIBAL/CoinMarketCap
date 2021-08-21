using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CoinMarketCap.WebUI.Controllers.Common
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class MediatorController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
