using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;
using MessageDecode.Services.Interfaces;
using MessageDecode.Shared;
using MessageDecode.Validations.Interfaces;

namespace MessageDecode.Services
{
    public class DecoderService : IDecoderService
    {
        private readonly IInputValidator _inputValidationBuilder;
        private readonly IMessageProcessor _messageProcessor;

        public DecoderService(IInputValidator inputValidationBuilder, IMessageProcessor messageProcessor)
        {
            _inputValidationBuilder = inputValidationBuilder;
            _messageProcessor = messageProcessor;
        }

        public ServiceResult<List<Section>> DecodeMessage(InputRequest request)
        {
            var validationResult = _inputValidationBuilder.IsValidInput(request.Message!);

            if (!validationResult.IsSuccess)
            {
                return new ServiceResult<List<Section>>(validationResult.Error);
            }

            var processorResult = _messageProcessor.Process(request);

            if (!processorResult.IsSuccess)
            {
                return new ServiceResult<List<Section>>(processorResult.Error);
            }

            return new ServiceResult<List<Section>>(processorResult.Data);
        }
    }
}
