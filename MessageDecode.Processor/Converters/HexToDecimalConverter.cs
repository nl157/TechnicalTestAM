using System.Collections.Generic;

namespace MessageDecode.Processor.Converters;

public static class HexToDecimalConverter
{
    public static int Convert(IEnumerable<char[]> hexList)
    {
        //TODO add reverse futher up
        var parsedChars = new List<char>();

        hexList.ToList().ForEach(x =>
        {
            parsedChars.Add(x.First());
            parsedChars.Add(x.Last());
        });

        return int.Parse(new string(parsedChars.ToArray()), System.Globalization.NumberStyles.HexNumber);
    }
}
