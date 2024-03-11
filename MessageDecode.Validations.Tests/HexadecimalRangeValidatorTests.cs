using MessageDecode.Validations.Validators;

namespace MessageDecode.Validations.Tests
{
    [TestClass]
    public class HexadecimalRangeValidatorTests
    {
        [TestMethod]
        public void Validate_NonHexByte_Throws()
        {
            var expected = "Invalid Hex Byte at Position (0)(1) : XX";
            var input = "XX";

            var validator = new HexadecimalRegexValidator();
            var result = () => validator.Validate(input);

            Assert.ThrowsException<Exception>(result, expected);
        }
    }
}