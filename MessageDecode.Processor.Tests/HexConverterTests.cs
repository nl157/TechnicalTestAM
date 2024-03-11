using MessageDecode.Processor.Converters;
using MessageDecode.Processor.Tests.Utils;

namespace MessageDecode.Processor.Tests;

[TestClass]
public class HexConverterTests
{

    [TestMethod]
    public void ConvertToSingleDecimal_ReverseFalse_ReturnsExpected()
    {
        var expected = 43775;
        var groupedBytes = ConverterTestUtils.GetGroupedBytes("AA", "FF");

        var result = HexConverter.ConvertToSingleDecimal(groupedBytes, false);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void ConvertToSingleDecimal_ReverseTrue_ReturnsExpected()
    {
        var expected = 65450;
        var groupedBytes = ConverterTestUtils.GetGroupedBytes("AA", "FF");

        var result = HexConverter.ConvertToSingleDecimal(groupedBytes, true);

        Assert.AreEqual(expected, result);
    }

        [TestMethod]
    public void ConvertToDecimalList_ReverseFalse_ReturnsExpected()
    {
        List<int> expected = [170, 255];
        var groupedBytes = ConverterTestUtils.GetGroupedBytes("AA", "FF");

        var result = HexConverter.ConvertToDecimalList(groupedBytes, false);

        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void ConvertToDecimalList_ReverseTrue_ReturnsExpected()
    {
        List<int> expected = [255, 170];
        var groupedBytes = ConverterTestUtils.GetGroupedBytes("AA", "FF");

        var result = HexConverter.ConvertToDecimalList(groupedBytes, true);

        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void ConvertToBool_True_ReturnsExpected()
    {
        //True can be anything not 0, but the method calling this narrows input to 00 or 01
        var groupedBytes = ConverterTestUtils.GetGroupedBytes("01");

        var result = HexConverter.ConvertToBool(groupedBytes.First());

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ConvertToBool_False_ReturnsExpected()
    {
        var groupedBytes = ConverterTestUtils.GetGroupedBytes("00");

        var result = HexConverter.ConvertToBool(groupedBytes.First());

        Assert.IsFalse(result);
    }

}
