using MessageDecode.Models;
using MessageDecode.Models.Enums;
using MessageDecode.Processor.Converters;
using MessageDecode.Processor.Tests.Utils;
namespace MessageDecode.Processor.Tests;

[TestClass]
public class SingleDecimalConverterTests
{

    [TestMethod]
    public void Convert_TripIdConvert_ReturnsExpected()
    {
        var expectedValue = 4569;
        var groupedBytes = ConverterTestUtils.GetGroupedBytes("D9", "11", "00", "00");
        var section = new Section() { GroupedBytes = groupedBytes, SchemaSection = SchemaSection.TripID };
        var converter = new SingleDecimalConverter();

        converter.Convert(section);
        var result = (int?)section.Value;

        Assert.AreEqual(expectedValue, result);
    }

    [TestMethod]
    public void Conver_MessageTypeConvert_ReturnsExpected()
    {
        var expectedValue = 255;
        var groupedBytes = ConverterTestUtils.GetGroupedBytes("FF", "00");
        var section = new Section() { GroupedBytes = groupedBytes, SchemaSection = SchemaSection.MessageType };
        var converter = new SingleDecimalConverter();

        converter.Convert(section);
        var result = (int?)section.Value;

        Assert.AreEqual(expectedValue, result);
    }
}
