
using MessageDecode.Models.Enums;
using MessageDecode.Models.Interfaces;

namespace MessageDecode.Processor;

public class CurrentSpeed : ISection
{
    public SchemaSection SchemaSection { get; set; }
    public IEnumerable<char[]>? GroupedBytes { get; set; }
    public object Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
