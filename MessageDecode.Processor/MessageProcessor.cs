using MessageDecode.Models;
using MessageDecode.Models.Enums;
using MessageDecode.Models.Presenter;
using MessageDecode.Processor.Converters;
using MessageDecode.Processor.Interfaces;

namespace MessageDecode.Processor;

public class MessageProcessor
{
    public TripSegment Process(InputRequest message)
    {
        var groupedMessage = MessageSplitter.SplitMessageIntoSchemaByteSections(message);
        var convertedSections = SectionConverter.ConvertSections(groupedMessage);

        throw new NotImplementedException();
    }
}
