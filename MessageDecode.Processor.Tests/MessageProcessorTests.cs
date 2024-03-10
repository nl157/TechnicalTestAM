using MessageDecode.Models;

namespace MessageDecode.Processor.Tests
{
    [TestClass]
    public class MessageSplitterTests
    {
        const string testMessage = "FF0006A6C92B3939393939316500DDCE0000D91100000100BC9EE00116C0EEFF";
        [DataRow(testMessage)]
        [TestMethod]
        public void SplitMessageIntoSchemaByteSections_ValidMessage_Returns(string message)
        {
            var sizes = new int[] {2, 4, 6, 2, 4, 4, 1, 1, 4, 4};
            var expectedSize = 10;
            var result = MessageSplitter.SplitMessageIntoSchemaByteSections(new InputRequest(){Message = message, MessageSectionSizes = sizes});

            Assert.AreEqual(expectedSize, result.Count);
        }
    }
}