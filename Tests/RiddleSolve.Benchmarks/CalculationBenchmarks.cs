using System.Drawing;
using System.Windows.Media.Imaging;
using BenchmarkDotNet.Attributes;
using RiddleSolve.Calculation;
using RiddleSolve.Model;

namespace RiddleSolve.Benchmarks
{
    // |    Method |            Mean |         Error |        StdDev |    Gen 0 |    Gen 1 |    Gen 2 |  Allocated |
    // |---------- |----------------:|--------------:|--------------:|---------:|---------:|---------:|-----------:|
    // | GetBitmap |      1,032.3 ns |       7.80 ns |       6.51 ns |   0.2708 |        - |        - |      568 B |
    // | GetPixels | 12,445,314.6 ns | 244,797.59 ns | 453,748.03 ns | 328.1250 | 328.1250 | 328.1250 | 22439901 B |
    // |   Parsing |      3,175.2 ns |      24.80 ns |      21.98 ns |   2.7046 |        - |        - |     5656 B |
    // |  Analysis |      3,249.1 ns |      21.55 ns |      16.82 ns |   1.8730 |        - |        - |     3920 B |
    // |     Solve |        827.8 ns |       4.47 ns |       3.96 ns |   0.1640 |        - |        - |      344 B |
    
    // If optimization needed GetPixels -> Parsing can be changed for working with bytes instead of colorss
    
    [MemoryDiagnoser]
    public class CalculationBenchmarks
    {
        private static Tile[,] _tiles;
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
        public Tile[,] Parsing() => TileParser.ParseTiles(_pixels, _bitmap.PixelWidth, _bitmap.PixelHeight);

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