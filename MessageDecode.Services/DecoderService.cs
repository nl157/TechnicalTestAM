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

        public async Task<ServiceResult<List<Section>>> DecodeMessage(InputRequest request)
        {
            var validationResult = await _inputValidationBuilder.IsValidInput(request.Message!);

            if (!validationResult.IsSuccess)
            {
                return new ServiceResult<List<Section>>(validationResult.Error);
            }

            var processorResult = _messageProcessor.Process(request);
            
            if (!processorResult.IsSuccess)
            {
                return new ServiceResult<List<Section>>(validationResult.Error);
            }

            return new ServiceResult<List<Section>>(processorResult.Data);
        }
    }
}
