namespace MessageDecode.Shared;

public static class StringExtensions
{
    public static List<string> ToMultiLineString(this string text) => text is not null ? [.. text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)] : ([]);
}
