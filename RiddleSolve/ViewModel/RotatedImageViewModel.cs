using System.Windows;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using RiddleSolve.Model;
using static RiddleSolve.Model.ITile;

namespace RiddleSolve.ViewModel
{
    public class RotatedImageViewModel : ViewModelBase
    {
        private bool _isDisplayedSolved;
        public bool IsDisplayedSolved
        {
            get => _isDisplayedSolved;
            set => Set(ref _isDisplayedSolved, value);
        }
        
        public double UnsolvedX { get; }
        public double UnsolvedY { get; }
        public double SolvedX { get; }
        public double SolvedY { get; }
        
        public BitmapSource BitmapSource { get; }
        public double Angle { get; }

        public RotatedImageViewModel(BitmapSource bitmapSource, ITile tile,
            double unsolvedX, double unsolvedY, double solvedX, double solvedY)
        {
            UnsolvedX = unsolvedX;
            UnsolvedY = unsolvedY;
            SolvedX = solvedX;
            SolvedY = solvedY;
            
            BitmapSource = bitmapSource;
            Angle = GetAngle(tile);
        }

        private static double GetAngle(ITile rotatedTile)
            => rotatedTile.Rotation switch
            {
                TileRotation.Left  => -90,
                TileRotation.Up    => 0,
                TileRotation.Right => 90,
                TileRotation.Down  => 180,
                _                  => 0,
            };
    }
}