using MessageDecode.Models;
using MessageDecode.Shared;

namespace MessageDecode.Services.Interfaces
{
    public interface IDecoderService
    {
        Task<ServiceResult<List<string>>> DecodeMessage(InputRequest message);
    }
}