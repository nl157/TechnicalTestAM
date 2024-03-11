using MessageDecode.Models;

namespace MessageDecode.Processor.Tests
{
    [TestClass]
    public class MessageSplitterTests
    {

        private static int[] GetSizes()
        {
            return new int[] { 2, 4, 6, 2, 4, 4, 1, 1, 4, 4 };
        }

        private static string GetTestMessage()
        {
            return "FF0006A6C92B3939393939316500DDCE0000D91100000100BC9EE00116C0EEFF";
        }

        [TestMethod]
        public void SplitMessageIntoSections_ValidMessage_ReturnsExpected()
        {
            var sizes = GetSizes();
            var message = GetTestMessage();
            var expectedSize = 10;

            var result = MessageSplitter.SplitMessageIntoSections(new InputRequest() { Message = message, MessageSectionSizes = sizes });

            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(expectedSize, result.Data.Count);
        }

        [TestMethod]
        public void SplitMessageIntoSections_Null_ReturnsError()
        {
            var expected = "Input Request is empty";
            var result = MessageSplitter.SplitMessageIntoSections(null!);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(expected, result.Error!.Message);
        }

        [TestMethod]
        public void SplitMessageIntoSections_Empty_ReturnsError()
        {
            var expected = "Input Request is empty";
            var sizes = GetSizes();
            var result = MessageSplitter.SplitMessageIntoSections(new InputRequest() { Message = "", MessageSectionSizes = sizes });

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(expected, result.Error!.Message);
        }

        [TestMethod]
        public void SplitMessageIntoSections_ShorterSizeList_ReturnsLinkingError()
        {
            var expected = "Error when linking sections to Byte data";
            var sizes = GetSizes().Take(3).ToArray();
            var message = GetTestMessage();

            var result = MessageSplitter.SplitMessageIntoSections(new InputRequest() { Message = message, MessageSectionSizes = sizes });

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(expected, result.Error!.Message);
        }
    }
}