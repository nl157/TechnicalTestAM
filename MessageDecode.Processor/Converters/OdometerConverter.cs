using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;
namespace MessageDecode.Processor.Converters
{
    internal class OdometerConverter : IMessageConverter
    {
        public void Convert(Section section) => section.Value = (decimal)HexConverter.ConvertToSingleDecimal(section.GroupedBytes!.Reverse());
    }
}
