using MessageDecode.Services.Interfaces;
using MessageDecode.Shared;
using MessageDecode.Validations.Interfaces;

namespace MessageDecode.Services
{
    public class DecoderService : IDecoderService
    {
        private readonly IInputValidationBuilder _inputValidationBuilder;

        public DecoderService(IInputValidationBuilder inputValidationBuilder)
        {
            _inputValidationBuilder = inputValidationBuilder;
        }

        public async Task<ServiceResult<List<string>>> DecodeMessage(string message)
        {
            var result = await _inputValidationBuilder.IsValidInput(message);

            if (!result.IsSuccess)
            {
                return new ServiceResult<List<string>>(result.Error);
            }
            return new ServiceResult<List<string>>([message.ToUpper()]);
        }
    }
}
