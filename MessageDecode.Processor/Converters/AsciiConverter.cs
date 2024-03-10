namespace MessageDecode.Processor.Converters;

public class AsciiConverter
{
    public static string ConvertToAsciiCharacter(int input)
    {
        return Convert.ToChar(input).ToString();
    }
}
