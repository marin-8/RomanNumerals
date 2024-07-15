
using FluentAssertions;
using Xunit;

namespace RomanNumerals.Tests;

public class MinMaxValuesTests
{
	[Fact]
	public void MinNumericValue_Is_1 ()
	{
		RomanNumeral.MinNumericValue.Should().Be(1);
	}

	[Fact]
	public void MinRomanValue_Is_I ()
	{
		RomanNumeral.MinRomanValue.Should().Be("I");
	}

	[Fact]
	public void MaxNumericValue_Is_3999 ()
	{
		RomanNumeral.MaxNumericValue.Should().Be(3999);
	}

	[Fact]
	public void MaxRomanValue_Is_MMMCMXCIX ()
	{
		RomanNumeral.MaxRomanValue.Should().Be("MMMCMXCIX");
	}
}
