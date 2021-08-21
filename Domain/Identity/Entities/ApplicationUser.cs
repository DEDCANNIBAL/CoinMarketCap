using CoinMarketCap.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace CoinMarketCap.Domain.Identity.Entities
{
    public class ApplicationUser : IdentityUser, IEntityWithId<string>
    {
    }
}
