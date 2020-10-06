using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace RiddleSolve.ViewModel
{
    public class ResultViewModel : ViewModelBase
    {
        private bool _isShowedSolved;
        public bool IsShowedSolved
        {
            get => _isShowedSolved;
            set => Set(ref _isShowedSolved, value);
        }
        
        public int Width { get; }
        public int Height { get; }
        
        public RotatedImageViewModel[] Images { get; }

        public ResultViewModel(int width, int height, RotatedImageViewModel[] images)
        {
            Width = width;
            Height = height;
            Images = images;
        }
    }
}