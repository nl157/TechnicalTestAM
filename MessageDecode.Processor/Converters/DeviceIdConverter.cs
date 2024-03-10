using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;

namespace MessageDecode.Processor.Converters
{
    internal class DeviceIdConverter : IMessageConverter
    {
        public void Convert(Section section)
        {
            var decimalResult = HexConverter.ConvertToDecimalList(section.GroupedBytes!);
            var output = "";
            foreach(var value in decimalResult)
            {
                output += AsciiConverter.ConvertToAsciiCharacter(value);
            }
            section.Value = output;
        }
    }
}
