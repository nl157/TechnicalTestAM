using Ardalis.Result;
using MessageDecode.Services.Interfaces;

namespace MessageDecode.Services
{
    public class DecoderService : IDecoderService
    {
        public DecoderService()
        {
        }

        public async Task<Result<List<string>>> DecodeMessage(string message)
        {
            await Task.Delay(1);
            return new Result<List<string>>([message.ToUpper()]);
        }
    }
}
