
namespace MessageDecode.Processor.Converters;
/// <summary>
/// This manages multiple conversions from Hexidecimal format
/// </summary>
public static class HexConverter
{
    /// <summary>
    /// Converts Hex to a single decimal with the option to reverse the list
    /// </summary>
    /// <param name="hexList">List input</param>
    /// <param name="reverseList">Reverse the inputted list</param>
    /// <returns></returns>
    public static int ConvertToSingleDecimal(IEnumerable<char[]> hexList, bool reverseList)
    {
        if (reverseList)
        {
            hexList = hexList.Reverse();
        }

        return ConvertToSingleDecimal(hexList);
    }

    /// <summary>
    /// Converts Hex to a single decimal
    /// </summary>
    /// <param name="hexList">List Input</param>
    /// <returns></returns>
    public static int ConvertToSingleDecimal(IEnumerable<char[]> hexList)
    {
        var parsedChars = new List<char>();

        hexList.ToList().ForEach(x =>
        {
            parsedChars.Add(x.First());
            parsedChars.Add(x.Last());
        });

        return int.Parse(new string(parsedChars.ToArray()), System.Globalization.NumberStyles.HexNumber);
    }

    /// <summary>
    /// Converts Hex to a decimal list with the option to reverse the list
    /// </summary>
    /// <param name="hexList">List input</param>
    /// <param name="reverseList">Reverse the inputted list</param>
    /// <returns></returns>
    public static List<int> ConvertToDecimalList(IEnumerable<char[]> hexList, bool reverseList)
    {
        if (reverseList)
        {
            hexList = hexList.Reverse();
        }

        return ConvertToDecimalList(hexList);
    }

    /// <summary>
    /// Converts Hex to a decimal list
    /// </summary>
    /// <param name="hexList">List Input</param>
    /// <returns></returns>
    public static List<int> ConvertToDecimalList(IEnumerable<char[]> hexList)
    {
        var parsedHex = new List<int>();
        foreach (var item in hexList.ToArray())
        {
            parsedHex.Add(int.Parse(new string(item), System.Globalization.NumberStyles.HexNumber));
        }
        return parsedHex;
    }

    /// <summary>
    /// Converts a byte to a boolean value
    /// </summary>
    /// <param name="hex"></param>
    /// <returns></returns>
    public static bool ConvertToBool(char[] hex) => Convert.ToBoolean(int.Parse(new string(hex), System.Globalization.NumberStyles.HexNumber));
}
