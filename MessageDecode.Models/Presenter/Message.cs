namespace MessageDecode.Models.Presenter;

public class Message
{
    public required string Start { get; set; }
    public required string Speed { get; set; }
    public required string Odometer { get; set; }
    public required string TripId { get; set; }
    public required string TripStart { get; set; }
    public required string TripEnd { get; set; }
    public required string Latitude { get; set; }
    public required string Longitude { get; set; }
    public required string End { get; set; }
}
