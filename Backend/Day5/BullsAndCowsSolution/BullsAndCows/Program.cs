namespace BullsAndCows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string targetWord = "golf";
            string guessWord;
            int cows, bulls;

            while (true)
            {
                Console.Write("Enter your guess: ");
                guessWord = Console.ReadLine();

                if (guessWord.Length != 4)
                {
                    Console.WriteLine("Please enter a 4-letter word.");
                    continue;
                }

                cows = bulls = 0;

                for (int i = 0; i < 4; i++)
                {
                    if (guessWord[i] == targetWord[i])
                    {
                        cows++;
                    }
                    else
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (i != j && guessWord[i] == targetWord[j])
                            {
                                bulls++;
                                break;
                            }
                        }
                    }
                }

                if (cows == 4)
                {
                    Console.WriteLine($"Cows: {cows}, Bulls: {bulls}");
                    Console.WriteLine("Congrats!!! You won!!!!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Cows: {cows}, Bulls: {bulls}");
                }
            }
        }
    }
}
