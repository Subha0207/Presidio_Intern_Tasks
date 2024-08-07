﻿namespace CODING_QUESTIONS_C_
{
    internal class Program   
    {
        static void Main(string[] args)
        {
            //Question 1
            //Create a application that take 2 numbers and find its sum, product and divide the first by second, also supract the second from the first. 
            //Include another method to find the remainder when the first number is divided by second

            Console.WriteLine("Enter number 1:");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter number 2:");
            int num2 = Convert.ToInt32(Console.ReadLine());

            PerformOperations(num1, num2);

            //Question 2
            //create an application that will find the greatest of the given numbers. Take input until the user enters a negative number

            int input1;
            int max = int.MinValue;
            Console.WriteLine("Enter a number (enter a negative number to stop):");
            while ((input1 = Convert.ToInt32(Console.ReadLine())) >= 0)
            {
                if (input1 > max)
                {
                    max = input1;
                }
                Console.WriteLine("Enter another number (enter a negative number to stop):");

            }
            Console.WriteLine($"The greatest number entered was: {max}");
            //Question 3
            //Find the avearage of all the numbers that are divisible by 7. Take input until the user enters a negative number

            int input2;
            int totalsum = 0;
            int counter = 0;
            while ((input2 = Convert.ToInt32(Console.ReadLine())) >= 0)
            {
                if (input2 % 7 == 0)
                {
                    totalsum += input2;
                    counter++;
                }

                Console.WriteLine($"The average is:{totalsum / counter}");

            }

            if (counter > 0)
            {
                double average = (double)totalsum / counter;
                Console.WriteLine($"The average of numbers divisible by 7 is: {average}");
            }
            else
            {
                Console.WriteLine("No numbers divisible by 7 were entered.");
            }
            //Question 4
            //Find the length of the given user's name

            Console.WriteLine("Enter your name");
            string user = Console.ReadLine();
            int length = user.Length;
            Console.WriteLine($"The length of your name is: {length}");
            //Question 5
            //Create a application that will take username and password from user. check if username is "ABC" and passwod is "123". 
            //Print error message if username or password is wrong
            //Allow user 3 attemts.
            // After 3rd attempt if user enters invalid credentials then print msg to intimate user taht he / she has exceeded the number of attempts and stop
            int count = 0;
            while (count < 3)
            {
                Console.WriteLine("Enter your name:");
                string username = Console.ReadLine();

                Console.WriteLine("Enter your Password:");
                string password = Console.ReadLine();

                if (username != "ABC" && password != "123")
                {
                    Console.WriteLine("Username and Password are incorrect");
                    count++;
                }
                else if (username != "ABC")
                {
                    Console.WriteLine("Username is incorrect");
                    count++;
                }
                else if (password != "123")
                {
                    Console.WriteLine("Password is incorrect");
                    count++;
                }
                else
                {
                    Console.WriteLine("Access granted, WELCOME");
                    break;
                }
                if (count == 3)
                {
                    Console.WriteLine("You have exceeded maximum number of attempts and stop");
                }

            }
            //Question 6
            //Take a string from user the words seperated by comma(","). Seperate the words and find the words with the least number of repeating vowels. print the count and the word. If there is a tie then print all the words that tie for the least

            Console.WriteLine("Enter words separated by comma:");
            string input = Console.ReadLine();
            string[] words = input.Split(',');

            int minVowelCount = int.MaxValue;
            var wordsWithLeastVowels = new System.Collections.Generic.List<string>();

            foreach (var word in words)
            {
                int vowelCount = word.Count(c => "aeiouAEIOU".Contains(c));
                if (vowelCount < minVowelCount)
                {
                    minVowelCount = vowelCount;
                    wordsWithLeastVowels.Clear();
                    wordsWithLeastVowels.Add(word);
                }
                else if (vowelCount == minVowelCount)
                {
                    wordsWithLeastVowels.Add(word);
                }
            }

            Console.WriteLine($"Words with the least number of repeating vowels ({minVowelCount}): {string.Join(", ", wordsWithLeastVowels)}");
        }


        static void PerformOperations(int num1, int num2)
        {
            int sum = num1 + num2;
            Console.WriteLine($"The sum is: {sum}");

            int product = num1 * num2;
            Console.WriteLine($"The product is: {product}");

            if (num2 != 0)
            {
                int division = num1 / num2;
                Console.WriteLine($"The division of num1 and num2 is: {division}");

                int remainder = num1 % num2;
                Console.WriteLine($"The remainder is: {remainder}");
            }
            else
            {
                Console.WriteLine("Cannot divide by zero or find remainder");
            }

            int diff = num1 - num2;
            Console.WriteLine($"The difference of num1 and num2 is: {diff}");

        }
    }
}
