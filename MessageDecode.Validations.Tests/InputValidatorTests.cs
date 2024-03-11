
using MessageDecode.Shared;

namespace MessageDecode.Validations.Tests
{
    [TestClass]
    public class InputValidatorTests
    {
        [TestMethod]

        public void IsValidInput_ValidInput_ReturnsTrue()
        {
            var input = "FF0006A6C92B3939393939316500DDCE0000D91100000100BC9EE00116C0EEFF";

            var validator = new InputValidator();
            var result = validator.IsValidInput(input);

            Assert.IsTrue(result.IsSuccess);

        }
        [TestMethod]

        public void IsValidInput_InvalidLengthInput_OnlyLengthError()
        {
            var expected = "Invalid input length. Difference: 62 Characters";
            var input = "XX";

            var validator = new InputValidator();
            var result = validator.IsValidInput(input);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(expected, result.Error!.Message);
        }

        [TestMethod]

        public void IsValidInput_InvalidInput_OnlyHexError()
        {

            var expected = "Invalid Hex Byte at Position (62)(63) : TT";
            var input = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXTT";

            var validator = new InputValidator();
            var result = validator.IsValidInput(input);

            Assert.IsFalse(result.IsSuccess);
            Assert.IsTrue(result.Error!.Message.ToMultiLineString().Contains(expected));

        }
    }
}
