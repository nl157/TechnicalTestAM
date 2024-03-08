using Ardalis.Result;

namespace MessageDecode.Services.Interfaces
{
    public interface IDecoderService
    {
        Task<Result<List<string>>> DecodeMessage(string message);
    }
}