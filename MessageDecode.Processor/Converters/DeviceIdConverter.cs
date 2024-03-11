using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;

namespace MessageDecode.Processor.Converters
{
    /// <summary>
    /// Manages the conversion for generating the Device Id
    /// </summary>
    internal class DeviceIdConverter : IMessageConverter
    {
        /// <summary>
        /// Converts a byte array to an ascii string for the Device Id
        /// </summary>
        /// <param name="section"></param>
        public void Convert(Section section)
        {
            var decimalResult = HexConverter.ConvertToDecimalList(section.GroupedBytes!, false);

            var output = "";
            foreach(var value in decimalResult)
            {
                output += AsciiConverter.ConvertToAsciiCharacter(value);
            }
            section.Value = output;
        }
    }
}
