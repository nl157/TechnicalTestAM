using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;

namespace MessageDecode.Processor.Converters
{
    /// <summary>
    /// Manages the conversion of a Byte array into a MPH value.
    /// </summary>
    internal class CurrentSpeedConverter : IMessageConverter
    {
        /// <summary>
        /// Converts the byte array into a decimal between 0 - 300
        /// </summary>
        /// <param name="section"> Section Input</param>
        /// <exception cref="Exception">Speed not in defined range</exception>
        public void Convert(Section section)
        {
            var decimalResult = HexConverter.ConvertToSingleDecimal(section.GroupedBytes!, true);

            if (decimalResult < 0 || decimalResult > 300)
            {
                throw new Exception("Speed not in range (0 - 300)");
            }

            section.Value = decimalResult;
        }
    }
}
