
using System;
using System.Text.RegularExpressions;

namespace RomanNumerals
{
	public partial class RomanNumeral
	{
		#region Public

		public const ushort MinNumericValue = 1;
		public const string MinRomanValue = "I";

		public const ushort MaxNumericValue = 3999;
		public const string MaxRomanValue = "MMMCMXCIX";

		public static ushort RomanToNumeric (string romanValue)
		{
			if (romanValue == null)
			{
				throw new ArgumentNullException(
					nameof(romanValue),
					"Value cannot be null.");
			}

			if (!IsValid(romanValue))
			{
				throw new ArgumentException(
					$"'{nameof(romanValue)}' must be a valid roman numeral.",
					nameof(romanValue));
			}

			romanValue = romanValue.ToUpper();

			return _RomanToNumericInternal(romanValue);
		}

		public static string NumericToRoman (ushort numericValue)
		{
			if (!IsValid(numericValue))
			{
				throw new ArgumentException(
					$"'{nameof(numericValue)}' must be between 1 and 3999 (both included).",
					nameof(numericValue));
			}

			return _NumericToRomanInternal(numericValue);
		}

		public static bool TryRomanToNumeric (
			string? possibleRomanValue, out ushort numericValue)
		{
			if (IsValid(possibleRomanValue))
			{
				possibleRomanValue = possibleRomanValue!.ToUpper();
				numericValue = _RomanToNumericInternal(possibleRomanValue);
				return true;
			}

			numericValue = default;
			return false;
		}

		public static bool TryNumericToRoman (
			ushort possibleNumericValue, out string? romanValue)
		{
			if (IsValid(possibleNumericValue))
			{
				romanValue = _NumericToRomanInternal(possibleNumericValue);
				return true;
			}

			romanValue = default;
			return false;
		}

		public static bool IsValid (string? romanValue)
		{
			return
				!string.IsNullOrWhiteSpace(romanValue)
				&& _RegexRomanValue.IsMatch(romanValue);
		}

		public static bool IsValid (ushort numericValue)
		{
			return numericValue > 0 && numericValue < 4000;
		}

		#endregion

		#region Private

		private static readonly Regex _RegexRomanValue =
			new Regex(
				@"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$",
				RegexOptions.Compiled | RegexOptions.IgnoreCase);

		private static readonly int[] _NumericValuesByRomanChar =
			new int[26] { 0, 0, 100, 500, 0, 0, 0, 0, 1, 0, 0, 50, 1000, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 10, 0, 0 };

		private static readonly string[] _Thousands =
			{ "", "M", "MM", "MMM" };

		private static readonly string[] _Hundreds =
			{ "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };

		private static readonly string[] _Tens =
			{ "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };

		private static readonly string[] _Ones =
			{ "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

		private static ushort _RomanToNumericInternal (string romanValue)
		{
			var numericValue = 0;
			var previousValue = 0;

			for (var i = romanValue.Length - 1; i >= 0; i--)
			{
				var currentValue = _NumericValuesByRomanChar[romanValue[i] - 'A'];

				if (currentValue >= previousValue)
				{
					numericValue += currentValue;
				}
				else
				{
					numericValue -= currentValue;
				}

				previousValue = currentValue;
			}

			return (ushort)numericValue;
		}

		private static string _NumericToRomanInternal (ushort numericValue)
		{
			return
				_Thousands[numericValue / 1000]
				+ _Hundreds[(numericValue % 1000) / 100]
				+ _Tens[(numericValue % 100) / 10]
				+ _Ones[numericValue % 10];
		}

		#endregion
	}
}
