using Questions_Programs;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("App started!");
        Console.WriteLine("Enter the input string");
        string? inputString = Console.ReadLine();

        Questions questions = new Questions();
        questions.ReverseStringWithoutInbuild(inputString);
        questions.ReverseStringInplace(inputString);
        questions.IsPalindromeString(inputString);
        questions.IsAnagramStringUsingSort(inputString, "nama");
        questions.RemoveDuplicateCharacters(inputString);
        questions.RemoveDuplicateCharactersUsingLinq(inputString);
        questions.FirstNonRepeatingCharacter(inputString);
        questions.FirstNonRepeatingCharacterUsingLinq(inputString);
        questions.CountVowelsAndConsonants(inputString);
        questions.CountVowelsAndConsonantsUsingLinq(inputString);
        questions.CountWordsInString(inputString);
        questions.CountEachCharacterInString(inputString);
        questions.CountEachCharacterInStringUsingLinq(inputString);
    }
}