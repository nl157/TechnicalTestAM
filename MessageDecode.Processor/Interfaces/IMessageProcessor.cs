using MessageDecode.Models;

namespace MessageDecode.Processor.Interfaces;

public interface IMessageProcessor
{
    TripSegment Process(string message);
}
