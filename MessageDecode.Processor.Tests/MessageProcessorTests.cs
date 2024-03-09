namespace MessageDecode.Processor.Tests
{
    [TestClass]
    public class MessageProcessorTests
    {
        const string testMessage = "FF0006A6C92B3939393939316500DDCE0000D91100000100BC9EE00116C0EEFF";
        
        [DataRow(testMessage)]
        [TestMethod]
        public void SplitMessage_ValidMessage_Returns()
        {
            var processor = new MessageProcessor();

            //processor.Split
        }
    }
}