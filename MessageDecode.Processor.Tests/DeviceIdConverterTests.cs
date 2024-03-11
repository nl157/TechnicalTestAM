using MessageDecode.Models;
using MessageDecode.Models.Enums;
using MessageDecode.Processor.Converters;

namespace MessageDecode.Processor.Tests.Utils;

[TestClass]
public class DeviceIdConverterTests
{
    [TestMethod]
    public void Convert_ReturnsExpected()
    {
        var expected = "999991";
        var groupedBytes = ConverterTestUtils.GetGroupedBytes("39", "39", "39", "39", "39", "31");
        var section = new Section() { GroupedBytes = groupedBytes, SchemaSection = SchemaSection.DeviceId };
        var converter = new DeviceIdConverter();

        converter.Convert(section);
        var result = (string?)section.Value;

        Assert.AreEqual(expected, result);
    }
}
