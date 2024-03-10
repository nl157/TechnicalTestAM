namespace MessageDecode.Models.Presenter;

public class Message
{
    public Section? Speed { get; set; }
    public Section? Odometer { get; set; }
    public Section? TripId { get; set; }
    public Section? TripStart { get; set; }
    public Section? TripEnd { get; set; }
    public Section? Latitude { get; set; }
    public Section? Longitude { get; set; }
}
