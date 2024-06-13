namespace SudokuValide
{
    public class Program
    {
        static void Main(string[] args)
        {
            const int sudokuSize = 9;
            string userInputString;
            int[,] userInputArray = new int[sudokuSize, sudokuSize];
            int rowNumber = 0;
            string[] wordsUserInput;
            Console.WriteLine("Please enter the elements for the sudoku 9*9 row by row :");
            for (int i = 0; i < sudokuSize; i++)
            {
                rowNumber = i + 1;
                Console.WriteLine("Row " + rowNumber);
                userInputString = Console.ReadLine();
                int j = 0;
                wordsUserInput = userInputString.Split(',');
                foreach (string str in wordsUserInput)
                {
                    if(str != "." && str != " ")
                    {
                        userInputArray[i, j] = Convert.ToInt32(str);
                    }
                    else
                    {
                        userInputArray[i, j] = 0;
                    }
                    j++;
                }
            }

            Console.WriteLine("\nSudoku :");
            for (int j = 0; j < sudokuSize; j++)
            {
                for (int k = 0; k < sudokuSize; k++)
                {
                    Console.Write(" " + userInputArray[j, k] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
