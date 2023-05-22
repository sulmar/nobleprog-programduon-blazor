using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramDuon.Training.Domain.Abstractions;

public interface IDeviceRepository : IEntityRepository<Device>
{    
    Task<Device> GetByBarcodeAsync(string barcode);   
}

