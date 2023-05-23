using System.ComponentModel.DataAnnotations;

namespace ProgramDuon.Training.Domain;

public class Device : BaseEntity
{
    [Required, StringLength(10, MinimumLength = 3)]
    public string Name { get; set; }
    [Required]
    [StringLength(100)]
    public string Description { get; set; }
    public DeviceState State { get; set; }
    public bool IsRemoved { get; set; }

    public float BateryLevel { get; set; }
}

public enum DeviceState
{
    Stopped,
    Starting,
    Started
}
