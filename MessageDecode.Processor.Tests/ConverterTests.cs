using MessageDecode.Models;
using MessageDecode.Models.Enums;
using MessageDecode.Processor.Converters;

namespace MessageDecode.Processor.Tests;
[TestClass]
public class ConverterTests
{



    [TestMethod]
    public void Convert()
    {
        //var blah = "06A6C92B";
        //HexToDecimalConverter.Convert(new char[] {'c'});
    }

    [TestMethod]
    public void CurrentTimeConverter_Convert()
    {
        var expectedTime = new DateTime(2023, 04, 12, 17, 25, 26);
        var currentTimeConverter = new CurrentTimeConverter();
        var a = "06";
        var b = "A6";
        var c = "C9";
        var d = "2B";
        List<char[]> chars = [a.ToCharArray(), b.ToCharArray(), c.ToCharArray(), d.ToCharArray()];
        var section = new Section()
        {
            GroupedBytes = chars,
            SchemaSection = SchemaSection.CurrentTime
        };

        currentTimeConverter.Convert(section);
        var result = (DateTime?)section.Value;

        Assert.AreEqual(expectedTime, result);
    }

    [TestMethod]
    public void DeviceIdConverter_Convert()
    {
        var expectedText = "999991";

        var converter = new DeviceIdConverter();
        var a = "39";
        var b = "39";
        var c = "39";
        var d = "39";
        var e = "39";
        var f = "31";
        List<char[]> chars = [a.ToCharArray(), b.ToCharArray(), c.ToCharArray(), d.ToCharArray(), e.ToCharArray(), f.ToCharArray()];
        var section = new Section()
        {
            GroupedBytes = chars,
            SchemaSection = SchemaSection.DeviceId
        };

        converter.Convert(section);
        var result = (string?)section.Value;

        Assert.AreEqual(expectedText, result);
    }

    [TestMethod]
    public void CurrentSpeedConverter_Convert()
    {
        var expectedValue = 101;

        var converter = new CurrentSpeedConverter();
        var a = "65";
        var b = "00";
        List<char[]> chars = [a.ToCharArray(), b.ToCharArray()];
        var section = new Section()
        {
            GroupedBytes = chars,
            SchemaSection = SchemaSection.CurrentSpeed
        };

        converter.Convert(section);
        var result = (int?)section.Value;

        Assert.AreEqual(expectedValue, result);
    }

    [TestMethod]
    public void OdometerConverter_Convert()
    {
        int expectedValue = 52957;

        var converter = new OdometerConverter();
        var a = "DD";
        var b = "CE";
        var c = "00";
        var d = "00";
        List<char[]> chars = [a.ToCharArray(), b.ToCharArray(), c.ToCharArray(), d.ToCharArray()];
        var section = new Section()
        {
            GroupedBytes = chars,
            SchemaSection = SchemaSection.Odometer
        };

        converter.Convert(section);
        var result = (int?)section.Value;

        Assert.AreEqual(expectedValue, result);
    }

    [TestMethod]
    public void TripIdConverter_Convert()
    {
        var expectedValue = 4569;

        var converter = new TripIdConverter();
        var a = "D9";
        var b = "11";
        var c = "00";
        var d = "00";
        List<char[]> chars = [a.ToCharArray(), b.ToCharArray(), c.ToCharArray(), d.ToCharArray()];
        var section = new Section()
        {
            GroupedBytes = chars,
            SchemaSection = SchemaSection.TripID
        };

        converter.Convert(section);
        var result = (int?)section.Value;

        Assert.AreEqual(expectedValue, result);
    }

    [DataRow("01", true, SchemaSection.TripStart)]
    [DataRow("00", false, SchemaSection.TripEnd)]
    [TestMethod]
    public void TripConverter_Convert(string input, bool expectedResult, SchemaSection schemaSection)
    {
        var currentTimeConverter = new TripConverter();
        List<char[]> chars = [input.ToCharArray()];
        var section = new Section()
        {
            GroupedBytes = chars,
            SchemaSection = schemaSection
        };

        currentTimeConverter.Convert(section);
        var result = (bool?)section.Value;

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void CoordinatesConverter_Latitude_Convert()
    {
        List<string> latitudeBytes = ["BC", "9E", "E0", "01"];
        var expectedResult = 52.49652666666667;
        var converter = new CoordinatesConverter();
        var chars = latitudeBytes.Select(x => x.ToCharArray()).ToList();
        var section = new Section()
        {
            GroupedBytes = chars,
            SchemaSection = SchemaSection.Latitude
        };

        converter.Convert(section);
        var result = (double?)section.Value;

        Assert.AreEqual(expectedResult, result);
    }

        [TestMethod]
    public void CoordinatesConverter_Longitude_Convert()
    {
        List<string> latitudeBytes = ["16", "C0", "EE", "FF"];
        var expectedResult = -1.8841233333333334;
        var converter = new CoordinatesConverter();
        var chars = latitudeBytes.Select(x => x.ToCharArray()).ToList();
        var section = new Section()
        {
            GroupedBytes = chars,
            SchemaSection = SchemaSection.Longitude
        };

        converter.Convert(section);
        var result = (double?)section.Value;

        Assert.AreEqual(expectedResult, result);
    }

}
