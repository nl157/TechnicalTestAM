using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;
namespace MessageDecode.Processor.Converters
{
    /// <summary>
    /// Manages Conversion for odometer readings.
    /// </summary>
    internal class OdometerConverter : IMessageConverter
    {
        /// <summary>
        /// Converts byte array to a double based odometer value.
        /// </summary>
        /// <param name="section"></param>
        public void Convert(Section section)
        {
            section.Value = (double) HexConverter.ConvertToSingleDecimal(section.GroupedBytes!, true);
        }
    }
}
