
using System;

namespace RomanNumerals
{
	public partial class RomanNumeral
		: IComparable<RomanNumeral>, IEquatable<RomanNumeral>
	{
		public ushort NumericValue { get; }
		public string RomanValue { get; }

		public RomanNumeral (ushort numericValue)
		{
			RomanValue = NumericToRoman(numericValue);
			NumericValue = numericValue;
		}

		public RomanNumeral (string romanValue)
		{
			NumericValue = RomanToNumeric(romanValue);
			RomanValue = romanValue;
		}

		public static RomanNumeral operator + (
			RomanNumeral romanNumeralA, RomanNumeral romanNumeralB)
		{
			return new RomanNumeral(
				(ushort)(romanNumeralA.NumericValue + romanNumeralB.NumericValue));
		}

		public static RomanNumeral operator - (
			RomanNumeral romanNumeralA, RomanNumeral romanNumeralB)
		{
			return new RomanNumeral(
				(ushort)(romanNumeralA.NumericValue - romanNumeralB.NumericValue));
		}

		public static RomanNumeral operator * (
			RomanNumeral romanNumeralA, RomanNumeral romanNumeralB)
		{
			return new RomanNumeral(
				(ushort)(romanNumeralA.NumericValue * romanNumeralB.NumericValue));
		}

		public static RomanNumeral operator / (
			RomanNumeral romanNumeralA, RomanNumeral romanNumeralB)
		{
			return new RomanNumeral(
				(ushort)(romanNumeralA.NumericValue / romanNumeralB.NumericValue));
		}

		public static RomanNumeral operator ++ (RomanNumeral romanNumeral)
		{
			return new RomanNumeral((ushort)(romanNumeral.NumericValue + 1));
		}

		public static RomanNumeral operator -- (RomanNumeral romanNumeral)
		{
			return new RomanNumeral((ushort)(romanNumeral.NumericValue - 1));
		}

		public int CompareTo (RomanNumeral other)
		{
			if (other == null)
			{
				return 1;
			}

			return NumericValue.CompareTo(other.NumericValue);
		}

		public bool Equals (RomanNumeral other)
		{
			return NumericValue == other.NumericValue;
		}
	}
}
