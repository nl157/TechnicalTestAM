using MessageDecode.Validations.Enums;
using MessageDecode.Validations.Validators;

namespace MessageDecode.Validations;

public class LengthValidator : Validator<string>
{
    public override void Validate(string input)
    {
        int expectedLength = (int) LengthValidatorEnums.MessageLength;
        if (input.Length != expectedLength)
        {
            var difference = input.Length < expectedLength ? expectedLength - input.Length : input.Length - expectedLength;
            throw new Exception($"Invalid input length. Difference: {difference} Characters");
        }

        base.Validate(input);
    }
}