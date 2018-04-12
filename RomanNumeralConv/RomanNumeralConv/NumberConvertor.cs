using System;
namespace RomanNumeralConv
{
    public class NumberConvertor
    {
        static int MAX = 10; 
        static string []romanNumeral= new string[]{ "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };

        public static string ToRomanNumeral(int i)
        {
            string result = "Error";

            if (i <= MAX)
                result = romanNumeral[i];
            return result;
        }

        public static int ToDecimalNumber(string c)
        {
            int result = 0;
            for (int i = 0; i < MAX; i++)
            {
                if (romanNumeral[i] == c)
                    result = i + 1;
            }

            return result;
        }
    }
}
