using RiddleSolve.Model;

namespace RiddleSolve.Calculation
{
    public static class Analyzer
    {
        public static Analysis Analyze(ITile[,] board)
        {
            var analysis = new Analysis();
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);
            
            for (var row = 0; row < rows; row++)
            for (var column = 0; column < columns; column++)
            {
                var tile = board[row, column];
                analysis.IncludeTile(tile);
            }

            return analysis;
        }
    }
}