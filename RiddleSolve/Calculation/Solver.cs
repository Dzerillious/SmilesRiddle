using System.Collections.Generic;
using RiddleSolve.Converters;
using RiddleSolve.Model;
using static RiddleSolve.Model.ITile;

namespace RiddleSolve.Calculation
{
    public class Solver
    {
        private readonly HashSet<Position> _usedTiles = new HashSet<Position>();

        public bool Solve(ITile[,] result, Analysis analysis)
            => Solve(result, analysis, (0, 0));

        private bool Solve(ITile[,] result, Analysis analysis, Position position)
        {
            if (!position.IsInside(result)) return true;
            var tilePossibilities = GetTilePossibilities(result, analysis, position);
                
            foreach (ITile tile in tilePossibilities)
            {
                if (_usedTiles.Contains(tile.FromPosition)) continue;
                result[position.Y, position.X] = tile;

                _usedTiles.Add(tile.FromPosition);
                if (Solve(result, analysis, position.GetNext(result))) return true;
                _usedTiles.Remove(tile.FromPosition);
            }
            return false;
        }

        private static IEnumerable<ITile> GetTilePossibilities(ITile[,] board, Analysis analysis, Position position)
        {
            var upperPosition = position + TileSide.Top.ToRelativePosition();
            var upperFacePart = GetFacePart(board, upperPosition, TileSide.Bottom);

            var leftPosition = position + TileSide.Left.ToRelativePosition();
            var leftFacePart = GetFacePart(board, leftPosition, TileSide.Right);

            return analysis.GetPossibleTiles(upperFacePart, leftFacePart);
        }

        private static FacePart GetFacePart(ITile[,] board, Position position, TileSide side)
        {
            if (!position.IsInside(board)) return FacePart.Any;
            var rotatedTile = board[position.Y, position.X];
            return rotatedTile.GetFacePart(side);
        }
    }
}