using MessageDecode.Models;
using MessageDecode.Models.Enums;
using MessageDecode.Processor.Converters;
using MessageDecode.Processor.Tests.Utils;

namespace MessageDecode.Processor.Tests;

[TestClass]
public class CoordinatesConverterTests
{
    [DataRow(52.49652666666667, SchemaSection.Latitude, "BC", "9E", "E0", "01", DisplayName = "Latitude Conversion")]
    [DataRow(-1.8841233333333334, SchemaSection.Longitude, "16", "C0", "EE", "FF", DisplayName = "Longitude Conversion")]
    [TestMethod]
    public void Convert_ReturnsExpected(double expected, SchemaSection schemaSection, params string[] bytes)
    {
        var groupedBytes = ConverterTestUtils.GetGroupedBytes(bytes);
        var section = new Section() { GroupedBytes = groupedBytes, SchemaSection = schemaSection };
        var converter = new CoordinatesConverter();

        converter.Convert(section);
        var result = (double?)section.Value;

        Assert.AreEqual(expected, result);
    }
}
