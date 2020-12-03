using System;
using System.Text.RegularExpressions;

namespace Day02
{
    class Program
    {
        static bool CheckPasswordValidationCounter(string password, char charToInclude, int minOccurences, int maxOccurences)
        {
            int countOfOccurences = Regex.Matches(password, charToInclude.ToString()).Count;

            return countOfOccurences >= minOccurences && countOfOccurences <= maxOccurences;
        }

        static bool CheckPasswordValidationOnPositions(string password, char charToInclude, int firstIndex, int secondIndex)
        {
            if (secondIndex >= password.Length)
            {
                return password[firstIndex] == charToInclude;
            }

            if (firstIndex < 0)
            {
                return password[secondIndex] == charToInclude;
            }

            return (password[firstIndex] == charToInclude) ^ (password[secondIndex] == charToInclude);
        }

        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"input.txt");

            int numberOfValidPasswordsPartOne = 0;
            int numberOfValidPasswordsPartTwo = 0;

            foreach (string line in lines)
            {
                string[] splittedLine = line.Split(":");
                string[] conditions = splittedLine[0].Split(" ");
                string password = splittedLine[1].Trim();

                char substringToInclude = conditions[1][0];
                string[] range = conditions[0].Split("-");

                int minNumber = Int32.Parse(range[0]);
                int maxNumber = Int32.Parse(range[1]);

                numberOfValidPasswordsPartOne += CheckPasswordValidationCounter(password, substringToInclude, minNumber, maxNumber) 
                                                                ? 1 
                                                                : 0;
                numberOfValidPasswordsPartTwo += CheckPasswordValidationOnPositions(password, substringToInclude, minNumber - 1, maxNumber - 1) 
                                                                ? 1 
                                                                : 0;
            }

            Console.WriteLine("Part One: " + numberOfValidPasswordsPartOne);
            Console.WriteLine("Part Two: " + numberOfValidPasswordsPartTwo);

            return;
        }
    }
}
