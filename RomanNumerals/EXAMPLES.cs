
using System;

namespace RomanNumerals
{
    class EXAMPLES
    {
        static void Main()
        {

            RomanNumeral R1 = new RomanNumeral(3999);
            Console.WriteLine($"\n {R1.Number} = {R1.Roman}");

            
            RomanNumeral R2 = new RomanNumeral("MMMcMxcix");
            Console.WriteLine(  $" {R2.Number} = {R2.Roman}");


            RomanNumeral R3 = new RomanNumeral(4999);
            Console.WriteLine($"\n {R3.Number} = {R3.Roman}");

            
            RomanNumeral R4 = new RomanNumeral("IVcMxcix");
            Console.WriteLine(  $" {R4.Number} = {R4.Roman}\n");


            foreach(var romanLetter in RomanNumeral.LettersValues)
            {
                Console.WriteLine($" {romanLetter.Key} = {romanLetter.Value}");
            }


            Console.WriteLine($"\n MIN roman value = {RomanNumeral.MIN_VALUE}");
            Console.WriteLine(  $" MAX roman value = {RomanNumeral.MAX_VALUE}");


            //for(int i = RomanNumeral.MIN_VALUE; i < RomanNumeral.MAX_VALUE+1; i++)
            //{
            //	string roman = RomanNumeral.NumberToRoman(i);
            //	if(RomanNumeral.RomanToNumber(roman) != i)
            //		Console.WriteLine($"[ERROR] > Number {i}");
            //}


            Console.WriteLine("\n Press any key to exit ");
            Console.ReadKey();

        }
    }
}
