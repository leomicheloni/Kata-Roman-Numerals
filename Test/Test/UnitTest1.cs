using System;
using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        // Symbol    Value
        // I            1
        // V            5
        // X            10
        // L            50
        // C            100
        // D            500
        // M            1000
        
        // - Generally, symbols are placed in order of value,
        //     - Starting with the largest values
        //     - When smaller values precede larger values, the smaller values are subtracted
        //         from the larger values, and the result is added to the total
        
        // - A number written in Arabic numerals can be broken into digits.
        // - For example, 1903 is composed of 1 (one thousand), 9 (nine hundreds), 0 (zero tens),
        // and 3 (three units).
        // - To write the Roman numeral, each of the non-zero digits should be treated separately.
        // - In the above example, 1,000 = M, 900 = CM, and 3 = III. Therefore, 1903 = MCMIII.
        // - The symbols I, X, C, and M can be repeated three times in succession, but no more.
        // (They may appear more than three times if they appear non-sequentially, such as XXXIX)
        //     D, L, and V. can never be repeated.
        //     I can be subtracted from V and X only.
        //     X can be subtracted from L and C only.
        //     C can be subtracted from D and M only.
        //     V, L, and D can never be subtracted.
        //     Only one small-value symbol may be subtracted from any large-value symbol.
        
        [Fact]
        public void ArabicToRoman_With_Number_1_Returns_I()
        {
            string expectedRomanNumber = "I";
            
            Assert.Equal(expectedRomanNumber, ArabicToRoman(1));
        }
        
        [Fact]
        public void ArabicToRoman_With_Number_3_Returns_III()
        {
            string expectedRomanNumber = "III";
            
            Assert.Equal(expectedRomanNumber, ArabicToRoman(3));
        }
        
        [Fact]
        public void ArabicToRoman_With_Number_4_Returns_IV()
        {
            string expectedRomanNumber = "IV";
            
            Assert.Equal(expectedRomanNumber, ArabicToRoman(4));
        }
        
        [Fact]
        public void ArabicToRoman_With_Number_5_Returns_V()
        {
            string expectedRomanNumber = "V";
            
            Assert.Equal(expectedRomanNumber, ArabicToRoman(5));
        }
        
        [Fact]
        public void ArabicToRoman_With_Number_8_Returns_VIII()
        {
            string expectedRomanNumber = "VIII";
            
            Assert.Equal(expectedRomanNumber, ArabicToRoman(8));
        }
        
        [Fact]
        public void ArabicToRoman_With_Number_9_Returns_IX()
        {
            string expectedRomanNumber = "IX";
            
            Assert.Equal(expectedRomanNumber, ArabicToRoman(9));
        }
        
        [Fact]
        public void ArabicToRoman_With_Number_10_Returns_X()
        {
            string expectedRomanNumber = "X";
            
            Assert.Equal(expectedRomanNumber, ArabicToRoman(10));
        }
        
        [Fact]
        public void ArabicToRoman_With_Number_11_Returns_XI()
        {
            string expectedRomanNumber = "XI";
            
            Assert.Equal(expectedRomanNumber, ArabicToRoman(11));
        }
        
        [Fact]
        public void ArabicToRoman_With_Number_15_Returns_XV()
        {
            string expectedRomanNumber = "XV";
            
            Assert.Equal(expectedRomanNumber, ArabicToRoman(15));
        }
        
        [Fact]
        public void ArabicToRoman_With_Number_19_Returns_XIX()
        {
            string expectedRomanNumber = "XIX";
            
            Assert.Equal(expectedRomanNumber, ArabicToRoman(19));
        }
        
        [Fact]
        public void ArabicToRoman_With_Number_20_Returns_XX()
        {
            string expectedRomanNumber = "XX";
            
            Assert.Equal(expectedRomanNumber, ArabicToRoman(20));
        }
        
        [Fact]
        public void ArabicToRoman_With_Number_90_Returns_XC()
        {
            string expectedRomanNumber = "XC";
            
            Assert.Equal(expectedRomanNumber, ArabicToRoman(90));
        }
        
        [Fact]
        public void ArabicToRoman_With_Number_100_Returns_C()
        {
            string expectedRomanNumber = "C";
            
            Assert.Equal(expectedRomanNumber, ArabicToRoman(100));
        }
        
        [Fact]
        public void ArabicToRoman_With_Number_111_Returns_CXI()
        {
            string expectedRomanNumber = "CXI";
            
            Assert.Equal(expectedRomanNumber, ArabicToRoman(111));
        }
        
        [Fact]
        public void ArabicToRoman_With_Number_500_Returns_D()
        {
            string expectedRomanNumber = "D";
            
            Assert.Equal(expectedRomanNumber, ArabicToRoman(500));
        }
        
        [Fact]
        public void ArabicToRoman_With_Number_999_Returns_CMXCIX()
        {
            string expectedRomanNumber = "CMXCIX";
            
            Assert.Equal(expectedRomanNumber, ArabicToRoman(999));
        }
        
        [Fact]
        public void ArabicToRoman_With_Number_3999_Returns_MMMCMXCIX()
        {
            string expectedRomanNumber = "MMMCMXCIX";
            
            Assert.Equal(expectedRomanNumber, ArabicToRoman(3999));
        }

        private string ArabicToRoman(int number)
        {
            int[] digits = GetDigits(number);
            var thousandsToRoman = Convert(digits[0], new []{'M'});
            var hundredsToRoman = Convert(digits[1], new char[] {'C', 'D', 'M'});
            var tensToRoman = Convert(digits[2], new char[] {'X', 'L', 'C'});
            var unitsToRoman = Convert(digits[3], new char[] {'I', 'V', 'X'});
            return thousandsToRoman + hundredsToRoman + tensToRoman + unitsToRoman;
        }

        private static string ConvertUnits(int units)
        {
            if (units >= 1 && units <= 3)
                return new string('I', units);

            if (units == 4)
                return "IV";
            
            if (units >= 5 && units <= 8)
                return "V" + new string('I', units - 5);
            
            if (units == 9)
                return "IX";

            return string.Empty;
        }

        private static string ConvertTens(int tens)
        {
            int units = tens / 10;
            if (units >= 1 && units <= 3)
                return new string('X', units);

            if (units == 4)
                return "XL";
            
            if (units >= 5 && units <= 8)
                return "X" + new string('L', units - 5);
            
            if (units == 9)
                return "XC";

            return string.Empty;
        }
        
        private static string ConvertHundreds(int hundreds)
        {
            int units = hundreds / 100;
            if (units >= 1 && units <= 3)
                return new string('C', units);

            if (units == 4)
                return "CD";
            
            if (units >= 5 && units <= 8)
                return "D" + new string('C', units - 5);
            
            if (units == 9)
                return "CM";

            return string.Empty;
        }
        
        private static string Convert(int digit, char[]romanLetters)
        {
            if (digit >= 1 && digit <= 3)
                return new string(romanLetters[0], digit);

            if (digit == 4)
                return char.ToString(romanLetters[0]) + char.ToString(romanLetters[1]);
            
            if (digit >= 5 && digit <= 8)
                return romanLetters[1] + new string(romanLetters[0], digit - 5);
            
            if (digit == 9)
                return char.ToString(romanLetters[0]) + char.ToString(romanLetters[2]);

            return string.Empty;
        }

        private static int[] GetDigits(int number)
        {
            int thousands = (number / 1000) * 1000;
            number -= thousands;
            int hundreds = (number / 100) * 100;
            number -= hundreds;
            int tens = (number/10) * 10;
            number -= tens;
            int units = number;

            return new [] {thousands/1000, hundreds/100, tens/10, units};
        }

        private static string ConvertThousands(int thousands)
        {
            int units = thousands / 1000;
            if (units >= 1 && units <= 3)
                return new string('M', units);
            
            return string.Empty;
        }
    }
}