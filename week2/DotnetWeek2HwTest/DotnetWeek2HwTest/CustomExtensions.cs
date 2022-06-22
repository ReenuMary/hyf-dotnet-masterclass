using System;
namespace DotnetWeek2HwTest
{
	public static class CustomExtensions
	{
        public static int score(this string myString)
        {
            int score = 0;

            char[] letters = myString.ToCharArray();
            foreach (char letter in letters)
            {
                int value = (int)Char.ToUpper(letter);
                if(value>=65 && value<=90 )
                {
                    
                    score += value-64;
                }
            }
            return score;
        }
    }
}

