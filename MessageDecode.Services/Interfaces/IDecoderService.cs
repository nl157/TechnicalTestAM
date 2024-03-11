using MessageDecode.Models;
using MessageDecode.Shared;

namespace MessageDecode.Services.Interfaces
{
    /// <summary>
    /// Service that manages the steps of Decoding the InputRequest.
    /// </summary>
    public interface IDecoderService
    {
        /// <summary>
        /// Sends the Input Request for validation and then processes the Validated message.
        /// </summary>
        /// <param name="message">Input from User</param>
        /// <returns>A list of each decoded message section</returns>
        ServiceResult<List<Section>> DecodeMessage(InputRequest message);
    }
}