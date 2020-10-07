using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
using RiddleSolve.Model;
using RiddleSolve.ViewModel;

namespace RiddleSolve.Calculation
{
    public static class ResultComposer
    {
        public static ResultViewModel GetResultViewModel(BitmapImage bitmapImage, RotatedTile[,] board)
        {
            var rotatedImages = new List<RotatedImageViewModel>();
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);

            for (var row = 0; row < rows; row++)
            for (var column = 0; column < columns; column++)
            {
                var tile = board[row, column];
                (int unsolvedX, int unsolvedY) = new Position(tile.Tile.Column, tile.Tile.Row) * Constants.TileSize;
                (int solvedX, int solvedY) = new Position(column, row) * Constants.TileSize;
                var bitmap = new CroppedBitmap(bitmapImage, new Int32Rect(unsolvedX + 1, unsolvedY + 1,
                                                                          Constants.TileSize - 1, Constants.TileSize - 1));
                rotatedImages.Add(new RotatedImageViewModel(bitmap, tile, 
                                                            unsolvedX, unsolvedY, solvedX, solvedY));
            }

            return new ResultViewModel(columns * Constants.TileSize, rows * Constants.TileSize, rotatedImages.ToArray());
        }
    }
}