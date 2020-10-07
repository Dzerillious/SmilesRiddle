using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace RiddleSolve.ViewModel
{
    public class ResultViewModel : ViewModelBase
    {
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

        public ResultViewModel(int width, int height, RotatedImageViewModel[] images)
        {
            Width = width;
            Height = height;
            Images = images;
            ToggleDisplaySolvedCommand = new RelayCommand(() => IsDisplayedSolved = !IsDisplayedSolved);
        }
    }
}