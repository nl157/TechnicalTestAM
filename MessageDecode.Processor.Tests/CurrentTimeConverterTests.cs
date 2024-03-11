using MessageDecode.Models;
using MessageDecode.Models.Enums;
using MessageDecode.Processor.Converters;
using MessageDecode.Processor.Tests.Utils;

namespace MessageDecode.Processor.Tests;
[TestClass]
public class CurrentTimeConverterTests
{
    [TestMethod]
    public void Convert_ReturnsExpected()
    {
        var expected = new DateTime(2023, 04, 12, 17, 25, 26);
        var groupedBytes = ConverterTestUtils.GetGroupedBytes("06", "A6", "C9", "2B");
        var section = new Section() { GroupedBytes = groupedBytes, SchemaSection = SchemaSection.CurrentTime };
        var currentTimeConverter = new CurrentTimeConverter();

        currentTimeConverter.Convert(section);
        var result = (DateTime?)section.Value;

        Assert.AreEqual(expected, result);
    }
}
