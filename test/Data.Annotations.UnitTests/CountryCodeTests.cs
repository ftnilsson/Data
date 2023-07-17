using Data.DataAnnotations;
using Shouldly;

namespace TestProject1
{
    public class CountryCodeTests
    {
        private readonly CountryCodeAttribute _sut;
        
        public CountryCodeTests()
        {
            _sut = new CountryCodeAttribute();
        }
        
        [Fact]
        public void Attribute_Should_Allow_Valid_Codes()
        {
            //ARRANGE

            //ACT
            var result = _sut.IsValid("US");
            
            //ASSET
            result.ShouldBe(true);
        }
        [Fact]
        public void Attribute_Should_Fail_if_Code_is_Null()
        {
            //ARRANGE

            //ACT
            var result = _sut.IsValid(null);
            //ASSET
            result.ShouldBe(false);
        }
        [Fact]
        public void Attribute_Should_Fail_if_Code_is_More_Than_two_Letters()
        {
            //ARRANGE

            //ACT
            var result = _sut.IsValid("ABC");
            //ASSET
            result.ShouldBe(false);
        }
        [Fact]
        public void Attribute_Should_Fail_if_Code_is_Less_Than_two_Letters()
        {
            //ARRANGE

            //ACT
            var result = _sut.IsValid("A");
            //ASSET
            result.ShouldBe(false);
        }
        [Fact]
        public void Attribute_Should_Fail_if_Code_is_not_Found()
        {
            //ARRANGE

            //ACT
            var result = _sut.IsValid("QX");
            //ASSET
            result.ShouldBe(false);
        }
    }
}
