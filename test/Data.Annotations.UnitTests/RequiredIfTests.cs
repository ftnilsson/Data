using Data.DataAnnotations;
using Shouldly;

namespace TestProject1
{
    public class RequiredIfTests
    {
        private RequiredIfAttribute _sut;
        
        public RequiredIfTests(RequiredIfAttribute sut)
        {
            this._sut = sut;
        }

        [Fact]
        public void Required_Condition_Is_is_Met()
        {
            _sut = new RequiredIfAttribute((1 + 1 == 2));
            var result = _sut.IsValid(null);

            result.ShouldBeFalse("is required");
        }

        [Fact]
        public void Required_If_Condition_Is_true_and_has_data()
        {
            _sut = new RequiredIfAttribute((1 + 1 == 2));
            var result = _sut.IsValid("value");

            result.ShouldBeTrue("is valid");
        }

        [Fact]
        public void Not_Required_If_Condition_Is_false()
        {
            _sut = new RequiredIfAttribute((1 + 1 == 3));
            var result = _sut.IsValid(null);

            result.ShouldBeTrue("is not required");
        }

        [Fact]
        public void Not_Required_If_Condition_Is_false_but_has_data()
        {
            _sut = new RequiredIfAttribute((1 + 1 == 3));
            var result = _sut.IsValid(null);

            result.ShouldBeTrue("should be valid");
        }
    }
}
