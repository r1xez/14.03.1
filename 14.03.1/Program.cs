using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag = 0;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Tic-Tac-Toe");
                Console.WriteLine("Player 1 (X) - Player 2 (O)");
                Console.WriteLine();
                DrawBoard();
                PlayerTurn();
                CheckWin();
            }
            while (flag != 1 && flag != -1);
            if (flag == 1)
                Console.WriteLine("Player " + player + " wins!");
            else
                Console.WriteLine("It's a draw!");
            Console.ReadLine();
        }

        private static void DrawBoard()
        {
            Console.WriteLine(" {0} | {1} | {2} ", board[1], board[2], board[3]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[4], board[5], board[6]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[7], board[8], board[9]);
        }

        private static void PlayerTurn()
        {
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Player " + player + ", choose a number (1-9): ");
                choice = int.Parse(Console.ReadLine());
                if (choice >= 1 && choice <= 9 && board[choice] != 'X' && board[choice] != 'O')
                {
                    board[choice] = player == 1 ? 'X' : 'O';
                    validInput = true;
                    player = (player == 1) ? 2 : 1;
                }
                else
                {
                    Console.WriteLine("Invalid input! Try again.");
                }
            }
        }

        private static void CheckWin()
        {
            if (board[1] == board[2] && board[2] == board[3] ||
                board[4] == board[5] && board[5] == board[6] ||
                board[7] == board[8] && board[8] == board[9] ||
                board[1] == board[4] && board[4] == board[7] ||
                board[2] == board[5] && board[5] == board[8] ||
                board[3] == board[6] && board[6] == board[9] ||
                board[1] == board[5] && board[5] == board[9] ||
                board[3] == board[5] && board[5] == board[7])
            {
                flag = 1;
            }
            else if (Array.IndexOf(board, '1') == -1 && Array.IndexOf(board, '2') == -1 &&
                     Array.IndexOf(board, '3') == -1 && Array.IndexOf(board, '4') == -1 &&
                     Array.IndexOf(board, '5') == -1 && Array.IndexOf(board, '6') == -1 &&
                     Array.IndexOf(board, '7') == -1 && Array.IndexOf(board, '8') == -1 &&
                     Array.IndexOf(board, '9') == -1)
            {
                flag = -1;
            }
        }
    }
}
