using Questions_Programs;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("App started!");
        Console.WriteLine("Enter the input string");
        string inputString = Console.ReadLine();

        Questions questions = new Questions();
        questions.ReverseStringWithoutInbuild(inputString);
        questions.ReverseStringInplace(inputString);
        questions.IsPalindromeString(inputString);
        questions.IsAnagramStringUsingSort(inputString, "nama");
        questions.RemoveDuplicateCharacters(inputString);
    }
}