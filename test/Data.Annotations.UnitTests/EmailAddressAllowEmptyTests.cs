using Data.DataAnnotations;
using Shouldly;

namespace TestProject1
{
    /// <summary>
    /// Summary description for EmailAddressAllowEmptyTests
    /// </summary>
    public class EmailAddressAllowEmptyTests
    {
        private EmailAddressAllowEmptyAttribute _sut;

       
        public EmailAddressAllowEmptyTests()
        {
            _sut = new EmailAddressAllowEmptyAttribute();
        }
        [Fact]
        public void Attribute_Should_allow_null_value()
        {
            var result = _sut.IsValid(null);

            result.ShouldBeTrue("should allow null value");
        }

        [Fact]
        public void Attribute_Should_allow_Empty_String()
        {
            var result = _sut.IsValid(string.Empty);

            result.ShouldBeTrue("should allow empty value");
        }

        [Fact]
        public void Attribute_Should_allow_email()
        {
            var result = _sut.IsValid("test@test.com");

            result.ShouldBeTrue("should allow email");
        }

        [Fact]
        public void Attribute_Should_Not_allow_bad_email()
        {
            var result = _sut.IsValid("test.test.com");

            result.ShouldBeFalse("should not allow bad email");
        }
    }
}
