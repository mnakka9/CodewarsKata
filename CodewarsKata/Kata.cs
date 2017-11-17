using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Math;

namespace CodewarsKata
{
    public static class Kata
    {
        /// <summary>
        /// YourOrdersPlease
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static string Order(string words)
        {
            if (!string.IsNullOrEmpty(words))
            {
                return String.Join(" ", (from word in words.Split(' ')
                         group word by word into g
                         select new { key = g.FirstOrDefault().Where(Char.IsDigit).FirstOrDefault(), word = g.FirstOrDefault() }).OrderBy(i => i.key).Select(k => k.word));

            }
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string ToJadenCase(this string phrase)
        {
            if (!string.IsNullOrEmpty(phrase))
            {
                return string.Join(" ", phrase.Split(' ').Select(i => i.First().ToString().ToUpperInvariant() + i.Substring(1)));
                //return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(phrase);
            }
            return String.Empty;
        }

        /// <summary>
        /// Find Next Perfect Square
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static long FindNextSquare(long num)
        {
            return Sqrt(num) % 1 == 0 ? (long)Pow(Sqrt(num) + 1, 2) : -1;
        }
    }
}
