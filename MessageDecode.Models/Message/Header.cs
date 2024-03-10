namespace MessageDecode.Models;

public class Header 
{
    public Section? Type { get; set; }
    public Section? DeviceId { get; set; }    
    public Section? Time { get; set; }
}

