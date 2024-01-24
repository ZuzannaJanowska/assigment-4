using System;

class Program
{
    static void Main()
    {
        TicTacToeGame ticTacToe = new TicTacToeGame();
        ticTacToe.Play();
    }
}

class TicTacToeGame
{
    private char[,] board;
    private char currentPlayer;

    public TicTacToeGame()
    {
        board = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        currentPlayer = 'X';
    }

    public void Play()
    {
        do
        {
            PrintBoard();
            MakeMove();
        } while (!IsGameOver());

        Console.ReadLine();
    }

    private void PrintBoard()
    {
        Console.Clear();
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                Console.Write(board[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    private void MakeMove()
    {
        bool isValidMove = false;
        do
        {
            Console.WriteLine($"Player {currentPlayer}, enter your move (row and column): ");
            string[] input = Console.ReadLine().Split();

            if (IsValidInput(input, out int row, out int col) && board[row, col] == ' ')
            {
                board[row, col] = currentPlayer;
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                isValidMove = true;
            }
            else
            {
                Console.WriteLine("Invalid move. Try again.");
            }
        } while (!isValidMove);
    }

    private bool IsValidInput(string[] input, out int row, out int col)
    {
        row = col = 0;
        if (input.Length == 2 && int.TryParse(input[0], out row) && int.TryParse(input[1], out col)
            && row >= 0 && row < 3 && col >= 0 && col < 3)
        {
            return true;
        }
        return false;
    }

    private bool IsGameOver()
    {
        if (CheckWinner())
        {
            PrintBoard();
            Console.WriteLine($"Player {currentPlayer} wins!");
            return true;
        }

        if (IsBoardFull())
        {
            PrintBoard();
            Console.WriteLine("It's a tie!");
            return true;
        }

        return false;
    }

    private bool CheckWinner()
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != ' ')
                return true;
            if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != ' ')
                return true;
        }
        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != ' ')
            return true;
        if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != ' ')
            return true;
        return false;
    }

    private bool IsBoardFull()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board[row, col] == ' ')
                {
                    return false;
                }
            }
        }
        return true;
    }
}
