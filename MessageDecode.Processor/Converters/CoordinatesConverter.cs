using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;
namespace MessageDecode.Processor.Converters
{
    internal class CoordinatesConverter : IMessageConverter
    {
        public void Convert(Section section)
        {
            section.Value = (double)HexConverter.ConvertToSingleDecimal(section.GroupedBytes!.Reverse()) / 600000;
        }
    }
}
