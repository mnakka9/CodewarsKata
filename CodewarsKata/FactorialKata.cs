using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CodewarsKata
{
    public class FactorialKata
    {
        public static string Factorial(int n)
        {
           return Enumerable.Range(1, n)
                .Select(x => BigInteger.Parse(x.ToString()))
                .Aggregate((prev, next) => prev * next)
                .ToString();
        }

        public static string FactorialNormal(int n)
        {
            if (n % 1 != 0 || n < 0)
            {
                return null;
            }
            else if (n == 0 || n == 1)
            {
                return "1";
            }
            else
            {
                char[] prevAns = Factorial(n - 1).ToCharArray();
                IEnumerable<int> digitsMultiplied = prevAns.Select(x => (n * (x - '0')));
                List<int> digits = new List<int>();

                foreach (int element in digitsMultiplied)
                {
                    digits.Add(element);
                }

                for (int index = digits.Count() - 1; index > 0; index--)
                {
                    digits[index - 1] += (digits[index] / 10);
                    digits[index] %= 10;
                }
                StringBuilder answer = new StringBuilder();
                for (int index = 0; index < digits.Count(); index++)
                {
                    answer.Append(digits[index].ToString());
                }
                return answer.ToString();
            }
        }
    }
}
