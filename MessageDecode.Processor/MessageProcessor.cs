using System.Diagnostics;
using MessageDecode.Models;
using MessageDecode.Processor.Enums;

namespace MessageDecode.Processor;

public class MessageProcessor
{
    public TripSegment Process(string message)
    {
        var groupedMessage = SplitMessage(message);

        throw new NotImplementedException();
    }

    internal List<SectionData> SplitMessage(string message)
    {
        var groupedBytes = message.ToCharArray().Chunk(2);


        var currentBytePositionCounter = 1;

        var enumSectionList = Enumerable.Range(1, Enum.GetNames(typeof(MessageBytePositionEnum)).Length).ToList();

        var currentMessageSection = 0;
        var nextMessageSEction = 1;
        
        var sortedSectionData = new List<SectionData>();

        foreach (var bytes in groupedBytes)
        {
            // This condition is how it should be when adding to the array
            // if (count < messages[nextMessage] && count > messages[currentMessage])
            // {

            // }

            // TODO Condition to end advancement of messages array 29
            if(enumSectionList[currentMessageSection] != enumSectionList.Last() && currentBytePositionCounter >= enumSectionList[nextMessageSEction])
            {
                currentMessageSection++;
                nextMessageSEction++;
            }
            
            if (sortedSectionData.Select(x => x.PositionEnum).Any())
            {
                sortedSectionData.First(x => (int)x.PositionEnum == enumSectionList[currentMessageSection]).GroupedBytes!.Append(bytes);
            }
            else
            {
                sortedSectionData.Add(new SectionData { PositionEnum = (MessageBytePositionEnum)enumSectionList[currentMessageSection], GroupedBytes = [bytes]});
            }
            currentBytePositionCounter++;
        }

        return sortedSectionData;
    }

}
