//Use the code in this class to prove that the SplitMix64 PRNG implemented is 
//indeed correct and intractaable as described in Task 2 of the Assignment Brief

using System;
using System.Diagnostics;
using DSA___A2___Part_Soution;
class Program

{
    static void Main(string[] args)
    {
        SplitMix64 prng = new SplitMix64();
        List<ulong> randomNumbers = new List<ulong>();

        for (int i = 0; i < 100; i++)
        {
            ulong number = prng.Next(1, 1000);
            randomNumbers.Add(number);
        }


        bool allInRange = randomNumbers.All(n => n >= 1 && n <= 1000);

        bool isAscending = randomNumbers.SequenceEqual(randomNumbers.OrderBy(n => n));

        bool isDescending = randomNumbers.SequenceEqual(randomNumbers.OrderByDescending(n => n));

        Console.WriteLine("Generated 100 random numbers:");
        Console.WriteLine(string.Join(", ", randomNumbers));

        Console.WriteLine("\nValidation Results:");
        Console.WriteLine($"All numbers in range [1, 1000]: {allInRange}");
        Console.WriteLine($"List is sorted in ascending order: {isAscending}");
        Console.WriteLine($"List is sorted in descending order: {isDescending}");


        SplitMix64 rng = new SplitMix64();
        int[] testSizes = { 1000, 10000, 100000, 1000000 };

        foreach (int size in testSizes)
        {
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < size; i++)
            {
                ulong randomNumber = rng.Next(1, 1000); 
            }

            sw.Stop();

            double elapsedMs = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
            Console.WriteLine($"Generated {size,10} random numbers in {elapsedMs,10:F4} ms");

        }
    }
}


