using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;

namespace PromoCodeFactory.DataAccess.Repositories;

public class InMemoryRepository<T>: IRepository<T> where T: BaseEntity
{
    private readonly List<T> _data;

    public InMemoryRepository(IEnumerable<T> data)
    {
        _data = [.. data];
    }

    public Task<IEnumerable<T>> GetAllAsync(CancellationToken ct)
    {
        return Task.FromResult(_data.AsEnumerable());
    }

    public Task<T> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return Task.FromResult(_data.FirstOrDefault(x => x.Id == id));
    }
}