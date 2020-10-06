using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
using RiddleSolve.Model;
using RiddleSolve.ViewModel;

namespace RiddleSolve.Calculation
{
    public static class SolutionDrawer
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
                var bitmap = new CroppedBitmap(bitmapImage, new Int32Rect(tile.Tile.Column * Constants.TileSize + 1, tile.Tile.Row * Constants.TileSize + 1,
                                                                          Constants.TileSize - 1, Constants.TileSize - 1));
                rotatedImages.Add(new RotatedImageViewModel(bitmap, tile,
                                                            tile.Tile.Column * Constants.TileSize, tile.Tile.Row * Constants.TileSize,
                                                            column * Constants.TileSize, row * Constants.TileSize));
            }

            return new ResultViewModel(columns * Constants.TileSize, rows * Constants.TileSize, rotatedImages.ToArray());
        }
    }
}