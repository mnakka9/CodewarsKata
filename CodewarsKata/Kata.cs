using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        /// <summary>
        /// Duplicate Encode ()
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string DuplicateEncode(string word) =>
            new string(word.ToLower().Select(ch => word.ToLower().Count(innerCh => ch == innerCh) == 1 ? '(' : ')').ToArray());


        public static IEnumerable<string> OpenOrSenior(int[][] data)
        {
            return data.Count() > 0 ? data.Select(i => i[0] > 54 && i[1] > 7 ? "Senior" : "Open") : new List<string>();
        }

        /// <summary>
        /// Which are In Array
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public static string[] inArray(string[] array1, string[] array2)
        {
            return array1.Count() > 0 ? 
                array1
                .Select(elem => array2.Any(inp => inp.Contains(elem)) ? elem : null)
                .Where(i => i != null).
                OrderBy(k => k).
                ToArray() 
                : new string[0];
        }

        /// <summary>
        /// Given the triangle of consecutive odd numbers:
        ///             1
        ///          3     5
        ///       7     9    11
        ///   13    15    17    19
        ///21    23    25    27    29
        ///...
        ///Calculate the row sums of this triangle from the row index (starting at index 1) e.g.:        
        ///rowSumOddNumbers(1); // 1
        ///rowSumOddNumbers(2); // 3 + 5 = 8
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long RowSumOddNumbers(long n)
        {
            return (long)Pow(n, 3);
        }

        /// <summary>
        /// First Non Repeating Character
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FirstNonRepeatingLetter(string s)
        {
            return (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s)) ? string.Empty : 
                Convert.ToString(s.
                GroupBy(c => Char.ToLowerInvariant(c)).
                Where(j => j.Count() == 1)
                .FirstOrDefault()
                ?.FirstOrDefault());
        }

        /// <summary>
        /// create a phone number for array
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static string CreatePhoneNumber(int[] numbers)
        {
            var number = string.Join("",numbers);
            return string.Format("({0}) {1}-{2}", number.Substring(0, 3), number.Substring(3, 3), number.Substring(6, 3));
        }

        /// <summary>
        /// Triple Double
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static int TripleDouble(long num1, long num2)
        {
            var tripleNumber = num1.ToString().GroupBy(i => i).Where(j => j.Count() == 3 ).Select(k => k.Key).DefaultIfEmpty(' ').FirstOrDefault();
            if(tripleNumber == ' ' || !Regex.IsMatch(num1.ToString(), "(.)\\1{" + (3 - 1) + "}"))
            {
                return 0;
            }
            else
            {
                return num2.ToString().GroupBy(i => i).Where(j => j.Count() == 2).Select(k => k.Key).DefaultIfEmpty(' ').Contains(tripleNumber) ? 1 : 0;
            }
            // return "0123456789".Count(number => num1.ToString().Contains(new string(number, 3)) && num2.ToString().Contains(new string(number, 2)));
        }
    }
}
