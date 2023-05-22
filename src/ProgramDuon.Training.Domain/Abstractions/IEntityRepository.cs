namespace ProgramDuon.Training.Domain.Abstractions;

// Generic interface (Template)
public interface IEntityRepository<T>
    where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T item);
    Task UpdateAsync(T item);
    Task DeleteAsync(int id);
}

