using System.Collections.Generic;
using RiddleSolve.Model;
using static RiddleSolve.Model.FacePart;

namespace RiddleSolve.Calculation
{
    public static class Solver
    {
        private static readonly HashSet<Position> UsedTiles = new HashSet<Position>();

        public static bool Solve(ITile[,] board, Analysis analysis, Position position)
        {
            if (!position.IsInside(board)) return true;
            var tilePossibilities = GetTilePossibilities(board, analysis, position);
                
            foreach (ITile tile in tilePossibilities)
            {
                if (UsedTiles.Contains(tile.TileFromPosition)) continue;
                board[position.Y, position.X] = tile;

                UsedTiles.Add(tile.TileFromPosition);
                if (Solve(board, analysis, position.GetNext(board))) return true;
                UsedTiles.Remove(tile.TileFromPosition);
            }
            return false;
        }

        public static IEnumerable<ITile> GetTilePossibilities(ITile[,] board, Analysis analysis, Position position)
        {
            var upperPosition = position + Side.Top.ToRelativePosition();
            var upperFacePart = GetFacePart(board, upperPosition, Side.Bottom);

            var leftPosition = position + Side.Left.ToRelativePosition();
            var leftFacePart = GetFacePart(board, leftPosition, Side.Right);

            return analysis.GetPossibleTiles(upperFacePart, leftFacePart);
        }

        private static FacePart GetFacePart(ITile[,] board, Position position, Side side)
        {
            if (!position.IsInside(board)) return Any;
            var rotatedTile = board[position.Y, position.X];
            return rotatedTile.GetFacePart(side);
        }
    }
}