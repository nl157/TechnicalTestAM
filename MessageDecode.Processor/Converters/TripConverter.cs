using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;

namespace MessageDecode.Processor.Converters
{
    /// <summary>
    /// Manages conversion for boolean values
    /// </summary>
    internal class TripConverter : IMessageConverter
    {
        /// <summary>
        /// Converts a single byte to bool
        /// </summary>
        /// <param name="section">Input value</param>
        /// <exception cref="Exception"></exception>
        public void Convert(Section section)
        {
            if (section.GroupedBytes!.Count() != 1)
            {
                throw new Exception("Trip requires a single byte");
            }

            var byteString = section.GroupedBytes!.First();

            if (byteString.ToString() != "00" || byteString.ToString() != "01")
            {
                throw new Exception("Byte value not in bool range (00 or 01)");
            }

            section.Value = (bool?)HexConverter.ConvertToBool(section.GroupedBytes!.First());
        }
    }
}
