

namespace EightQueensSolver
{
    class Program
    {
        static int N = 8; // Number of queens and board size

        static void Main(string[] args)
        {
            List<List<string>> solutions = SolveNQueens();

            Console.WriteLine($"Total distinct solutions: {solutions.Count}");
            Console.WriteLine();

            for (int i = 0; i < solutions.Count; i++)
            {
                Console.WriteLine($"Solution {i + 1}:\n");
                PrintSolution(solutions[i]);
                Console.WriteLine();
            }
        }

        static List<List<string>> SolveNQueens()
        {
            List<List<string>> solutions = new List<List<string>>();
            char[][] board = new char[N][];
            for (int i = 0; i < N; i++)
            {
                board[i] = new char[N];
                for (int j = 0; j < N; j++)
                {
                    board[i][j] = '.';
                }
            }

            SolveNQueensUtil(board, 0, solutions);
            return solutions;
        }

        static void SolveNQueensUtil(char[][] board, int col, List<List<string>> solutions)
        {
            if (col == N)
            {
                solutions.Add(CreateSolution(board));
                return;
            }

            for (int row = 0; row < N; row++)
            {
                if (IsSafe(board, row, col))
                {
                    board[row][col] = 'Q';
                    SolveNQueensUtil(board, col + 1, solutions);
                    board[row][col] = '.';
                }
            }
        }

        static bool IsSafe(char[][] board, int row, int col)
        {
            for (int i = 0; i < col; i++)
            {
                if (board[row][i] == 'Q')
                    return false;

                if (row - i >= 0 && board[row - i][col - i] == 'Q')
                    return false;

                if (row + i < N && board[row + i][col - i] == 'Q')
                    return false;
            }
            return true;
        }

        static List<string> CreateSolution(char[][] board)
        {
            List<string> solution = new List<string>();
            foreach (char[] row in board)
            {
                solution.Add(new string(row));
            }
            return solution;
        }

        static void PrintSolution(List<string> solution)
        {
            foreach (string row in solution)
            {
                Console.WriteLine(row);
            }
        }
    }
}