namespace MessageDecode.Processor.Converters;
/// <summary>
/// Contains methods for Ascii Conversion
/// </summary>
public class AsciiConverter
{
    /// <summary>
    /// Converts an int to the Ascii character
    /// </summary>
    /// <param name="input"></param>
    /// <returns>Ascii Character as string</returns>
    /// <exception cref="Exception">Not in range exception</exception>
    public static string ConvertToAsciiCharacter(int input)
    {
        if (input < 0 || input > 127)
        {
            throw new Exception("Ascii value not in range (0 to 127)");
        }

        return Convert.ToChar(input).ToString();
    }
}
