using System.Windows;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using RiddleSolve.Model;
using static RiddleSolve.Model.RotatedTile;

namespace RiddleSolve.ViewModel
{
    public class RotatedImageViewModel : ViewModelBase
    {
        private bool _isShowedSolved;
        public bool IsShowedSolved
        {
            get => _isShowedSolved;
            set => Set(ref _isShowedSolved, value);
        }
        
        public Thickness FromPosition { get; }
        public Thickness ToPosition { get; }
        
        public BitmapSource BitmapSource { get; }
        public double Angle { get; }

        public RotatedImageViewModel(BitmapSource bitmapSource, RotatedTile rotation,
            double fromLeft, double fromTop, double toLeft, double toTop)
        {
            FromPosition = new Thickness(fromLeft, fromTop, 0, 0);
            ToPosition = new Thickness(toLeft, toTop, 0, 0);
            
            BitmapSource = bitmapSource;
            Angle = GetAngle(rotation);
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