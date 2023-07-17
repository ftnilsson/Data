using Data.DataAnnotations;
using Shouldly;

namespace TestProject1
{
    /// <summary>
    /// Summary description for EmptyGuidTests
    /// </summary>
    public class EmptyGuidTests
    {

        private NonEmptyGuidAttribute _sut;
        
        public EmptyGuidTests()
        {
            _sut = new NonEmptyGuidAttribute();
        }
        
        [Fact]
        public void Attribute_Should_allow_null_value()
        {
            var result = _sut.IsValid(null);

            result.ShouldBeTrue("should allow null value");
        }

        [Fact]
        public void Attribute_Not_Allow_bad_Guid()
        {
            var result = _sut.IsValid("D1EF4E7C-FD3B-46C7-AC5D");

            result.ShouldBeFalse("should not allow bad value");
        }

        [Fact]
        public void Attribute_Not_Allow_Empty_Guid()
        {
            var result = _sut.IsValid(Guid.Empty);

            result.ShouldBeFalse( "should not allow empty value");
        }
    }
}
