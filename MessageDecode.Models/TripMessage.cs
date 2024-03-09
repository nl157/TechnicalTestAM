namespace MessageDecode.Models.Presenter;

public class TripMessage
{
    public required int Speed { get; set; }
    public required int Odometer { get; set; }
    public required List<int> TripId { get; set; }
    public required bool TripStart { get; set; }
    public required bool TripEnd { get; set; }
    public required double Latitude { get; set; }
    public required double Longitude { get; set; }
}
