namespace SudokuValide
{
    public class Program
    {
        const int sudokuSize = 9;
        const int innerSudokuSize = 3;
        string userInputString = "";
        int[,] userInputArray = new int[sudokuSize, sudokuSize];
        int rowNumber = 0;
        string[] wordsUserInput;
        bool isCompleteSudokuValide = true;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.GetUserData();
            program.ValidateCompleteSudoku();
        }

        //Get user data row by row
        public void GetUserData()
        {
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
                    if (str != "." && str != " ")
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
        }

        //validate the complete sudoku 9*9
        public void ValidateCompleteSudoku()
        {
            List<int> isInnerSudokuValidList = new List<int>();
            bool isValide;
            int startingIndexColumn = 0, startingIndexRow = 0;
            for (int i = 0; i < sudokuSize; i++)
            {
                if(i == 0)
                {
                    startingIndexColumn = 0;
                    startingIndexRow = 0;
                }
                else if (i == 1)
                {
                    startingIndexColumn = 0;
                    startingIndexRow = 3;
                }
                else if (i == 2)
                {
                    startingIndexColumn = 0;
                    startingIndexRow = 6;
                }
                else if (i == 3)
                {
                    startingIndexColumn = 3;
                    startingIndexRow = 0;
                }
                else if (i == 4)
                {
                    startingIndexColumn = 3;
                    startingIndexRow = 3;
                }
                else if (i == 5)
                {
                    startingIndexColumn = 3;
                    startingIndexRow = 6;
                }
                else if (i == 6)
                {
                    startingIndexColumn = 6;
                    startingIndexRow = 0;
                }
                else if (i == 7)
                {
                    startingIndexColumn = 6;
                    startingIndexRow = 3;
                }
                else if (i == 8)
                {
                    startingIndexColumn = 6;
                    startingIndexRow = 6;
                }

                isValide = ValidateInnerSudoku(startingIndexColumn, startingIndexRow);
                if(ValidateInnerSudoku(startingIndexColumn, startingIndexRow))
                    isInnerSudokuValidList.Add(1);
                else
                    isInnerSudokuValidList.Add(0);
            }

            foreach (int i in isInnerSudokuValidList){
                if (i == 0)
                { 
                    isCompleteSudokuValide = false;
                    break;
                }

            }
            if(isCompleteSudokuValide &&
                   ValidateRowWise() && ValidateColumnWise())
                Console.WriteLine("Given sudoku is valid");
            else
                Console.WriteLine("Given sudoku is not valid");
        }

        //Validate inner grids 3*3
        public bool ValidateInnerSudoku(int startingIndexColumn = 0, int startingIndexRow = 0, int tmpSudokuSize = 3, int byColumnOrRow = 0)
        {
            List<int> innerSudokuGridList = new List<int>();
            List<int> tmpInnerSudokuGridList = new List<int>();
            bool isValide = true;
            for (int j = startingIndexColumn; j < tmpSudokuSize; j++)
            {
                for (int k = startingIndexRow; k < tmpSudokuSize; k++)
                {
                    if(byColumnOrRow == 1) //Column = 1, Row = 2, Grid = 0
                    {
                        if (userInputArray[k, j] != 0)
                            innerSudokuGridList.Add(userInputArray[k, j]);
                    }
                    else
                    {
                        if (userInputArray[j, k] != 0)
                            innerSudokuGridList.Add(userInputArray[j, k]);
                    }                    
                }
                if (byColumnOrRow == 2 || byColumnOrRow == 1) //Column = 1, Row = 2, Grid = 0
                {
                    tmpInnerSudokuGridList = innerSudokuGridList.Distinct().ToList();
                    isValide = tmpInnerSudokuGridList.Count == innerSudokuGridList.Count ? true : false;
                    if (isValide == false)
                        break;
                    else
                    {
                        tmpInnerSudokuGridList.Clear();
                        innerSudokuGridList.Clear() ;
                    }
                }
            }

            if (byColumnOrRow == 0) //Column = 1, Row = 2, Grid = 0
            {
                tmpInnerSudokuGridList = innerSudokuGridList.Distinct().ToList();
                isValide = tmpInnerSudokuGridList.Count == innerSudokuGridList.Count ? true : false;
            }
            
            return isValide;
        }

        //Validate row by row
        public bool ValidateRowWise()
        {
            bool isRowValide;
            isRowValide = ValidateInnerSudoku(0, 0, 9, 2);
            return isRowValide;
        }

        //Validate colum by column
        public bool ValidateColumnWise()
        {
            bool isColumnValide;
            isColumnValide = ValidateInnerSudoku(0, 0, 9, 1);
            return isColumnValide;
        }

        //Display user entered sudoku the format 9*9
        public void DisplaySudoku()
        {
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
