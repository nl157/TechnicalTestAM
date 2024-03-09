namespace MessageDecode.Models.Presenter;

public class Header
{
    public required string Start { get; set; }
    public required string Type { get; set; }
    public virtual string? Time { get; set; }
    public required string DeviceId { get; set; }
    public required string End { get; set; }
}
