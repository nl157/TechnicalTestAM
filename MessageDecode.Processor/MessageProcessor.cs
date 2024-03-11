using MessageDecode.Models;
using MessageDecode.Models.Enums;
using MessageDecode.Models.Presenter;
using MessageDecode.Processor.Converters;
using MessageDecode.Processor.Interfaces;
using MessageDecode.Shared;

namespace MessageDecode.Processor;

public class MessageProcessor : IMessageProcessor
{
    public ServiceResult<List<Section>> Process(InputRequest message)
    {
        if (message == null)
        {
            return new ServiceResult<List<Section>>(new Exception("Input Request is null"));
        }
        var groupedMessage = MessageSplitter.SplitMessageIntoSections(message);

        if (!groupedMessage.IsSuccess)
        {
            return new ServiceResult<List<Section>>(groupedMessage.Error);
        }

        var convertedSections = SectionConverter.ConvertSections(groupedMessage.Data);

        if (!convertedSections.IsSuccess)
        {
            return new ServiceResult<List<Section>>(convertedSections.Error);
        }

        return new ServiceResult<List<Section>>(convertedSections.Data);
    }
}
