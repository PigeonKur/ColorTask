
using Xunit;
using ColorLibrary;
using System;

namespace ColorLibrary.Tests
{
    public class ColorConverterTests
    {
        public class ColorConverterTest
        {
            [Theory]
            [InlineData(255, 255, 255, "#FFFFFF")]
            [InlineData(0, 0, 0, "#000000")]
            [InlineData(128, 64, 32, "#804020")]
            public void RgbToHex_ValidValues_ReturnsCorrectHex(int r, int g, int b, string expected)
            {
                var result = ColorConverter.RgbToHex(r, g, b);
                Assert.Equal(expected, result);
            }

            [Theory]
            [InlineData(-1, 0, 0)]
            [InlineData(0, 256, 0)]
            public void RgbToHex_InvalidValues_ThrowsException(int r, int g, int b)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => ColorConverter.RgbToHex(r, g, b));
            }

            [Theory]
            [InlineData("#FFFFFF", 255, 255, 255)]
            [InlineData("#000000", 0, 0, 0)]
            public void HexToRgb_ValidHex_ReturnsCorrectRgb(string hex, int r, int g, int b)
            {
                var result = ColorConverter.HexToRgb(hex);
                Assert.Equal((r, g, b), result);
            }

            [Theory]
            [InlineData("FFFFFF")]
            [InlineData("#ZZZZZZ")]
            [InlineData("#123")]
            public void HexToRgb_InvalidHex_ThrowsException(string hex)
            {
                Assert.Throws<ArgumentException>(() => ColorConverter.HexToRgb(hex));
            }

            [Fact]
            public void RgbToHsl_WhiteColor_ReturnsExpectedHsl()
            {
                var result = ColorConverter.RgbToHsl(255, 255, 255);
                Assert.Equal((0.0, 0.0, 100.0), result);
            }
        }
    }
}
