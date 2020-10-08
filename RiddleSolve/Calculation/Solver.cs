using System.Collections.Generic;
using RiddleSolve.Converters;
using RiddleSolve.Model;
using static RiddleSolve.Model.ITile;

namespace RiddleSolve.Calculation
{
    public class Solver
    {
        private readonly HashSet<Position> _usedTiles = new HashSet<Position>();

        public bool Solve(ITile[,] board, Analysis analysis, Position position)
        {
            if (!position.IsInside(board)) return true;
            var tilePossibilities = GetTilePossibilities(board, analysis, position);
                
            foreach (ITile tile in tilePossibilities)
            {
                if (_usedTiles.Contains(tile.FromPosition)) continue;
                board[position.Y, position.X] = tile;

                _usedTiles.Add(tile.FromPosition);
                if (Solve(board, analysis, position.GetNext(board))) return true;
                _usedTiles.Remove(tile.FromPosition);
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
            if (!position.IsInside(board)) return FacePart.Any;
            var rotatedTile = board[position.Y, position.X];
            return rotatedTile.GetFacePart(side);
        }
    }
}