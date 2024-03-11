
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
    }
}
