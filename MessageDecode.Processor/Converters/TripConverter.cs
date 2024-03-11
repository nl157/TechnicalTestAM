using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;

namespace MessageDecode.Processor.Converters
{
    /// <summary>
    /// Manages conversion for boolean values
    /// </summary>
    public class TripConverter : IMessageConverter
    {
        private static readonly string[] sourceArray = ["00", "01"];

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

            var onlyByte = section.GroupedBytes!.First();

            if (!(sourceArray).Contains(new string(onlyByte)))
            {
                throw new Exception("Byte value not in bool range (00 or 01)");
            }

            section.Value = (bool?)HexConverter.ConvertToBool(section.GroupedBytes!.First());
        }
    }
}
