using System.ComponentModel.DataAnnotations;

namespace ProgramDuon.Training.Domain;

public class Device : BaseEntity, IValidatableObject
{
    [Required, StringLength(10, MinimumLength = 3)]
    public string Name { get; set; }
    [Required]
    [StringLength(100)]
    public string Description { get; set; }
    public DeviceState State { get; set; }
    public bool IsRemoved { get; set; }

    public double MemoryUsed { get; set; }
    public float BateryLevel { get; set; }

    public float MinTemperature { get; set; }
    public float MaxTemperature { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (MinTemperature > MaxTemperature)
            yield return new ValidationResult($"The {nameof(MinTemperature)} value must not be greater than the {nameof(MaxTemperature)} value");
        else
            yield return ValidationResult.Success;
    }
}

public enum DeviceState
{
    Stopped,
    Running,
    Starting,
    Started
}
