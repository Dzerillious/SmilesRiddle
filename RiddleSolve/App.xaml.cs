using System.Drawing;
using System.Windows;
using RiddleSolve.Calculation;
using RiddleSolve.Model;

namespace RiddleSolve
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var bitmap = Loader.GetBitmap();
            Color[] pixels = Loader.GetPixels(bitmap);
            Tile[,] tiles = TileParser.ParseTiles(pixels, bitmap.PixelWidth, bitmap.PixelHeight);
            Analysis analysis = Analyser.Analyze(tiles);
            var result = new RotatedTile[tiles.GetLength(0), tiles.GetLength(1)];
            
            if (Solver.Solve(result, analysis, (0, 0)))
                Printer.Print(result);
        }
    }
}