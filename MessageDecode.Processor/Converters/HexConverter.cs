
using System.Collections;
using System.Net.NetworkInformation;

namespace MessageDecode.Processor.Converters;

public static class HexConverter
{
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

    public static List<int> ConvertToDecimalList(IEnumerable<char[]> hexList)
    {
        var parsedHex = new List<int>();
        foreach (var item in hexList.ToArray())
        {
            parsedHex.Add(int.Parse(new string(item), System.Globalization.NumberStyles.HexNumber));
        }
        return parsedHex;
    }

    public static bool ConvertToBool(char[] hex) => int.Parse(new string(hex), System.Globalization.NumberStyles.HexNumber) % 2 == 1;
}
