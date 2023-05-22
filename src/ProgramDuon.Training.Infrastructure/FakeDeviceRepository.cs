using ProgramDuon.Training.Domain;
using ProgramDuon.Training.Domain.Abstractions;

namespace ProgramDuon.Training.Infrastructure;

public class FakeDeviceRepository : FakeEntityRepository<Device>, IDeviceRepository
{
    public FakeDeviceRepository(IEnumerable<Device> items) : base(items)
    {
    }

    public Task<Device> GetByBarcodeAsync(string barcode)
    {
        throw new NotImplementedException();
    }
}
