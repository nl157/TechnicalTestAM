using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;

namespace MessageDecode.Processor.Converters
{
    internal class CurrentSpeedConverter : IMessageConverter
    {
        public void Convert(Section section) => section.Value = (int)HexConverter.ConvertToSingleDecimal(section.GroupedBytes!.Reverse());
    }
}
