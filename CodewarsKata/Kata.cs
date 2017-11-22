using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
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
        public static long FindNextSquare(long num) => Sqrt(num) % 1 == 0 ? (long)Pow(Sqrt(num) + 1, 2) : -1;

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
            var number = string.Join("", numbers);
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
            var tripleNumber = num1.ToString().GroupBy(i => i).Where(j => j.Count() == 3).Select(k => k.Key).DefaultIfEmpty(' ').FirstOrDefault();
            if (tripleNumber == ' ' || !Regex.IsMatch(num1.ToString(), "(.)\\1{" + (3 - 1) + "}"))
            {
                return 0;
            }
            else
            {
                return num2.ToString().GroupBy(i => i).Where(j => j.Count() == 2).Select(k => k.Key).DefaultIfEmpty(' ').Contains(tripleNumber) ? 1 : 0;
            }
            // return "0123456789".Count(number => num1.ToString().Contains(new string(number, 3)) && num2.ToString().Contains(new string(number, 2)));
        }

        /// <summary>
        /// Count the number of Smileys
        /// </summary>
        /// <param name="smileys"></param>
        /// <returns></returns>
        public static int CountSmileys(string[] smileys)
        {
            List<char> chars = new List<char>() { ':', ';', '-', '~', ')', 'D' };
            return smileys.Count(i => i.Where(k => !chars.Contains(k)).Count() == 0);
            //return smileys.Count(s => Regex.IsMatch(s, @"^[:;]{1}[~-]{0,1}[\)D]{1}$"));
        }

        /// <summary>
        /// Is Number a Prime
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (number % 2 == 0) return (number == 2);
            int root = (int)Math.Sqrt((double)number);
            for (int i = 3; i <= root; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;

            // LINQ
            /*
            if (a <= 1) return false;
            if (a <= 3) return true;

            return !Enumerable.Range(2, (int)(Math.Sqrt(a))).Where(divisor => a % divisor == 0).Any();
            */
        }

        /// <summary>
        /// Find a number whose count is Odd Number
        /// </summary>
        /// <param name="seq"></param>
        /// <returns></returns>
        public static int FindTheOddInt(int[] seq)
        {
            return seq.GroupBy(i => i).Where(k => k.Count() >= 1 && (k.Count() % 2) != 0).FirstOrDefault().Key;
        }

        /// <summary>
        /// Find out whether a number is Narcissistic or not.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Narcissistic(int value)
        {
            return value.ToString().Select(n => Pow(char.GetNumericValue(n), value.ToString().Length)).Sum() == value;
        }

        /// <summary>
        /// Line Tickets
        /// </summary>
        /// <param name="peopleInLine"></param>
        /// <returns></returns>
        public static string Tickets(int[] peopleInLine)
        {
            Dictionary<int, int> wallet = new Dictionary<int, int>() { { 25, 0 }, { 50, 0 }, { 100, 0 } };
            int i = 0;
            bool result = true;


            while (result && i < peopleInLine.Count())
            {
                var curPayment = peopleInLine[i++];

                int moneyBack = curPayment - 25;

                while (moneyBack > 0 && result)
                {
                    var tempResult = wallet.Where(el => el.Value > 0)
                        .OrderByDescending(el => el.Key)
                        .FirstOrDefault(el => moneyBack % el.Key == 0);

                    result = tempResult.Key != 0;
                    if (result)
                    {
                        wallet[tempResult.Key]--;
                        moneyBack -= tempResult.Key;
                    }
                }

                wallet[curPayment] = wallet[curPayment] + 1;
            }

            return result ? "YES" : "NO";
        }

        /// <summary>
        /// Persistence Persistant Bugger
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Persistence(long n)
        {
            int count = 0;
            while (n > 9)
            {
                n = Convert.ToInt64(n.ToString().Select(c => Char.GetNumericValue(c)).Aggregate((a, b) => a * b));
                count++;
            }
            return count;
        }

        /// <summary>
        /// List of squares of Divisors
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string listSquared(long m, long n)
        {
            StringBuilder strBuild = new StringBuilder();
            strBuild.Append("[");
            for(long i=m;i <= n; i++)
            {
                List<int> numbers = new List<int>();
                for(int j = 1; j <= i; j++)
                {
                    if(i % j == 0)
                    {
                        numbers.Add(j);
                    }
                }

                if(numbers.Count > 0)
                {
                    var sum = numbers.Select(num => num * num).Sum();
                    if(Sqrt(sum) % 1 == 0)
                    {
                        strBuild.Append($"[{i},{sum}]");
                    }
                }
            }
            strBuild.Append("]");
            return strBuild.ToString().TrimEnd(',');
        }

        /// <summary>
        /// RegularSlideDown
        /// </summary>
        /// <param name="pyramid"></param>
        /// <returns></returns>
        public static int RegularSlideDown(int[][] pyramid)
        {
            return pyramid.Select(i => Array.IndexOf(pyramid, i) > 1 ? i[Array.IndexOf(pyramid, i) - 1] : i[0]).Sum();
        }
        /// <summary>
        /// Longest Slide Down
        /// </summary>
        /// <param name="pyramid"></param>
        /// <returns></returns>
        public static int LongestSlideDown(int[][] pyramid)
        {
            return pyramid.Reverse().Aggregate((prev, next) =>
            {
                return next.Select((x, i) => x + Math.Max(prev[i], prev[i + 1])).ToArray();
            }).First();
        }

        /// <summary>
        /// Is an number is Special
        /// </summary>
        /// <param name="number"></param>
        /// <param name="awesomePhrases"></param>
        /// <returns></returns>
        public static int IsInteresting(int number, List<int> awesomePhrases)
        {
            var listOfDigits = number.ToString().Select(i => int.Parse(i.ToString()));
            if (IsNumberSpecial(number) || awesomePhrases.Contains(number))
            {
                return 2;
            }
            else if(awesomePhrases.Contains(number + 1) || awesomePhrases.Contains(number + 2) || IsNumberSpecial(number+1) || IsNumberSpecial(number+2))
            {
                return 1;
            }
            return 0;
        }

        private static bool IsNumberSpecial(int number)
        {
            var listOfDigits = number.ToString().Select(i => int.Parse(i.ToString()));
            var isSequenceEqual =listOfDigits.Count() > 2 && ( listOfDigits.Last() == 0 ? Enumerable.Range(listOfDigits.Take(listOfDigits.Count() - 1).Min(), listOfDigits.Take(listOfDigits.Count() - 1).Count())
                              .SequenceEqual(listOfDigits.Take(listOfDigits.Count() - 1)) : Enumerable.Range(listOfDigits.Min(), listOfDigits.Count())
                              .SequenceEqual(listOfDigits));
            return listOfDigits.Count() > 1 && (Enumerable
                .SequenceEqual(listOfDigits, listOfDigits
                .Reverse()) || isSequenceEqual || listOfDigits.Skip(1).Select((v, i) => v == (listOfDigits.ToArray()[i] - 1)).All(v => v) || listOfDigits.Skip(1).Select((v, i) => v == listOfDigits.ToArray()[i]).All(v => v) || (number >= 100 && number.ToString().TrimEnd('0').Length == 1));
                              
        }

        /// <summary>
        /// Moves all zeros to last
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] MoveZeroes(int[] arr)
        {
            return arr.Where(i => i != 0).Concat(arr.Where(i => i == 0)).ToArray();
        }

        /// <summary>
        /// ROT13
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string Rot13(string message)
        {
            return string.Join("", message.Select(c =>
            {
                if (char.IsLetter(c))
                {
                    if (char.IsUpper(c))
                    {
                        var num = c + 13;
                        return num > 90 ? num - 90 + 66 : num;
                    }
                    else
                    {
                        var num = c + 13;
                        return num > 122 ? num - 122 + 98 : num;
                    }
                }
                else
                {
                    return c;
                }
            }).Select(k => (char)k));
        }

        /// <summary>
        /// RGB to Hex
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string Rgb(int r, int g, int b)
        {
            return LimitValue(r) + LimitValue(g) + LimitValue(b);
        }

        private static string LimitValue(int r)
        {
            if (r > 255) r = 255;
            if (r < 0) r = 0;
            return r.ToString("X2");
        }

        /// <summary>
        /// Base Conversion
        /// </summary>
        /// <param name="input"></param>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string ConvertFromOnetoOne(string input, string source, string target)
        {
            var ibase = source.Length;
            var val = input.Reverse()
              .Select(c => source.IndexOf(c))
              .Select((d, i) => d * (long)Math.Pow(ibase, i))
              .Sum();
            if (val == 0) return target[0].ToString();
            var obase = target.Length;
            var res = new List<int>();
            while (val > 0)
            {
                val = DivRem(val, obase, out long rem);
                res.Add((int)rem);
            }
            return String.Concat(res.Select(d => target[d]).Reverse());
        }

        /// <summary>
        /// Who is Next
        /// </summary>
        /// <param name="names"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string WhoIsNext(string[] names,int n)
        {
            var l = names.Length;
            return n <= l ? names[n - 1] : WhoIsNext(names, (n - l + 1) / 2);
        }

        /// <summary>
        /// Sum of Two Strings as numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string SumStrings(string a, string b)
        {
            if (string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b))
            {
                return null;
            }
            a = string.IsNullOrEmpty(a) ? "0" : a;
            b = string.IsNullOrEmpty(b) ? "0" : b;
            return (BigInteger.Parse(a) + BigInteger.Parse(b)).ToString();
        }

        /// <summary>
        /// Gap in Prime Numbers Prime Gap
        /// </summary>
        /// <param name="g"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long[] Gap(int g, long m, long n)
        {
            long[] p = new long[2];
            for(long i=m;i <=n; i++)
            {
                if (IsPrime((int)i))
                {
                    p[0] = p[1];
                    p[1] = i;
                    if (p[1] - p[0] == g) return p;
                }
            }
            return p;
        }

    }

}
