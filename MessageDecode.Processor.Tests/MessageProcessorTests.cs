namespace MessageDecode.Processor.Tests;

[TestClass]
public class MessageProcessorTests
{
    public void Process_Null_ReturnsError()
    {
        var expected = "Input Request is null";
        var processor = new MessageProcessor();

        var result = processor.Process(null!);

        Assert.IsFalse(result.IsSuccess);

        Assert.AreEqual(expected, result.Error!.Message);
    }
}
