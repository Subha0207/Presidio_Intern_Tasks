using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblemApplication
{
    public class LeetCodeProblem2
    {
        public async Task<string> ConvertToExcel(int columnNumber)
        {
            string letters = string.Empty;

            int q = columnNumber;
            int r = 0;
            while (q > 0)
            {
                r = q % 26;
                q = q / 26;
                letters = AppendCharacter(letters, r);
                if (r == 0)
                    q = q - 1;
            }

            return letters;
        }

        private string AppendCharacter(string previousLetters, int r)
        {
            string newLetter;
            if (r == 0)
                newLetter = $"{((char)90)}{previousLetters}"; //If number is a multiple of 26, we add 'Z' at the end
            else
                newLetter = $"{(char)(64 + r)}{previousLetters}";

            return newLetter;
        }

        public async void GetExcelValues()
        {
            Console.WriteLine("Enter your Number : ");
            int ColumnNumber = Convert.ToInt32(Console.ReadLine());
            string result = await ConvertToExcel(ColumnNumber);
            Console.WriteLine("The Result is :" + result);
        }
        public static void Main(string[] args)
        {
            LeetCodeProblem2 program = new LeetCodeProblem2();
            program.GetExcelValues();
        }
    }
}
