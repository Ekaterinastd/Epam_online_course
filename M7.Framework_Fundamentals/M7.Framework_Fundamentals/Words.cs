using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7.Framework_Fundamentals
{
    public class Words
    {
        public static string ReverseWords(string input)
        {
            var listOfWords = input.Split().ToList();
            listOfWords.Reverse();
            var result = new StringBuilder();
            foreach (var el in listOfWords)
                result.Append(el + " ");
            result.Remove(result.Length - 1,1);
            return result.ToString();
        }
    }
}
