namespace ProgramDuon.Training.Domain;

public class Device : BaseEntity
{
    public string Name { get; set; }
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
