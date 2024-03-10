using MessageDecode.Models;
using MessageDecode.Models.Enums;

namespace MessageDecode.Processor;

public static class MessageSplitter
{
    internal static List<Section> SplitMessageIntoSchemaByteSections(InputRequest message)
    {
        if (message is null || message.Message == "")
        {
            return [];
        }

        var splitMessageBytes = message.Message!.ToCharArray().Chunk(2).ToList();
        var groupedBytes = new List<List<char[]>>();
        var startPosition = 0;

        foreach (var schemaSize in message.MessageSectionSizes!)
        {
            groupedBytes.Add(splitMessageBytes.GetRange(startPosition, schemaSize));
            startPosition += schemaSize;
        }

        return LinkSectionsToBytes(groupedBytes);
    }

    internal static List<Section> LinkSectionsToBytes(List<List<char[]>> groupedBytes)
    {
        var schemaSections = Enum.GetValues(typeof(SchemaSection)).Cast<SchemaSection>().ToList();

        if (schemaSections.Count != groupedBytes.Count)
        {
            return [];
        }

        return groupedBytes.Zip(schemaSections, (x, y) =>
        {
            return new Section()
            {
                GroupedBytes = x,
                SchemaSection = y
            };
        }).ToList();
    }

    

}
