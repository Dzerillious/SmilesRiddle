using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RiddleSolve.Calculation;
using RiddleSolve.Model;

namespace RiddleSolve.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public bool HasSolution { get; }

        private bool _isDisplayedSolved;
        public bool IsDisplayedSolved
        {
            get => _isDisplayedSolved;
            set
            {
                Set(ref _isDisplayedSolved, value);
                foreach (RotatedImageViewModel image in Images)
                    image.IsDisplayedSolved = value;
            }
        }

        public int Width { get; }
        public int Height { get; }
        
        public RelayCommand ToggleDisplaySolvedCommand { get; }
        
        public RotatedImageViewModel[] Images { get; }

        public MainWindowViewModel()
        {
            ToggleDisplaySolvedCommand = new RelayCommand(() => IsDisplayedSolved = !IsDisplayedSolved);
            
            var bitmapImage = Loader.GetBitmap();
            Color[] pixels = Loader.GetPixels(bitmapImage);
            ITile[,] board = TileParser.ParseTiles(pixels, bitmapImage.PixelWidth, bitmapImage.PixelHeight);
            Analysis analysis = Analyser.Analyze(board);
            var result = new ITile[board.GetLength(0), board.GetLength(1)];
            
            Width = board.GetLength(0) * Constants.TileSize;
            Height = board.GetLength(1) * Constants.TileSize;

            if (Solver.Solve(result, analysis, (0, 0)))
            {
                HasSolution = true;
                Images = GetImageViewModels(bitmapImage, result);
            }
            else
            {
                HasSolution = false;
                Images = GetImageViewModels(bitmapImage, board);
            }
        }

        public static RotatedImageViewModel[] GetImageViewModels(BitmapImage bitmapImage, ITile[,] board)
        {
            var rotatedImages = new List<RotatedImageViewModel>();
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);

            for (var row = 0; row < rows; row++)
            for (var column = 0; column < columns; column++)
            {
                var tile = board[row, column];
                (int unsolvedY, int unsolvedX) = tile.TilePosition * Constants.TileSize;
                (int solvedY, int solvedX) = new Position(row, column) * Constants.TileSize;
                var bitmap = new CroppedBitmap(bitmapImage, new Int32Rect(unsolvedX + 1, unsolvedY + 1,
                                                                          Constants.TileSize - 1, Constants.TileSize - 1));
                rotatedImages.Add(new RotatedImageViewModel(bitmap, tile, unsolvedX, unsolvedY, solvedX, solvedY));
            }

            return rotatedImages.ToArray();
        }
    }
}