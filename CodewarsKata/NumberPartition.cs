using System;
using System.Collections.Generic;
using System.Linq;

namespace CodewarsKata
{
    public static class NumberPartition
    {
        private static Dictionary<long, List<List<long>>> cache = new Dictionary<long, List<List<long>>>();
        /// <summary>
        /// enum(n) prod(n) Median  Integer Partitions
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string Part(long n)
        {
            
            var numbersArray = Split(n).Select(i => i.Aggregate((a, b) => (a * b))).Distinct().OrderBy(i => i);
           
            return $"Range: {numbersArray.Max() - numbersArray.Min()} Average: {numbersArray.Average().ToString("F")} Median: {numbersArray.Median().ToString("F")}";
        }

        public static List<List<long>> Split(long n)
        {
            if (cache.ContainsKey(n))
                return cache[n];

            var list = new List<List<long>>();

            for (long i = n; i > 0; i--)
            {
                if (i == n)
                {
                    var sublist = new List<long>();
                    sublist.Add(i);
                    list.Add(sublist);
                    continue;
                }

                foreach (var resultList in Split(n - i))
                {
                    if (resultList.First() > i)
                        continue;

                    var sublist = new List<long>();
                    sublist.Add(i);
                    sublist.AddRange(resultList);

                    list.Add(sublist);
                }
            }

            if (!cache.ContainsKey(n))
                cache.Add(n, list);

            return list;
        }

        private static double Median<T>(this IEnumerable<T> numbers) where T:struct
        {
            int numberCount = numbers.Count();
            int halfIndex = numbers.Count() / 2;
            var sortedNumbers = numbers.OrderBy(n => n);
            double median;
            if ((numberCount % 2) == 0)
            {
                median = (Convert.ToDouble(sortedNumbers.ElementAt(halfIndex)) +
                    Convert.ToDouble(sortedNumbers.ElementAt(halfIndex - 1))) / 2;
            }
            else
            {
                median = Convert.ToDouble(sortedNumbers.ElementAt(halfIndex));
            }
            return median;
        }
    }
}
