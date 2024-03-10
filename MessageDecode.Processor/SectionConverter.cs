using MessageDecode.Models;
using MessageDecode.Models.Enums;
using MessageDecode.Processor.Converters;
using MessageDecode.Processor.Interfaces;

namespace MessageDecode.Processor;

public class SectionConverter
{
    public static List<Section> ConvertSections(List<Section> groupedMessage)
    {
        var sectionWithConverters = new Dictionary<SchemaSection, IMessageConverter>() {
                {SchemaSection.MessageType,new MessageTypeConverter()},
                {SchemaSection.CurrentTime,new CurrentTimeConverter()},
                {SchemaSection.DeviceId,new DeviceIdConverter()},
                {SchemaSection.CurrentSpeed,new CurrentSpeedConverter()},
                {SchemaSection.Odometer,new OdometerConverter()},
                {SchemaSection.TripID, new TripIdConverter()},
                {SchemaSection.TripStart,new TripConverter()},
                {SchemaSection.TripEnd,new TripConverter()},
                {SchemaSection.Latitude,new LatitudeConverter()},
                {SchemaSection.Longitude,new LongitudeConverter()}};

        foreach (var section in groupedMessage)
        {
            if (sectionWithConverters.TryGetValue(section.SchemaSection, out var converter))
            {
                converter.Convert(section);
            }
        }

        return groupedMessage;
    }
}
