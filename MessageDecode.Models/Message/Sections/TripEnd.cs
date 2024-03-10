using MessageDecode.Models.Enums;
using MessageDecode.Models.Interfaces;

namespace MessageDecode.Models;

public class TripEnd : ISection
{
    public SchemaSection SchemaSection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IEnumerable<char[]>? GroupedBytes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public object Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
