using System.ComponentModel;
using System.Drawing;
using System.Windows;
using RiddleSolve.Calculation;
using RiddleSolve.Model;
using RiddleSolve.ViewModel;

namespace RiddleSolve.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ResultViewModel ViewModel => DataContext as ResultViewModel;
        
        public MainWindow()
        {
            InitializeComponent();
            
            var bitmap = Loader.GetBitmap();
            Color[] pixels = Loader.GetPixels(bitmap);
            Tile[,] tiles = TileParser.ParseTiles(pixels, bitmap.PixelWidth, bitmap.PixelHeight);
            Analysis analysis = Analyser.Analyze(tiles);
            var result = new RotatedTile[tiles.GetLength(0), tiles.GetLength(1)];

            if (Solver.Solve(result, analysis, (0, 0)))
                DataContext = SolutionDrawer.GetResultViewModel(bitmap, result);
        }
    }
}