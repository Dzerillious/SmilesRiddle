using System.Collections.Generic;
using RiddleSolve.Model;
using static RiddleSolve.Model.FacePart;

namespace RiddleSolve.Calculation
{
    public static class Solver
    {
        private static readonly Dictionary<Tile, RotatedTile> UsedTiles = new Dictionary<Tile, RotatedTile>();

        public static bool Solve(RotatedTile[,] board, Analysis analysis, Position position)
        {
            if (!position.IsInside(board)) return true;
            var tilePossibilities = GetTilePossibilities(board, analysis, position);
                
            foreach (RotatedTile rotatedTile in tilePossibilities)
            {
                if (UsedTiles.ContainsKey(rotatedTile.Tile)) continue;
                board[position.Y, position.X] = rotatedTile;
                
                UsedTiles[rotatedTile.Tile] = rotatedTile;
                if (Solve(board, analysis, position.GetNext(board))) return true;
                UsedTiles.Remove(rotatedTile.Tile);
            }
            return false;
        }

        public static IEnumerable<RotatedTile> GetTilePossibilities(RotatedTile[,] board, Analysis analysis, Position position)
        {
            var upperPosition = position + Side.Top.ToRelativePosition();
            var upperFacePart = GetFacePart(board, upperPosition, Side.Bottom);

            var leftPosition = position + Side.Left.ToRelativePosition();
            var leftFacePart = GetFacePart(board, leftPosition, Side.Right);

            return analysis.GetPossibleTiles(upperFacePart, leftFacePart);
        }

        private static FacePart GetFacePart(RotatedTile[,] board, Position position, Side side)
        {
            if (!position.IsInside(board)) return Any;
            var rotatedTile = board[position.Y, position.X];
            return rotatedTile.GetFacePart(side);
        }
    }
}