using System.ComponentModel;
using System.Windows;
using RiddleSolve.ViewModel;

namespace RiddleSolve.View
{
    public partial class MovedImageControl
    {
        private RotatedImageViewModel ViewModel => DataContext as RotatedImageViewModel;
        
        public static readonly RoutedEvent ShowSolutionEvent =  
            EventManager.RegisterRoutedEvent("ShowSolution", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MovedImageControl)); 
        public static readonly RoutedEvent HideSolutionEvent =  
            EventManager.RegisterRoutedEvent("HideSolution", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MovedImageControl)); 
			
        public event RoutedEventHandler ShowSolution
        { 
            add => AddHandler(ShowSolutionEvent, value);
            remove => RemoveHandler(ShowSolutionEvent, value);
        } 
        
        public event RoutedEventHandler HideSolution
        { 
            add => AddHandler(HideSolutionEvent, value);
            remove => RemoveHandler(HideSolutionEvent, value);
        } 
        
        public MovedImageControl()
        {
            InitializeComponent();
        }

        private void ResultViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaiseEvent(ViewModel.IsSolvedDisplayed
                           ? new RoutedEventArgs(ShowSolutionEvent)
                           : new RoutedEventArgs(HideSolutionEvent));
        }

        private void MovedImageControl_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ViewModel.PropertyChanged += ResultViewModelOnPropertyChanged;
        }
    }
}