using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions_Programs
{
    public class Questions
    {
        public void ReverseStringWithoutInbuild(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString)) { Console.WriteLine(inputString); }
            string result = GetReverseString(inputString);
            Console.WriteLine($"This is the revers string : {result}");
        }

        private string GetReverseString(string inputString)
        {
            if (inputString == null || inputString.Length == 0)
            {
                return string.Empty;
            }
            return GetReverseString(inputString.Substring(1)) + inputString[0];
        }

        public void ReverseStringInplace(string inputString)
        {
            var splitedString = inputString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //var result = string.Join(" ", splitedString.Select(x => GetReverseString(x)).ToArray());
            var result = string.Join(" ", splitedString.Select(x => new string(x.Reverse().ToArray())).ToArray());
            Console.WriteLine($"Reverse Inplace String : {result}");
        }

        public void IsPalindromeString(string inputString)
        {
            int midOfString = Math.Abs(inputString.Length / 2);
            if (!string.IsNullOrWhiteSpace(inputString) && !string.IsNullOrEmpty(inputString))
            {
                for (int i = 0; i < midOfString; i++)
                {
                    if (inputString[i] != inputString[^(i + 1)])
                    {
                        Console.WriteLine($"{inputString} is not a palindrome");
                    }
                }
            }
            Console.WriteLine($"{inputString} is a palindrome");
        }

        public void IsAnagramString(string firstString, string secondString)
        {
            if (string.IsNullOrWhiteSpace(firstString) || string.IsNullOrWhiteSpace(secondString))
            {
                Console.WriteLine("One or both strings are null or empty.");
                return;
            }

            var firstCharCount = firstString.ToLower().GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            var secondCharCount = secondString.ToLower().GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

            bool isAnagram = firstCharCount.Count == secondCharCount.Count &&
                             firstCharCount.All(kvp => secondCharCount.TryGetValue(kvp.Key, out int count) && count == kvp.Value);

            Console.WriteLine(isAnagram ? $"{firstString} and {secondString} are anagrams." : $"{firstString} and {secondString} are not anagrams.");
        }

        public void IsAnagramStringUsingSort(string firstString, string secondString)
        {
            if (string.IsNullOrWhiteSpace(firstString) || string.IsNullOrWhiteSpace(secondString))
            {
                Console.WriteLine("One or both strings are null or empty.");
                return;
            }

            var sortedFirst = string.Concat(firstString.ToLower().OrderBy(c => c));
            var sortedSecond = string.Concat(secondString.ToLower().OrderBy(c => c));

            bool isAnagram = sortedFirst == sortedSecond;
            Console.WriteLine(isAnagram ? $"{firstString} and {secondString} are anagrams." : $"{firstString} and {secondString} are not anagrams.");
        }

        public void IsAnagram(string firstString, string secondString)
        {
            if (string.IsNullOrWhiteSpace(firstString) || string.IsNullOrWhiteSpace(secondString))
            {
                Console.WriteLine("One or both strings are null or empty.");
                return;
            }

            Dictionary<char, int> firstCharCount = firstString.ToLower().GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            Dictionary<char, int> secondCharCount = secondString.ToLower().GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

            foreach (var kvp in firstCharCount)
            {
                if (!secondCharCount.TryGetValue(kvp.Key, out int count) || count != kvp.Value)
                {
                    Console.WriteLine($"{firstString} and {secondString} are not anagrams.");
                    return;
                }
            }
            Console.WriteLine($"{firstString} and {secondString} are anagrams.");
        }

        public void RemoveDuplicateCharacters(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Input string is null or empty.");
                return;
            }

            HashSet<char> seenChars = new HashSet<char>();
            StringBuilder result = new StringBuilder();

            foreach (char c in inputString)
            {
                if (seenChars.Add(c)) // Add returns false if the character is already present
                {
                    result.Append(c);
                }
            }

            Console.WriteLine($"String after removing duplicates: {result.ToString()}");
        }

        public void RemoveDuplicateCharactersUsingLinq(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Input string is null or empty.");
                return;
            }

            var result = new string(inputString.Distinct().ToArray());
            Console.WriteLine($"String after removing duplicates using LINQ: {result}");
        }
    }
}
