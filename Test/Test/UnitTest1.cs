using Xunit;

namespace Test
{
    public class UnitTest1
    {

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
            int[] digits = SplitNumberIntoDigits(number);
            return GetRomanSymbolsForDigit(digits[0], new []{'M'}) + 
                   GetRomanSymbolsForDigit(digits[1], new char[] {'C', 'D', 'M'}) + 
                   GetRomanSymbolsForDigit(digits[2], new char[] {'X', 'L', 'C'}) + 
                   GetRomanSymbolsForDigit(digits[3], new char[] {'I', 'V', 'X'});
        }

        private static string GetRomanSymbolsForDigit(int digit, char[]romanLetters)
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

        private static int[] SplitNumberIntoDigits(int number)
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

    }
}