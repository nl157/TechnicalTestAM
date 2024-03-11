namespace MessageDecode.Processor.Tests.Utils;

public static class ConverterTestUtils
{
    public static List<char[]> GetGroupedBytes(params string[] byteSection)
    {
        List<string> odometerBytes = [.. byteSection];
        var groupedBytes = odometerBytes.Select(x => x.ToCharArray()).ToList();
        return groupedBytes;
    }
}
