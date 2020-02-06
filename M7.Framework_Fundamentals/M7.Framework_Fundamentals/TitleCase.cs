using System.Text;

namespace M7.Framework_Fundamentals
{
    public static class TitleCase
    {
        public static string GetTitle(string input, string minorWords = "")
        {
            var inputWords = input.Split();
            var minorWordsLowCase = minorWords.ToLower();
            var result = new StringBuilder();
            var wordInLowCase = "";
            var firstWord = true;
            foreach (var word in inputWords)
            {
                wordInLowCase = word.ToLower();
                if (word == inputWords[0] && firstWord)
                {
                    result.Append(FirstLetterToUpper(wordInLowCase) + " ");
                    firstWord = false;
                }
                else if (!minorWordsLowCase.Contains(wordInLowCase))
                    result.Append(FirstLetterToUpper(wordInLowCase) + " ");
                else result.Append(wordInLowCase + " ");
            }
            return result.ToString().TrimEnd();
        }

        private static string FirstLetterToUpper(string str)
        {
            if (str.Length > 0)
                return char.ToUpper(str[0]) + str.Substring(1);
            return "";
        }
    }
}
