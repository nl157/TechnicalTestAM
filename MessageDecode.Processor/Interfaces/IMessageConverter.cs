using MessageDecode.Models;

namespace MessageDecode.Processor.Interfaces
{
    internal interface IMessageConverter
    {
        void Convert(Section section);
    }
}
