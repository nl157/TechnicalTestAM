using MessageDecode.Shared;

namespace MessageDecode.Validations.Interfaces;
public interface IInputValidationBuilder
{
    public Task<ServiceResult<bool>> IsValidInput(string input);
}
