namespace BasicControlFlowStatements
{
    internal class Program
    {
        void UnderstandingArrays()
        {
            int[] numbers = { 200, 666, 960, 777, 665, 681 };
            int countOfRepeatingNumbers = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int firstNumber, secondNumber, thirdNumber;
                firstNumber = numbers[i] / 100;

                secondNumber = (numbers[i] / 10) % 10;
                thirdNumber = numbers[i] % 10;

                if (firstNumber == secondNumber && secondNumber == thirdNumber)
                    countOfRepeatingNumbers++;
            }
            Console.WriteLine("The number of repeating numbers is " + countOfRepeatingNumbers);

        }
        void UnderstandingSequenceStatments()
        {
            int num1, num2;
            num1 = 100;
            num2 = 20;
            int num3 = num1 / num2;
            Console.WriteLine($"The result of {num1} divided by {num2} is {num3}");
        }
        void UnderstandingForLoops()
        {
            Console.WriteLine("Understanding for loop");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Hello" + i);
            }

        }
        void UnderstandingDoWhileLoops()
        {
            int count = -1;
            do
            {
                Console.WriteLine("In Do while the value is  " + count);
                Console.WriteLine("Please enter the number");
                count = Convert.ToInt32(Console.ReadLine());

            } while (count > 0);
        }
        void UnderstandingWhileLoops()
        {
            Console.WriteLine("Understanding while loop");
            int count = 10;
            while (count > 0)
            {
                count--;
                if (count == 7)
                    continue;
                Console.WriteLine("The value of count is " + count);
                if (count == 4)
                    break;

            }
        }
        void UnderstandingIf()
        {
            string str = "Ramu";
            if (str == "Ramu")
            {
                Console.WriteLine("Welcome Ramu");
            }
            else if (str == "Somu")
            {
                Console.WriteLine("You have basic access");
            }
            else
            {
                Console.WriteLine("You are not allowed");
            }
        }
        void UnderstandingSwitchCase()
        {
            Console.WriteLine("Please enter a number for day");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("Try again");
                    break;
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.UnderstandingSequenceStatments();
            program.UnderstandingIf();
            program.UnderstandingSwitchCase();
            program.UnderstandingForLoops();
            program.UnderstandingWhileLoops();
            program.UnderstandingDoWhileLoops();
            program.UnderstandingArrays();
        }

    }
}
