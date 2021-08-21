using CoinMarketCap.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoinMarketCap.Application.Common.Extensions
{
    public static class EntityFrameworkExtensions
    {
        public static async Task<TEntity> FindByIdAsync<TEntity, TKey>(this IQueryable<TEntity> query, TKey key,
                CancellationToken cancellationToken = default)
            where TEntity : IEntityWithId<TKey>
        {
            return await query.SingleOrDefaultAsync(i => i.Id.Equals(key), cancellationToken);
        }
    }
}
