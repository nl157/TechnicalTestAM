using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;

namespace MessageDecode.Processor.Converters
{
    internal class CurrentTimeConverter : IMessageConverter
    {
        public void Convert(Section section)
        {
            var convertedDecimal = HexToDecimalConverter.Convert(section.GroupedBytes!.Reverse());
            var epoch = new DateTime(2000, 01, 01);
            var convertedTime = new TimeSpan(0, 0, convertedDecimal);
            section.Value = epoch + convertedTime;
        }
    }
}
