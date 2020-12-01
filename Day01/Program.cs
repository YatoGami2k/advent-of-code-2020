using System;
using System.Collections.Generic;

namespace Day01
{
    class Program
    {
        private static HashSet<int> values = new HashSet<int>();

        private static long SolutionOne()
        {
            foreach (int value in values)
            {
                if (values.Contains(2020 - value))
                {
                    return value * (2020 - value);
                }
            }

            return 0;
        }

        private static long SolutionTwo()
        {
            foreach (int a in values)
            {
                foreach (int b in values)
                {
                    if (values.Contains(2020 - a - b))
                    {
                        return a * b * (2020 - a - b);
                    }
                }
            }
            return 0;
        }

        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"input.txt");

            foreach (string line in lines)
            {
                values.Add(Int32.Parse(line));
            }

            Console.WriteLine($"Part 1: {SolutionOne()}");
            Console.WriteLine($"Part 2: {SolutionTwo()}");

            return;
        }
    }
}
