using MessageDecode.Shared;

namespace MessageDecode.Services.Interfaces
{
    public interface IDecoderService
    {
        Task<ServiceResult<List<string>>> DecodeMessage(string message);
    }
}