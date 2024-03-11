using MessageDecode.Shared;
using MessageDecode.Validations.Interfaces;
using MessageDecode.Validations.Validators;
namespace MessageDecode.Validations;

public class InputValidator : IInputValidator
{
    public ServiceResult<bool> IsValidInput(string input)
    {
        try
        {
            var validator = new LengthValidator();
            validator.SetNext(new HexadecimalRegexValidator());
            validator.Validate(input);
        }
        catch (Exception e)
        {
            return new ServiceResult<bool>(e);
        }

        return new ServiceResult<bool>(true);
    }
}
