using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;
using MessageDecode.Services.Interfaces;
using MessageDecode.Shared;
using MessageDecode.Validations.Interfaces;

namespace MessageDecode.Services
{
    public class DecoderService : IDecoderService
    {
        private readonly IInputValidationBuilder _inputValidationBuilder;
        private readonly IMessageProcessor _messageProcessor;

        public DecoderService(IInputValidationBuilder inputValidationBuilder, IMessageProcessor messageProcessor)
        {
            _inputValidationBuilder = inputValidationBuilder;
            _messageProcessor = messageProcessor;
        }

        public async Task<ServiceResult<List<string>>> DecodeMessage(InputRequest request)
        {
            //Validator
            var validationResult = await _inputValidationBuilder.IsValidInput(request.Message!);

            if (!validationResult.IsSuccess)
            {
                return new ServiceResult<List<string>>(validationResult.Error);
            }
            
            // Processor
            var processorResult = _messageProcessor.Process(request);
            return new ServiceResult<List<string>>([request.Message!.ToUpper()]);
        }
    }
}
