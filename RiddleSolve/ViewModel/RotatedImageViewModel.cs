using System.Windows;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using RiddleSolve.Model;
using static RiddleSolve.Model.RotatedTile;

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
        
        public Thickness FromPosition { get; }
        public Thickness ToPosition { get; }
        
        public BitmapSource BitmapSource { get; }
        public double Angle { get; }

        public RotatedImageViewModel(BitmapSource bitmapSource, RotatedTile tile,
            double unsolvedX, double unsolvedY, double solvedX, double solvedY)
        {
            FromPosition = new Thickness(unsolvedX, unsolvedY, 0, 0);
            ToPosition = new Thickness(solvedX, solvedY, 0, 0);
            
            BitmapSource = bitmapSource;
            Angle = GetAngle(tile);
        }

        private static double GetAngle(RotatedTile rotatedTile)
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