using Data.DataAnnotations;
using Shouldly;

namespace TestProject1
{
    /// <summary>
    /// Summary description for ValidEnumTests
    /// </summary>
    public class ValidEnumTests
    {
        private ValidEnumValueAttribute _sut;

        public enum MyEnum
        {
            Apple = 0,
            Pear = 1,
            Banana = 3
        }
        
        public ValidEnumTests()
        {
            _sut = new ValidEnumValueAttribute();
        }
        [Fact]
        public void Attribute_Should_Not_allow_null_value()
        {
            var result = _sut.IsValid(null);

            result.ShouldBeFalse("should not allow null value");
        }

        [Fact]
        public void Attribute_Should_Not_allow_Non_existing_Enum_value()
        {
            var result = _sut.IsValid(4);

            result.ShouldBeFalse("should not allow missing enum value");
        }

        [Fact]
        public void Attribute_Should_Not_allow_Non_existing_Enum_value_string()
        {
            var result = _sut.IsValid("Car");

            result.ShouldBeFalse("should not allow missing enum value");
        }

        [Fact]
        public void Attribute_Should__allow_existing_Enum_value_string()
        {
            var result = _sut.IsValid("Apple");

            result.ShouldBeTrue("should allow enum value");
        }

        [Fact]
        public void Attribute_Should__allow_existing_Enum_value()
        {
            var result = _sut.IsValid(0);

            result.ShouldBeTrue( "should allow enum value");
        }
    }
}
