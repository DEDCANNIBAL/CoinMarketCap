using CoinMarketCap.Application.Common.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace CoinMarketCap.WebUI.Utils
{
    public static class ExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var error = context.Features.Get<IExceptionHandlerPathFeature>().Error;

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = error switch
                    {
                        IRestException applicationException => applicationException.Code,
                        _ => (int)HttpStatusCode.InternalServerError
                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(new { Error = error.GetType().Name }));
                });
            });
        }
    }
}
