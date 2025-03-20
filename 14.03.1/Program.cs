using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int currentPlayer;
        static bool isGameOver = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe!");
            Console.WriteLine("You are 'X', the computer is 'O'.");

            Random random = new Random();
            currentPlayer = random.Next(2) + 1;

            while (!isGameOver)
            {
                Console.Clear();
                DisplayBoard();
                if (currentPlayer == 1)
                {
                    UserMove();
                }
                else
                {
                    ComputerMove();
                }
                CheckGameStatus();
                SwitchPlayer();
            }
        }

        static void DisplayBoard()
        {
            Console.WriteLine("Player 1 (X) - Player 2 (O)\n");
            Console.WriteLine(" {0} | {1} | {2} ", board[1], board[2], board[3]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[4], board[5], board[6]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[7], board[8], board[9]);
            Console.WriteLine();
        }

        static void UserMove()
        {
            int move;
            Console.WriteLine("Your turn! Enter a number between 1 and 9 to place your 'X': ");
            while (!int.TryParse(Console.ReadLine(), out move) || move < 1 || move > 9 || board[move] == 'X' || board[move] == 'O')
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
            board[move] = 'X';
        }

        static void ComputerMove()
        {
            Random random = new Random();
            int move;
            do
            {
                move = random.Next(1, 10);
            } while (board[move] == 'X' || board[move] == 'O');
            Console.WriteLine($"Computer placed 'O' at position {move}");
            board[move] = 'O';
        }

        static void CheckGameStatus()
        {
            if (CheckWinner('X'))
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine("You win!");
                isGameOver = true;
            }
            else if (CheckWinner('O'))
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine("Computer wins!");
                isGameOver = true;
            }
            else if (Array.IndexOf(board, '1') == -1 && Array.IndexOf(board, '2') == -1 && Array.IndexOf(board, '3') == -1 && Array.IndexOf(board, '4') == -1 && Array.IndexOf(board, '5') == -1 && Array.IndexOf(board, '6') == -1 && Array.IndexOf(board, '7') == -1 && Array.IndexOf(board, '8') == -1 && Array.IndexOf(board, '9') == -1)
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine("It's a draw!");
                isGameOver = true;
            }
        }

        static bool CheckWinner(char symbol)
        {
            return (board[1] == symbol && board[2] == symbol && board[3] == symbol) ||
                   (board[4] == symbol && board[5] == symbol && board[6] == symbol) ||
                   (board[7] == symbol && board[8] == symbol && board[9] == symbol) ||
                   (board[1] == symbol && board[4] == symbol && board[7] == symbol) ||
                   (board[2] == symbol && board[5] == symbol && board[8] == symbol) ||
                   (board[3] == symbol && board[6] == symbol && board[9] == symbol) ||
                   (board[1] == symbol && board[5] == symbol && board[9] == symbol) ||
                   (board[3] == symbol && board[5] == symbol && board[7] == symbol);
        }

        static void SwitchPlayer()
        {
            currentPlayer = currentPlayer == 1 ? 2 : 1;
        }
    }
}
