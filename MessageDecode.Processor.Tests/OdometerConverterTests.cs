using MessageDecode.Models;
using MessageDecode.Models.Enums;
using MessageDecode.Processor.Converters;
using MessageDecode.Processor.Tests.Utils;

namespace MessageDecode.Processor.Tests;

[TestClass]
public class OdometerConverterTests
{
    [TestMethod]
    public void Converter_ReturnsExpected()
    {
        var expectedValue = 52957;
        var groupedBytes = ConverterTestUtils.GetGroupedBytes("DD", "CE", "00", "00");
        var section = new Section() { GroupedBytes = groupedBytes, SchemaSection = SchemaSection.Odometer };
        var converter = new OdometerConverter();

        converter.Convert(section);
        var result = (double?)section.Value;

        Assert.AreEqual(expectedValue, result);
    }
}
