using System;
using RiddleSolve.Model;

namespace RiddleSolve.Calculation
{
    public static class Printer
    {
        public static void Print(RotatedTile[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);
            
            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                    Console.Write($"  {board[row, column].Top.ToShortString()}  ");
                
                Console.WriteLine();
                for (var column = 0; column < columns; column++)
                    Console.Write($"{board[row, column].Left.ToShortString()}  " +
                                  $"{board[row, column].Right.ToShortString()}");
                
                Console.WriteLine();
                for (var column = 0; column < columns; column++)
                    Console.Write($"  {board[row, column].Bottom.ToShortString()}  ");
                
                Console.WriteLine();
            }
        }
    }
}