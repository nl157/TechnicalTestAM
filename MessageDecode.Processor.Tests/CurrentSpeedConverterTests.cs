using MessageDecode.Models;
using MessageDecode.Models.Enums;
using MessageDecode.Processor.Converters;
using MessageDecode.Processor.Tests.Utils;

namespace MessageDecode.Processor.Tests;

[TestClass]
public class CurrentSpeedConverterTests
{
    [TestMethod]
    public void Convert_Convert_ReturnsExpected()
    {
        var expectedValue = 101;
        var groupedBytes = ConverterTestUtils.GetGroupedBytes("65", "00");
        var section = new Section() { GroupedBytes = groupedBytes, SchemaSection = SchemaSection.CurrentSpeed };
        var converter = new CurrentSpeedConverter();

        converter.Convert(section);
        var result = (int?)section.Value;

        Assert.AreEqual(expectedValue, result);
    }

    [DataRow("2D", "01" , DisplayName = "Range Exceeded - 301")]
    [TestMethod]
    public void Convert_InputExceedingRange_Throws(params string[] input)
    {
        var expectedMessage = "Speed not in range (0 - 300)";
        var groupedBytes = ConverterTestUtils.GetGroupedBytes(input);
        var section = new Section() { GroupedBytes = groupedBytes, SchemaSection = SchemaSection.CurrentSpeed };
        var converter = new CurrentSpeedConverter();

        var result = () => converter.Convert(section);

        Assert.ThrowsException<Exception>(result, expectedMessage);
    }
}
