using ProgramDuon.Training.Domain;
using ProgramDuon.Training.Domain.Abstractions;

namespace ProgramDuon.Training.Infrastructure;

public class FakeUserRepository : FakeEntityRepository<User>, IUserRepository
{
    public FakeUserRepository(IEnumerable<User> items) : base(items)
    {
    }
}
