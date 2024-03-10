using MessageDecode.Models.Enums;

namespace MessageDecode.Models.Interfaces;

public interface ISection
{
    SchemaSection SchemaSection { get; set; }
    IEnumerable<char[]>? GroupedBytes { get; set; }
    object Value { get; set; }
}