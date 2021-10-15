using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    class Program
    {
        const int BOARD_ROWS = 3;
        const int BOARD_COLUMNS = 3;
        const int MAX_NUMBER_OF_MOVES = BOARD_ROWS * BOARD_COLUMNS;
        const char PLAYER1MARK = 'X';
        const char PLAYER2MARK = 'O';

        static void Main(string[] args)
        {
            char[,] board = InitBoard();
            bool isFirstPlayerMove = true;
            Console.ForegroundColor = ConsoleColor.Yellow;
            //WriteInColor(Console.ForegroundColor=ConsoleColor.Blue,"X");
            /*Console.ResetColor();
            WriteInColor(Console.ForegroundColor = ConsoleColor.Red, "О");
            Console.ResetColor();*/
            
            for (int i = 0; i < MAX_NUMBER_OF_MOVES; i++)
            {
                char currentPlayerMark = isFirstPlayerMove ? PLAYER1MARK : PLAYER2MARK;
                PrintBoard(board, currentPlayerMark);

                board = AddNextMoveToBoard(board, currentPlayerMark);

                if (CheckForWinningMove(board, currentPlayerMark))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Console.WriteLine($"Player {currentPlayerMark} wins");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }

                if (currentPlayerMark=='X')
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                isFirstPlayerMove = !isFirstPlayerMove;
        }

        static char[,] InitBoard()
        {
            char[,] result = new char[BOARD_ROWS, BOARD_COLUMNS];

            for (int i = 0; i < BOARD_ROWS; i++)
            {
                for (int j = 0; j < BOARD_COLUMNS; j++)
                {
                    result[i, j] = '-';
                }
            }
            return result;

        }
        static char[,] AddNextMoveToBoard(char[,] board, char playerMark)
        {
            int xCoord;
            int yCoord;

            bool isPositionTaken = true;
           
            do
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Please enter a valid X coordinate [0-{BOARD_ROWS - 1}]");
                    xCoord = int.Parse(Console.ReadLine());
                }
                while (xCoord > BOARD_ROWS - 1 || xCoord < 0);

                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"Please enter a valid Y coordinate [0-{BOARD_COLUMNS - 1}]");
                    yCoord = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                while (yCoord > BOARD_COLUMNS - 1 || yCoord < 0);

                if (board[xCoord, yCoord] != '-')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    isPositionTaken = true;
                    Console.WriteLine("These coordinates are already taken");
                }
                else
                {
                    isPositionTaken = false;
                }
            }
            while (isPositionTaken);


            board[xCoord, yCoord] = playerMark;

            return board;
        }

        private static void PrintBoard(char[,] board, char currentPlayerMark)
        {
            Console.Clear();
            char[] numbers = new char[] { '0', '1', '2' };

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(" "+numbers[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < BOARD_ROWS; i++)
            {
                Console.Write(i+" ");
                for (int j = 0; j < BOARD_COLUMNS; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Player {currentPlayerMark} turn");
            Console.WriteLine();
        }
        static void WriteInColor(ConsoleColor color,string textToDisplay)
        {
            Console.WriteLine("Color {0}, text {1}", color, textToDisplay);
        }
        static bool CheckForWinningMove(char[,] board, char playerMark)
        {
            int playerMarkCounter = 0;

            for (int i = 0; i < BOARD_ROWS; i++)
            {
                for (int j = 0; j < BOARD_COLUMNS; j++)
                {
                    if (board[i, j] == playerMark)
                    {
                        playerMarkCounter++;
                    }
                }

                if (playerMarkCounter == BOARD_ROWS)
                {
                    return true;
                }

                playerMarkCounter = 0;
            }

            for (int i = 0; i < BOARD_COLUMNS; i++)
            {
                for (int j = 0; j < BOARD_ROWS; j++)
                {
                    if (board[i, j] == playerMark)
                    {
                        playerMarkCounter++;
                    }
                }

                if (playerMarkCounter == BOARD_COLUMNS)
                {
                    return true;
                }

                playerMarkCounter = 0;
            }

            if (BOARD_ROWS == BOARD_COLUMNS)
            {
                for (int i = 0; i < BOARD_ROWS; i++)
                {
                    if (board[i, i] == playerMark)
                    {
                        playerMarkCounter++;
                    }

                    if (playerMarkCounter == BOARD_COLUMNS)
                    {
                        return true;
                    }

                    playerMarkCounter = 0;

                    if (board[(BOARD_ROWS - 1) - i, i] == playerMark)
                    {
                        playerMarkCounter++;
                    }

                    if (playerMarkCounter == BOARD_COLUMNS)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
