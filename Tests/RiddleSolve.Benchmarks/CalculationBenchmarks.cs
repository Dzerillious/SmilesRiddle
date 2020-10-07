using System.Drawing;
using System.Windows.Media.Imaging;
using BenchmarkDotNet.Attributes;
using RiddleSolve.Calculation;
using RiddleSolve.Model;

namespace RiddleSolve.Benchmarks
{
    // |    Method |            Mean |         Error |        StdDev |          Median |    Gen 0 |    Gen 1 |    Gen 2 |  Allocated |
    // |---------- |----------------:|--------------:|--------------:|----------------:|---------:|---------:|---------:|-----------:|
    // | GetBitmap |        925.3 ns |       4.52 ns |       4.01 ns |        926.0 ns |   0.2708 |        - |        - |      568 B |
    // | GetPixels | 10,831,605.3 ns | 204,213.66 ns | 473,296.21 ns | 10,673,020.3 ns | 328.1250 | 328.1250 | 328.1250 | 22439901 B |
    // |   Parsing |      2,122.4 ns |       4.89 ns |       4.34 ns |      2,121.6 ns |   2.6360 |        - |        - |     5512 B |
    // |  Analysis |      8,212.1 ns |      35.37 ns |      33.09 ns |      8,215.7 ns |   3.3264 |        - |        - |     6970 B |
    // |     Solve |      1,284.0 ns |       2.07 ns |       1.61 ns |      1,284.4 ns |   0.1640 |        - |        - |      344 B |

    
    // If optimization needed GetPixels -> Parsing can be changed for working with bytes instead of colorss
    
    [MemoryDiagnoser]
    public class CalculationBenchmarks
    {
        private static ITile[,] _tiles;
        private static Analysis _analysis;
        private static BitmapImage _bitmap;
        private static Color[] _pixels;

        [Benchmark]
        public BitmapImage GetBitmap() => Loader.GetBitmap();


        [GlobalSetup(Target = nameof(GetPixels))]
        public void GetPixelsSetup()
        {
            _bitmap = GetBitmap();
        }
        
        [Benchmark]
        public Color[] GetPixels() => Loader.GetPixels(_bitmap);
        

        [GlobalSetup(Target = nameof(Parsing))]
        public void ParsingSetup()
        {
            _bitmap = GetBitmap();
            _pixels = GetPixels();
        }
        
        [Benchmark]
        public ITile[,] Parsing() => TileParser.ParseTiles(_pixels, _bitmap.PixelWidth, _bitmap.PixelHeight);

        [GlobalSetup(Target = nameof(Analysis))]
        public void AnalysisSetup()
        {
            _bitmap = GetBitmap();
            _pixels = GetPixels();
            _tiles = Parsing();
        }

        [Benchmark]
        public Analysis Analysis() => Analyser.Analyze(_tiles);
        

        [GlobalSetup(Target = nameof(Solve))]
        public void SolveSetup()
        {
            _bitmap = GetBitmap();
            _pixels = GetPixels();
            _tiles = Parsing();
            _analysis = Analysis();
        }
        
        [Benchmark]
        public bool Solve()
        {
            var result = new RotatedTile[_tiles.GetLength(0), _tiles.GetLength(1)];
            return Solver.Solve(result, _analysis, (0, 0));
        }
    }
}