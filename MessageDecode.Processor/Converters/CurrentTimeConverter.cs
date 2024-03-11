using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;

namespace MessageDecode.Processor.Converters
{
    /// <summary>
    /// Manages the conversion of the section data to the current time
    /// </summary>
    internal class CurrentTimeConverter : IMessageConverter
    {
        /// <summary>
        /// Converts Bytes to current time based on a fixed time.
        /// </summary>
        /// <param name="section">Input Bytes</param>
        public void Convert(Section section)
        {
            var convertedDecimalSeconds = HexConverter.ConvertToSingleDecimal(section.GroupedBytes! , true);

            var convertedTime = new TimeSpan(0, 0, convertedDecimalSeconds);
            section.Value = new DateTime(2000, 01, 01) + convertedTime;
        }
    }
}
