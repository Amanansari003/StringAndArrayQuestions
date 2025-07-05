using System.Text;

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
                        return;
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

        public void FirstNonRepeatingCharacter(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Input string is null or empty.");
                return;
            }

            Dictionary<char, int> charCount = inputString.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            foreach (var c in inputString)
            {
                if (charCount[c] == 1)
                {
                    Console.WriteLine($"First non-repeating character is : {c}");
                    return;
                }
            }
        }

        public void FirstNonRepeatingCharacterUsingLinq(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Input string is null or empty.");
                return;
            }

            var firstNonRepeating = inputString
                .GroupBy(c => c)
                .Where(g => g.Count() == 1)
                .Select(g => g.Key)
                .FirstOrDefault();

            if (firstNonRepeating != default(char))
            {
                Console.WriteLine($"First non-repeating character using LINQ is : {firstNonRepeating}");
            }
            else
            {
                Console.WriteLine("No non-repeating character found.");
            }
        }

        public void CountVowelsAndConsonants(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Input string is null or empty.");
                return;
            }

            int vowelCount = 0;
            int consonantCount = 0;
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            foreach (char c in inputString)
            {
                if (char.IsLetter(c))
                {
                    if (vowels.Contains(c))
                    {
                        vowelCount++;
                    }
                    else
                    {
                        consonantCount++;
                    }
                }
            }

            Console.WriteLine($"Vowels: {vowelCount}, Consonants: {consonantCount}");
        }

        public void CountVowelsAndConsonantsUsingLinq(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Input string is null or empty.");
                return;
            }

            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            int vowelCount = inputString.Count(c => char.IsLetter(c) && vowels.Contains(c));
            int consonantCount = inputString.Count(c => char.IsLetter(c) && !vowels.Contains(c));

            Console.WriteLine($"Vowels: {vowelCount}, Consonants: {consonantCount}");
        }

        public void CountWordsInString(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Input string is null or empty.");
                return;
            }

            var words = inputString.Split(new[] { ' ', '\t', '\n', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = words.Length;
            Console.WriteLine($"Number of words in the string: {wordCount}");
        }

        public void CountEachCharacterInString(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Input string is null or empty.");
                return;
            }
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in inputString)
            {
                if (char.IsLetter(c))
                {
                    if (charCount.ContainsKey(c))
                    {
                        charCount[c]++;
                    }
                    else
                    {
                        charCount[c] = 1;
                    }
                }
            }

            foreach (var kvp in charCount)
            {
                Console.WriteLine($"Character '{kvp.Key}' occurs {kvp.Value} times.");
            }
        }

        public void CountEachCharacterInStringUsingLinq(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Input string is null or empty.");
                return;
            }

            var charCount = inputString
                .Where(c => char.IsLetter(c))
                .GroupBy(c => c)
                .ToDictionary(g => g.Key, g => g.Count());

            foreach (var kvp in charCount)
            {
                Console.WriteLine($"Character '{kvp.Key} occurs {kvp.Value} times.");
            }
        }

        public void LongestSubstringWithoutRepeatingCharacters(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Input string is null or empty.");
                return;
            }

            int maxLength = 0;
            int start = 0;
            Dictionary<char, int> charIndexMap = new Dictionary<char, int>();

            for (int i = 0; i < inputString.Length; i++)
            {
                if (charIndexMap.ContainsKey(inputString[i]) && charIndexMap[inputString[i]] >= start)
                {
                    start = charIndexMap[inputString[i]] + 1;
                }
                charIndexMap[inputString[i]] = i;
                maxLength = Math.Max(maxLength, i - start + 1);
            }

            Console.WriteLine($"Length of the longest substring without repeating characters: {maxLength}");
        }

        public void ReplaceVowelsFromFirstToLast(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("input string is null or empty.");
                return;
            }

            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            int firstVowelIndex = 0;
            int lastVowelIndex = inputString.Length - 1;

            while (firstVowelIndex < inputString.Length)
            {
                while (firstVowelIndex < inputString.Length && !vowels.Contains(inputString[firstVowelIndex]))
                {
                    firstVowelIndex++;
                }

                while (lastVowelIndex >= 0 && !vowels.Contains(inputString[lastVowelIndex]))
                {
                    lastVowelIndex--;
                }
                if (firstVowelIndex < lastVowelIndex)
                {
                    char temp = inputString[firstVowelIndex];
                    inputString = inputString.Remove(firstVowelIndex, 1).Insert(firstVowelIndex, inputString[lastVowelIndex].ToString());
                    inputString = inputString.Remove(lastVowelIndex, 1).Insert(lastVowelIndex, temp.ToString());
                    firstVowelIndex++;
                    lastVowelIndex--;
                }
                Print($"String after replacing vowels from first to last: {inputString}");
            }


        }

        public void ReverseWordInStringWithoutInbuildMethod(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                Print("Input string is null or empty.");
                return;
            }

            // Initialize StringBuilder for result and current word
            string result = string.Empty;
            string currentWord = string.Empty;
            int stringLength = inputString.Length;
            // Iterate through each character in the input string
            for (int i = 0; i < stringLength; i++)
            {
                char currentChar = inputString[i];
                // If the character is a space, append the current word to result and reset current word

                if (currentChar == ' ')
                {
                    if (currentWord.Length > 0)
                    {
                        result = result + currentWord + " ";
                        currentWord = string.Empty;
                    }
                }
                else
                {
                    // If the character is not a space, add it to the current word
                    currentWord = currentChar + currentWord; ;
                }
            }

            Print($"Reversed words in string without using inbuilt methods: {result + currentWord}");
        }


        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
