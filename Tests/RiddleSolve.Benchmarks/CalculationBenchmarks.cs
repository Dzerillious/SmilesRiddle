using System.Drawing;
using System.Windows.Media.Imaging;
using BenchmarkDotNet.Attributes;
using RiddleSolve.Calculation;
using RiddleSolve.Model;

namespace RiddleSolve.Benchmarks
{
    // |    Method |            Mean |         Error |        StdDev |    Gen 0 |    Gen 1 |    Gen 2 |  Allocated |
    // |---------- |----------------:|--------------:|--------------:|---------:|---------:|---------:|-----------:|
    // | GetBitmap |        945.1 ns |       4.74 ns |       4.43 ns |   0.2708 |        - |        - |      568 B |
    // | GetPixels | 11,020,150.0 ns | 217,004.76 ns | 448,152.46 ns | 343.7500 | 343.7500 | 343.7500 | 22440016 B |
    // |   Parsing |      2,300.8 ns |      19.19 ns |      17.95 ns |   2.7733 |        - |        - |     5800 B |
    // |  Analysis |      8,586.7 ns |      68.29 ns |      63.88 ns |   3.3264 |        - |        - |     6970 B |
    // |     Solve |    251,453.6 ns |   1,659.44 ns |   1,552.24 ns |  83.4961 |        - |        - |   175042 B |
    
    // If optimization needed: GetPixels -> Parsing can be changed for working with bytes instead of colors
    
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
            var result = new ITile[_tiles.GetLength(0), _tiles.GetLength(1)];
            return new Solver().Solve(result, _analysis);
        }
    }
}