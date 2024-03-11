using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;
namespace MessageDecode.Processor.Converters
{
    /// <summary>
    /// Converts Section Data into Coordinates
    /// </summary>
    internal class CoordinatesConverter : IMessageConverter
    {
        /// <summary>
        /// Converts the group of bytes into a single value and then to Coordinates
        /// </summary>
        /// <param name="section">Inputted Section</param>
        public void Convert(Section section)
        {
            var decimalResult = (double)HexConverter.ConvertToSingleDecimal(section.GroupedBytes!, true);
            section.Value = decimalResult / 600000.0;
        }
    }
}
