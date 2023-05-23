using ProgramDuon.Training.Domain;
using ProgramDuon.Training.Domain.Abstractions;

namespace ProgramDuon.Training.Infrastructure;

// Generic class (Template class)
public class FakeEntityRepository<T> : IEntityRepository<T>
    where T : BaseEntity
{
    private readonly IDictionary<int, T> _items;

    public FakeEntityRepository(IEnumerable<T> items)
    {
        _items = items.ToDictionary(p => p.Id);
    }

    public Task AddAsync(T item)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<T>>(_items.Values);
    }

    public Task<T> GetByIdAsync(int id)
    {
        if (_items.TryGetValue(id, out T item))
        {
            return Task.FromResult(item);
        }
        else
            return Task.FromResult<T>(null);
    }

    public Task UpdateAsync(T item)
    {
        throw new NotImplementedException();
    }
}
