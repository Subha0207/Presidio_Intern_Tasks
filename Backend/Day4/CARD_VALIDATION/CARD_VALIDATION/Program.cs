using System;
using System.Diagnostics;

namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:");
            string input = Console.ReadLine();

            // Input validation
            if (input.Length > 15)
            {
                Console.WriteLine("Invalid input. Please enter a number not exceeding 15 digits.");
                return;
            }

            char[] inputArray = input.ToCharArray();
            int n = input.Length;
            char[] reverse = new char[n];

            for (int i = 0; i < n; i++)
            {
                reverse[i] = inputArray[n - 1 - i];
            }

            int totalSum = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(reverse[i].ToString());
                if ((i + 1) % 2 == 0)
                {
                    int evenPositionNumber = num * 2;
                    int evenSum = 0;
                    if (evenPositionNumber > 9)
                    {
                        while (evenPositionNumber != 0)
                        {
                            evenSum += evenPositionNumber % 10;
                            evenPositionNumber /= 10;
                        }
                    }
                    else
                    {
                        evenSum = evenPositionNumber;
                    }
                    totalSum += evenSum;
                }
                else
                {
                    totalSum += num;
                }
            }
            Console.WriteLine(totalSum);
            if (totalSum % 10 == 0)
            {
                Console.WriteLine("Valid number");
            }
            else
            {
                Console.WriteLine("Not a Valid number");
            }
        }
    }
}