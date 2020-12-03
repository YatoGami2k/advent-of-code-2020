using System;

namespace Day03
{
    class Program
    {
        static int treesOnSlope(string[] lines, int slopeX, int slopeY)
        {
            int lineLength = lines[0].Length;

            int x = 0;
            int y = 0;
            int trees = 0;

            while (y < lines.Length)
            {
                trees += lines[y][x] == '#' ? 1 : 0;

                x = (x + slopeX) % lineLength;
                y += slopeY;
            }

            return trees;
        }

        static int solvePartOne(string[] lines)
        {
            return treesOnSlope(lines, 3, 1);
        }

        static long solvePartTwo(string[] lines)
        {
            int totalTrees = 1;

            totalTrees *= treesOnSlope(lines, 1, 1);
            totalTrees *= treesOnSlope(lines, 3, 1);
            totalTrees *= treesOnSlope(lines, 5, 1);
            totalTrees *= treesOnSlope(lines, 7, 1);
            totalTrees *= treesOnSlope(lines, 1, 2);

            return totalTrees;
        }

        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"input.txt");

            Console.WriteLine("Part One: " + solvePartOne(lines));
            Console.WriteLine("Part Two: " + solvePartTwo(lines));
        }
    }
}
