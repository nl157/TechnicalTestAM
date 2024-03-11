using MessageDecode.Models;
using MessageDecode.Models.Enums;
using MessageDecode.Shared;

namespace MessageDecode.Processor;
/// <summary>
///  Handles splitting of the Message Bytes into Sections determined by the schema.
/// </summary>
public static class MessageSplitter
{
    /// <summary>
    /// Groups the Bytes into Sections and then assigns a section Enum.
    /// </summary>
    /// <param name="message">Input Message</param>
    /// <returns></returns>
    public static ServiceResult<List<Section>> SplitMessageIntoSections(InputRequest message)
    {
        if (message == null || message.Message! == "")
        {
            return new ServiceResult<List<Section>>(new Exception("Input Request is empty"));
        }

        var groupedBytes = GroupBytesBySectionSizes(message);

        var linkedSections = LinkSectionsToBytes(groupedBytes);

        if (linkedSections == null || linkedSections.Count == 0)
        {
            return new ServiceResult<List<Section>>(new Exception("Error when linking sections to Byte data"));
        }

        return new ServiceResult<List<Section>>(linkedSections);
    }

    /// <summary>
    /// Splits Message in to byte sections. Arranges the bytes into ranges based on Message Section Schema.
    /// </summary>
    /// <param name="message">Input Message</param>
    /// <returns></returns>
    private static List<List<char[]>> GroupBytesBySectionSizes(InputRequest message)
    {
        var splitMessageBytes = message.Message!.ToCharArray().Chunk(2).ToList();
        var groupedBytes = new List<List<char[]>>();
        var startPosition = 0;

        foreach (var schemaSize in message.MessageSectionSizes!)
        {
            groupedBytes.Add(splitMessageBytes.GetRange(startPosition, schemaSize));
            startPosition += schemaSize;
        }

        return groupedBytes;
    }

    /// <summary>
    /// Links the Section Enum to each grouped section
    /// </summary>
    /// <param name="groupedBytes">Message that has been grouped into byte sections</param>
    /// <returns></returns>
    private static List<Section> LinkSectionsToBytes(List<List<char[]>> groupedBytes)
    {
        var schemaSections = Enum.GetValues(typeof(SchemaSection)).Cast<SchemaSection>().ToList();

        if (schemaSections.Count != groupedBytes.Count)
        {
            return new List<Section>();
        }

        return groupedBytes.Zip(schemaSections, (bytes, section) =>
        {
            return new Section()
            {
                GroupedBytes = bytes,
                SchemaSection = section
            };
        }).ToList();
    }
}
