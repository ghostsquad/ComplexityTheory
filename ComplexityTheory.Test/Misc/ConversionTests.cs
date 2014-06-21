namespace ComplexityTheory.Test.Misc
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using ComplexityTheory.Core.Misc;

    using Ploeh.AutoFixture;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class ConversionTests
    {
        private const long BasicExpected = 123;

        private const string BasicValue = "123";

        [Fact]
        public void GivenZillowTestWhenIndividualIntExpectLong()
        {
            // act
            var actual = Conversions.StringToLong(BasicValue);

            // assert
            Assert.Equal<long>(BasicExpected, actual);
        }

        [Fact]
        public void GivenZillowTestWhenRoundedExpectLong()
        {
            // act
            var actual = Conversions.StringToLong(BasicValue, Conversions.ConversionMethods.Rounded);

            // assert
            Assert.Equal<long>(BasicExpected, actual);
        }

        [Fact]
        public void GivenLongMaxValue()
        {
            // arrange
            var expected = long.MaxValue;
            var value = expected.ToString();

            // act
            var actual = Conversions.StringToLong(value);

            // assert
            Assert.Equal<long>(expected, actual);
        }

        [Fact]
        public void GivenNegativeInteger()
        {
            // arrange
            var fixture = new Fixture();
            long expected = 0 - fixture.Create<uint>();
            var value = expected.ToString();

            // act
            var actual = Conversions.StringToLong(value);

            // assert
            Assert.Equal<long>(expected, actual);
        }

        [Fact]
        public void GivenLongMinValue()
        {
            // arrange
            var expected = long.MinValue;
            var value = expected.ToString();

            // act
            var actual = Conversions.StringToLong(value);

            // assert
            Assert.Equal<long>(expected, actual);
        }

        [Fact]
        public void GivenZero()
        {
            // arrange
            long expected = 0;
            var value = expected.ToString();

            // act
            var actual = Conversions.StringToLong(value);

            // assert
            Assert.Equal<long>(expected, actual);
        }

        [Fact]
        public void GivenNumberToBigExpectException()
        {
            // arrange
            const string LongMaxPlusOne = "9223372036854775808";

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Conversions.StringToLong(LongMaxPlusOne); });
        }

        [Fact]
        public void GivenNumberTooSmallExpectException()
        {
            // arrange
            var longMinMinusOne = "-9223372036854775809";

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Conversions.StringToLong(longMinMinusOne); });
        }

        [Fact]
        public void GivenInCorrectFormatWhenIndividualIntegersExpectException()
        {
            // arrange
            const string Value = "ABC-123";

            // act & assert
            Assert.Throws<ArgumentException>(() => { Conversions.StringToLong(Value); });
        }

        [Fact]
        public void GivenIncorrectDoubleDecimalFormatWhenIndividualIntegersExpectException()
        {
            // arrange
            const string Value = "123.456.789";

            // act & assert
            Assert.Throws<ArgumentException>(() => { Conversions.StringToLong(Value); });
        }

        [Fact]
        public void GivenIncorrectDoubleDecimalFormatWhenRoundedExpectException()
        {
            // arrange
            const string Value = "123.456.789";

            // act & assert
            Assert.Throws<ArgumentException>(
                () => { Conversions.StringToLong(Value, Conversions.ConversionMethods.Rounded); });

        }

        [Fact]
        public void GivenIncorrectDoubleNegativeFormatWhenIndividualIntegersExpectException()
        {
            // arrange
            const string Value = "--1";

            // act & assert
            Assert.Throws<ArgumentException>(() => { Conversions.StringToLong(Value); });
        }

        [Fact]
        public void GivenNullConversionMethodExpectException()
        {
            // act & assert
            Assert.Throws<NotImplementedException>(
                () => { Conversions.StringToLong(BasicValue, (Conversions.ConversionMethods)int.MaxValue); });

        }

        [Fact]
        public void GivenNullWhenIndividualIntegersExpectException()
        {
            // act & assert
            Assert.Throws<ArgumentNullException>(() => { Conversions.StringToLong(null); });
        }

        [Fact]
        public void GivenIncorrectDoubleNegativeFormatWhenRoundedExpectException()
        {
            // arrange
            const string Value = "--1";

            // act & assert
            Assert.Throws<ArgumentException>(
                () => { Conversions.StringToLong(Value, Conversions.ConversionMethods.Rounded); });
        }

        [Fact]
        public void GivenNullWhenRoundedExpectException()
        {            
            // act & assert
            Assert.Throws<ArgumentNullException>(
                () => { Conversions.StringToLong(null, Conversions.ConversionMethods.Rounded); });

        }

        [Fact]
        public void GivenDoubleWhenRoundedExpectLong()
        {
            // arrange
            var fixture = new Fixture();
            var expectedAsDouble = fixture.Create<double>();
            var expected = (long)expectedAsDouble;
            var value = expectedAsDouble.ToString();

            // act
            var actual = Conversions.StringToLong(value, Conversions.ConversionMethods.Rounded);

            // assert
            Assert.Equal<long>(expected, actual);
        }

        [Fact]
        public void GivenNegativeDoubleWhenRoundedExpectLong()
        {
            // arrange
            var fixture = new Fixture();
            var expectedAsDouble = 0 - fixture.Create<double>();
            var expected = (long)expectedAsDouble;
            var value = expectedAsDouble.ToString();

            // act
            var actual = Conversions.StringToLong(value, Conversions.ConversionMethods.Rounded);

            // assert
            Assert.Equal<long>(expected, actual);
        }
    }
}
