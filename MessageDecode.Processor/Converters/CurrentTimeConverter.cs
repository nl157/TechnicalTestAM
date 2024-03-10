using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;

namespace MessageDecode.Processor.Converters
{
    internal class CurrentTimeConverter : IMessageConverter
    {
        public void Convert(Section section)
        {
            var convertedDecimalSeconds = HexConverter.ConvertToSingleDecimal(section.GroupedBytes!.Reverse());
            var convertedTime = new TimeSpan(0, 0, convertedDecimalSeconds);
            section.Value = new DateTime(2000, 01, 01) + convertedTime;
        }
    }
}
