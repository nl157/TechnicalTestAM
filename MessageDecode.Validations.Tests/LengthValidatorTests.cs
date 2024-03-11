
using MessageDecode.Validations.Validators;

namespace MessageDecode.Validations.Tests
{
    [TestClass]
    public class LengthValidatorTests
    {
        [TestMethod]
        public void Validate_InputShorterThanLength_Throws()
        {
            var expected = "Invalid input length. Difference: 62 Characters";
            var input = "XX";

            var validator = new LengthValidator();
            var result = () => validator.Validate(input);

            Assert.ThrowsException<Exception>(result, expected);
        }
    }
}
