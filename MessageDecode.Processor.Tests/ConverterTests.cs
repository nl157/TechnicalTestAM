using MessageDecode.Models;
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
        var expectedTime = new DateTime(2023, 04, 12,17,25,26);
        var currentTimeConverter = new CurrentTimeConverter();
        var a = "06";
        var b = "A6";
        var c = "C9";
        var d = "2B";
        List<char[]> chars = [ a.ToCharArray(), b.ToCharArray(), c.ToCharArray(), d.ToCharArray() ];
        var section = new Section() {
            GroupedBytes = chars,
            SchemaSection = Models.Enums.SchemaSection.CurrentTime
        };

        currentTimeConverter.Convert(section);
        var result = (DateTime?)section.Value; 

        Assert.AreEqual(expectedTime, result);
    }
}
