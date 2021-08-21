using CoinMarketCap.Application.Common.Interfaces;
using System;
using System.Net;

namespace CoinMarketCap.Application.Common.Exceptions
{
    public class BadRequestException : Exception, IRestException
    {
        private const string DefaultMessage = "BadRequest";

        public int Code => (int)HttpStatusCode.BadRequest;

        public BadRequestException()
            : this(DefaultMessage)
        {
        }

        public BadRequestException(string message)
            : base(message)
        {
        }
    }
}
