using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        int low = GetPositiveNumber("Enter the low number: ");
        int high;
        do
        {
            high = GetPositiveNumber("Enter the high number (greater than low): ");
        } while (high <= low);

        Console.WriteLine($"Difference between low and high: {high - low}");

        int[] numbers = GenerateNumbersArray(low, high);
        WriteNumbersToFile(numbers, "numbers.txt");

        int sum = ReadNumbersFromFileAndCalculateSum("numbers.txt");
        Console.WriteLine($"Sum of numbers: {sum}");

        List<double> numbersList = GenerateNumbersList(low, high);
        PrintPrimeNumbers(numbersList);
    }

    static int GetPositiveNumber(string prompt)
    {
        int number;
        do
        {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out number) || number <= 0);
        return number;
    }

    static int[] GenerateNumbersArray(int low, int high)
    {
        int[] numbers = new int[high - low + 1];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = high - i;
        }
        return numbers;
    }

    static void WriteNumbersToFile(int[] numbers, string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (int number in numbers)
            {
                writer.WriteLine(number);
            }
        }
    }

    static int ReadNumbersFromFileAndCalculateSum(string fileName)
    {
        int sum = 0;
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                sum += int.Parse(line);
            }
        }
        return sum;
    }

    static List<double> GenerateNumbersList(int low, int high)
    {
        List<double> numbers = new List<double>();
        for (double i = high; i >= low; i--)
        {
            numbers.Add(i);
        }
        return numbers;
    }

    static void PrintPrimeNumbers(List<double> numbers)
    {
        Console.WriteLine("Prime numbers between low and high:");
        foreach (double number in numbers)
        {
            if (IsPrime(number))
            {
                Console.Write($"{number} ");
            }
        }
        Console.WriteLine();
    }

    static bool IsPrime(double number)
    {
        if (number <= 1)
            return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
}
