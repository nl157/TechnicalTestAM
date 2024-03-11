using MessageDecode.Models;
using MessageDecode.Models.Enums;
using MessageDecode.Processor.Converters;
using MessageDecode.Processor.Tests.Utils;

namespace MessageDecode.Processor.Tests;

[TestClass]
public class TripConverterTests
{
    [DataRow("01", true, SchemaSection.TripStart, DisplayName = "True Test")]
    [DataRow("00", false, SchemaSection.TripEnd, DisplayName = "False Test")]
    [TestMethod]
    public void Convert_ReturnsExpected(string input, bool expectedResult, SchemaSection schemaSection)
    {
        List<char[]> chars = [input.ToCharArray()];
        var section = new Section() { GroupedBytes = chars, SchemaSection = schemaSection };
        var currentTimeConverter = new TripConverter();

        currentTimeConverter.Convert(section);
        var result = (bool?)section.Value;

        Assert.AreEqual(expectedResult, result);
    }
    
    [TestMethod]
    public void Convert_MoreThanOneByte_Throws()
    {
        var expectedMessage = "Trip requires a single byte";
        var groupedBytes = ConverterTestUtils.GetGroupedBytes("01", "01");
        var section = new Section() { GroupedBytes = groupedBytes, SchemaSection = SchemaSection.TripStart };
        var currentTimeConverter = new TripConverter();

        var result = () => currentTimeConverter.Convert(section);

        Assert.ThrowsException<Exception>(result, expectedMessage);
    }

    [TestMethod]
    public void Convert_OutOfRange_Throws()
    {
        var expectedMessage = "Byte value not in bool range (00 or 01)";
        var groupedBytes = ConverterTestUtils.GetGroupedBytes("21");
        var section = new Section() { GroupedBytes = groupedBytes, SchemaSection = SchemaSection.TripStart };
        var currentTimeConverter = new TripConverter();

        var result = () => currentTimeConverter.Convert(section);

        Assert.ThrowsException<Exception>(result, expectedMessage);
    }
}
