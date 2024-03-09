using MessageDecode.Shared;
using MessageDecode.Validations.Interfaces;
using MessageDecode.Validations.Validators;
namespace MessageDecode.Validations;

public class InputValidationBuilder : IInputValidationBuilder
{
    public Task<ServiceResult<bool>> IsValidInput(string input)
    {
        try
        {
            var validator = new LengthValidator();
            validator.SetNext(new HexadecimalRegexValidator());
            validator.Validate(input);
        }
        catch (Exception e)
        {
            return Task.FromResult(new ServiceResult<bool>(e));
        }

        return Task.FromResult(new ServiceResult<bool>(true));
    }
}
