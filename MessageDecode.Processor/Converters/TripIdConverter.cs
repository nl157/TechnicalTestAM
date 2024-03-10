using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;

namespace MessageDecode.Processor.Converters;

public class TripIdConverter : IMessageConverter
{
    public void Convert(Section section)
    {
        section.Value = HexConverter.ConvertToSingleDecimal(section.GroupedBytes!.Reverse());
    }

}
