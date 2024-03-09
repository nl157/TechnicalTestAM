using MessageDecode.Models.Presenter;

namespace MessageDecode.Models;

public class TripSegment
{
    public TripHeader? TripHeader { get; set; }
    public TripMessage? TripMessage { get; set; }
}
