using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;

namespace MessageDecode.Processor.Converters;

/// <summary>
/// Wrapper for Converting to single decimal and reversing Bytes
/// </summary>
public class SingleDecimalConverter : IMessageConverter
{
    /// <summary>
    /// Converts the byte array to a single value
    /// </summary>
    /// <param name="section">Section Input</param>
    public void Convert(Section section)
    {
        section.Value = HexConverter.ConvertToSingleDecimal(section.GroupedBytes!, true);
    }

}
