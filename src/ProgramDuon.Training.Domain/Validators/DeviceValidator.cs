using FluentValidation;
using ProgramDuon.Training.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramDuon.Training.Domain.Validators;

// dotnet add package FluentValidation
public class DeviceValidator : AbstractValidator<Device>
{
    public DeviceValidator()
    {
        RuleFor(p=>p.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(10);

        RuleFor(p => p.Description)
            .NotEmpty()
            .MaximumLength(100);
        
    }
}
