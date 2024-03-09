using MessageDecode.Processor.Enums;

namespace MessageDecode.Processor;

public class SectionData
{

    public MessageBytePositionEnum PositionEnum { get; set; }
    public IEnumerable<char[]>? GroupedBytes { get; set; }
}
