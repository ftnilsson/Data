using Data.DataAnnotations;
using Shouldly;

namespace TestProject1
{
   
    public class DateTimeOffsetTests
    {
        private DateTimeOffsetAttribute _sut;

       
        public DateTimeOffsetTests()
        {
            _sut = new DateTimeOffsetAttribute();
        }
        
        [Fact]
        public void Attribute_Is_Not_Valid_Id_Null()
        {
            //ARRANGE

            //ACT
            var result = _sut.IsValid(null);
            //ASSET
            result.ShouldBe(false);
        }

        [Fact]
        public void Attribute_Is_Not_Valid_if_Not_Valid_Date()
        {
            //ARRANGE

            //ACT
            var result = _sut.IsValid("2018-01-32");
            //ASSET
            result.ShouldBe(false);
        }

        [Fact]
        public void Attribute_Is_Not_Valid_if_Date_min()
        {
            //ARRANGE

            //ACT
            var result = _sut.IsValid(DateTimeOffset.MinValue);
            //ASSET
            result.ShouldBe(false);
        }

        [Fact]
        public void Attribute_Is_Valid_if_Valid_Date()
        {
            //ARRANGE

            //ACT
            var result = _sut.IsValid(DateTimeOffset.Now);
            //ASSET
            result.ShouldBe(true);
        }

        [Fact]
        public void Attribute_Is_Valid_if_Valid_Date_string()
        {
            //ARRANGE

            //ACT
            var result = _sut.IsValid("2018-01-01");
            //ASSET
            result.ShouldBe(true);
        }
    }
}
