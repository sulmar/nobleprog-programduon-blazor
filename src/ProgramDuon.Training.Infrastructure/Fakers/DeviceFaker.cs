using Bogus;
using ProgramDuon.Training.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramDuon.Training.Infrastructure.Fakers;

public class DeviceFaker : Faker<Device>
{
    public DeviceFaker()
    {
        StrictMode(true);
        RuleFor(p => p.Id, f => f.IndexFaker);
        RuleFor(p => p.Name, f => f.Hacker.Adjective());
        RuleFor(p => p.Description, f => f.Lorem.Paragraph());
        RuleFor(p => p.State, f => f.PickRandom<DeviceState>());
        RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.3f));
        Ignore(p => p.BateryLevel);
    }
}
