namespace MessageDecode.Models;

public class TripHeader 
{
    public MessageType? Type { get; set; }
    public string? DeviceId { get; set; }    
    public DateTime? Time { get; set; }
}

