using MessageDecode.Models;
using MessageDecode.Models.Enums;
using MessageDecode.Processor.Converters;
using MessageDecode.Processor.Interfaces;
using MessageDecode.Shared;

namespace MessageDecode.Processor;
/// <summary>
/// Manages the assinging and running of Converters
/// </summary>
public class SectionConverter
{
    /// <summary>
    /// Links SchemaSection Enums to relevant converter and runs each converter
    /// </summary>
    /// <param name="groupedSections"></param>
    /// <returns></returns>
    public static ServiceResult<List<Section>> ConvertSections(List<Section> groupedSections)
    {
        var sectionsLinkedToConverter = new Dictionary<SchemaSection, IMessageConverter>() {
                {SchemaSection.MessageType, new SingleDecimalConverter()},
                {SchemaSection.CurrentTime, new CurrentTimeConverter()},
                {SchemaSection.DeviceId, new DeviceIdConverter()},
                {SchemaSection.CurrentSpeed, new CurrentSpeedConverter()},
                {SchemaSection.Odometer, new OdometerConverter()},
                {SchemaSection.TripID, new SingleDecimalConverter()},
                {SchemaSection.TripStart, new TripConverter()},
                {SchemaSection.TripEnd, new TripConverter()},
                {SchemaSection.Latitude, new CoordinatesConverter()},
                {SchemaSection.Longitude, new CoordinatesConverter()}};

        try
        {
            RunConverter(groupedSections, sectionsLinkedToConverter);
        }
        catch (Exception e)
        {
            return new ServiceResult<List<Section>>(e);
        }

        return new ServiceResult<List<Section>>(groupedSections);
    }
    /// <summary>
    /// Runs converter for linked section.
    /// </summary>
    /// <param name="groupedSections">Grouped Section Bytes</param>
    /// <param name="sectionsLinkedToConverter">Dictionary of Sections linked to converters</param>
    /// <exception cref="Exception">If TryGetValue fails to link section to converter</exception>
    private static void RunConverter(List<Section> groupedSections, Dictionary<SchemaSection, IMessageConverter> sectionsLinkedToConverter)
    {
        foreach (var section in groupedSections)
        {
            if (sectionsLinkedToConverter.TryGetValue(section.SchemaSection, out var converter))
            {
                converter.Convert(section);
            }
            else
            {
                throw new Exception($"Error when converting section : {section.GroupedBytes!}");
            }
        }
    }

}
