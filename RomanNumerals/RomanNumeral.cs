
/// ================================================================================================================ ///

    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

/// ================================================================================================================ ///

namespace RomanNumerals
{
    class RomanNumeral
    {
    /// ==================================================== ///


        public static Dictionary<char,int> LettersValues { get; } = new Dictionary<char, int>()
        {
            { 'i',       1 }, { 'v',      5 },
            { 'x',      10 }, { 'l',     50 },
            { 'c',     100 }, { 'd',    500 },
            { 'M',    1000 }, { 'V',   5000 },
            { 'X',   10000 }, { 'L',  50000 },
            { 'C',  100000 }, { 'D', 500000 },
            { 'W', 1000000 }
        };


        public static int MIN_VALUE { get; } = LettersValues.Values.First();
        public static int MAX_VALUE { get; } = LettersValues.Values.Last();


        public static Regex Regex_Roman { get; } = new Regex(@"^((CW|CD|D?C{0,3})(XC|XL|L?X{0,3})((IX|IV|V?I{0,3})|(M{0,3}))(cM|cd|d?c{0,3})(xc|xl|l?x{0,3})(ix|iv|v?i{0,3})|W)$");


    /// ==================================================== ///


        private int n;
        public int Number { get { return n; } set
        {
            r = NumberToRoman(value);
            n = value;
        }}


        private string r;
        public string Roman { get { return r; } set
        {
            n = RomanToNumber(value);
            r = value;
        }}


    /// ==================================================== ///


        public RomanNumeral(in int number)
        {
            Roman = NumberToRoman(number);
        }


        public RomanNumeral(in string roman)
        {
            Number = RomanToNumber(roman);
        }
        

    /// ==================================================== ///
    

        public static void ValidateNumber(in int number)
        {
            if(number < MIN_VALUE || number > MAX_VALUE)
                throw new ArgumentOutOfRangeException($"The number must be between {MIN_VALUE} and {MAX_VALUE} (both included)");
        }


        public static void ValidateRoman(in string roman)
        {
            if(!Regex_Roman.IsMatch(roman))
                throw new ArgumentOutOfRangeException("The pattern of the roman numeral does not follow the 'RomanRegex' regular expression");
        }


    /// ==================================================== ///


        public static string NumberToRoman(in int number)
        {
            ValidateNumber(in number);

            if(number == MAX_VALUE)
                return LettersValues.Keys.Last().ToString();

            string roman = "";
            List<char> letters = LettersValues.Keys.ToList();
            string[] pattern = {"","A","AA","AAA","AE","E","EA","EAA","EAAA","AU"};

            for(int i = (int)Math.Log10(number); i > -1; i--)
            {
                roman += pattern[number/(int)Math.Pow(10,i)%10]
                         .Replace('A', letters[i*2])
                         .Replace('E', letters[i*2+1])
                         .Replace('U', letters[(i+1)*2]);
            }

            return
                number > 3999
                ? roman
                  .Replace("MV","IV")
                  .Replace("VMMM","VIII")
                  .Replace("VMM","VII")
                  .Replace("VM","VI")
                  .Replace("MX","IX")
                : roman;
        }


    /// ==================================================== ///


        public static int RomanToNumber(in string roman)
        {
            ValidateRoman(in roman);

            if(roman == LettersValues.Keys.Last().ToString())
                return MAX_VALUE;

            int number = 0;
            string _roman = roman.Replace("IV","MV").Replace("VIII","VMMM").Replace("VII","VMM").Replace("VI","VM").Replace("IX","MX");

            List<char> letters = LettersValues.Keys.ToList();

            for (int i = 0; i < LettersValues.Count/2; i++)
            {
                string pattern = @"(AU|AE|E?A{0,3})$"
                                 .Replace('A', letters[i*2])	  // I
                                 .Replace('E', letters[i*2+1])    // V
                                 .Replace('U', letters[(i+1)*2]); // X

                MatchCollection matches = new Regex(pattern).Matches(_roman);

                if(matches.Count == 1) continue;

                string part = matches[0].Value;

                if(part == $"{letters[i*2]}{letters[i*2+1]}") // IV
                {
                    number += LettersValues[letters[i*2+1]] - LettersValues[letters[i*2]];
                }					
                else if(part == $"{letters[i*2]}{letters[(i+1)*2]}") // IX
                {
                    number += LettersValues[letters[(i+1)*2]] - LettersValues[letters[i*2]];
                }
                else // I, II, III, V, VI, VII, VIII
                {
                    number += part.Count(c => c == letters[i*2]) * LettersValues[letters[i*2]];
                    number += part.Contains(letters[i*2+1]) ? LettersValues[letters[i*2+1]] : 0;
                }

                _roman = _roman.Replace(part, "");

                if(_roman == "") break;
            }

            return number;
        }


    /// ==================================================== ///

        // TODO: DecomposeRoman

        //public static string DecomposeRoman(in string roman)
        //{
        //	return "";
        //}

        // TODO: ComposeRoman

        //public static string ComposeRoman(in string roman)
        //{
        //	return "";
        //}


    /// ==================================================== ///
    
        // TODO: NumberToRomanDecomposed

        //public static string NumberToRomanDecomposed(in int number)
        //{
        //	ValidateNumber(in number);

        //	if(number == LettersValues.Values.Last())
        //		return LettersValues.Keys.Last().ToString();

        //	string roman = "";
        //	List<char> letters = new List<char>(LettersValues.Keys);
        //	string[] pattern = {"","A-","AA-","AAA-","AE-","E-","EA-","EAA-","EAAA-","AU-"};

        //	for(int i = (int)Math.Log10(number); i > -1; i--)
        //		roman += pattern[number/(uint)Math.Pow(10,i)%10].Replace('A', letters[i*2]).Replace('E', letters[i*2+1]).Replace('U', letters[(i+1)*2]);

        //	return roman.Remove(roman.Length - 1);
        //}


    /// ==================================================== ///
    }
}

/// ================================================================================================================ ///
