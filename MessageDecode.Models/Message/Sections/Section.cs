
using MessageDecode.Models.Enums;
using MessageDecode.Models.Interfaces;

namespace MessageDecode.Models;

public class Section : ISection
{
    public SchemaSection SchemaSection { get; set; }
    public IEnumerable<char[]>? GroupedBytes { get; set; }
    public object? Value { get; set; }
}
