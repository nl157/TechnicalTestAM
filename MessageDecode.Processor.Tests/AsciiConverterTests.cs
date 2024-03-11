using MessageDecode.Processor.Converters;

namespace MessageDecode.Processor.Tests;
[TestClass]
public class AsciiConverterTests
{
    [TestMethod]
    public void ConvertToAsciiCharacter_ResultExpected()
    {
        var expected = "R";
        var input = 82;

        var result = AsciiConverter.ConvertToAsciiCharacter(input);

        Assert.AreEqual(expected, result);
    }

    [DataRow(-1)]
    [DataRow(128)]
    [TestMethod]
    public void ConvertToAsciiCharacter_InputNotInRange_Throws(int input)
    {
        var expected = "Ascii value not in range (0 to 127)";

        Action result = () => AsciiConverter.ConvertToAsciiCharacter(input);

        Assert.ThrowsException<Exception>(result, expected);
    }
}
