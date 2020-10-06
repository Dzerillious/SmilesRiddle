using System.ComponentModel;
using System.Drawing;
using System.Windows;
using RiddleSolve.Calculation;
using RiddleSolve.Model;
using RiddleSolve.ViewModel;

namespace RiddleSolve
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ResultViewModel ViewModel => DataContext as ResultViewModel;
        
        public static readonly RoutedEvent ShowSolutionEvent =  
            EventManager.RegisterRoutedEvent("ShowSolution", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MainWindow)); 
        public static readonly RoutedEvent HideSolutionEvent =  
            EventManager.RegisterRoutedEvent("HideSolution", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MainWindow)); 
			
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
        
        public MainWindow()
        {
            InitializeComponent();
            
            var bitmap = Loader.GetBitmap();
            Color[] pixels = Loader.GetPixels(bitmap);
            Tile[,] tiles = TileParser.ParseTiles(pixels, bitmap.PixelWidth, bitmap.PixelHeight);
            Analysis analysis = Analyser.Analyze(tiles);
            var result = new RotatedTile[tiles.GetLength(0), tiles.GetLength(1)];

            if (Solver.Solve(result, analysis, (0, 0)))
            {
                DataContext = SolutionDrawer.GetResultViewModel(bitmap, result);
                ViewModel.PropertyChanged += ResultViewModelOnPropertyChanged;
            }
        }

        private void ResultViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (ViewModel.IsShowedSolved) RaiseEvent(new RoutedEventArgs(ShowSolutionEvent));
            else RaiseEvent(new RoutedEventArgs(HideSolutionEvent));
        }
    }
}