using MessageDecode.Models;
using MessageDecode.Shared;

namespace MessageDecode.Processor.Interfaces;

public interface IMessageProcessor
{
    ServiceResult<List<Section>> Process(InputRequest message);
}
