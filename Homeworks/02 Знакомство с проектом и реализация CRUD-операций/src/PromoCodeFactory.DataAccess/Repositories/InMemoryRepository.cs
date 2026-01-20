using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using System.Collections.Concurrent;

namespace PromoCodeFactory.DataAccess.Repositories;

public class InMemoryRepository<T>: IRepository<T> where T: BaseEntity
{
    private readonly ConcurrentDictionary<Guid, T> _data;

    public InMemoryRepository(IEnumerable<T> data)
    {
        _data = new ConcurrentDictionary<Guid, T>(data.Select(e => new KeyValuePair<Guid, T>(e.Id, e)));
    }

    public Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken ct)
    {
        return Task.FromResult((IReadOnlyCollection<T>)_data);
    }

    public Task<T?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        _data.TryGetValue(id, out var value);
        return Task.FromResult(value);
    }
}
