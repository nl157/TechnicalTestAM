using MessageDecode.Shared;

namespace MessageDecode.Validations.Interfaces;
/// <summary>
/// Manages the chaining of Validations relating to Input.
/// </summary>
public interface IInputValidationBuilder
{
    /// <summary>
    /// Check that all input is valid according to multiple criteria stored in Validators
    /// </summary>
    /// <param name="input">Text entered into input</param>
    /// <returns>Whether the input is valid or not</returns>
    public Task<ServiceResult<bool>> IsValidInput(string input);
}
