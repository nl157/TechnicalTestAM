using System.Text.RegularExpressions;

namespace MessageDecode.Validations.Validators;

public partial class HexadecimalRegexValidator : Validator<string>
{
    public override void Validate(string input)
    {
        var errors = new List<string>();

        for (int i = 0; i < input.Length - 1; i += 2)
        {
            var hexSegment = input.Substring(i, 2);
            if (!HexRegex().IsMatch(hexSegment))
            {
                errors.Add($"Invalid Hex Byte at Position ({i})({i+1}) : {hexSegment}");
            }
        }

        if (errors.Count != 0)
        {
            throw new Exception($"The Following {errors.Count} Input Errors were found: {Environment.NewLine} {string.Join(Environment.NewLine, errors)}");
        }

        base.Validate(input);
    }

    // Compile Time regex
    [GeneratedRegex(@"[0-9A-Fa-f]")]
    private static partial Regex HexRegex();

}
