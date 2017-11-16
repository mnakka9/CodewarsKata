using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
