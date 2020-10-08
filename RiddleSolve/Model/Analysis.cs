using System;
using System.Collections.Generic;
using System.Linq;
using static RiddleSolve.Model.ITile;

namespace RiddleSolve.Model
{
    public class Analysis
    {
        private readonly Dictionary<FacePart, List<RotatedTile>> _matchingTiles 
            = new Dictionary<FacePart, List<RotatedTile>>();

        public Analysis()
        {
            foreach (FacePart.PartType partType in Enum.GetValues(typeof(FacePart.PartType)))
            foreach (FacePart.FaceColor faceColor in Enum.GetValues(typeof(FacePart.FaceColor)))
                _matchingTiles[new FacePart(partType, faceColor)] = new List<RotatedTile>();
        }

        public void IncludeTile(ITile tile)
        {
            AddMatchingTile(FacePart.Any, tile, TileRotation.Right);
            AddMatchingTile(FacePart.Any, tile, TileRotation.None);
            AddMatchingTile(FacePart.Any, tile, TileRotation.Left);
            AddMatchingTile(FacePart.Any, tile, TileRotation.Down);
            AddMatchingTile(tile.Left, tile, TileRotation.Right);
            AddMatchingTile(tile.Top, tile, TileRotation.None);
            AddMatchingTile(tile.Right, tile, TileRotation.Left);
            AddMatchingTile(tile.Bottom, tile, TileRotation.Down);
        }

        private void AddMatchingTile(FacePart facePart, ITile tile, TileRotation rotate)
        {
            var matchingFacePart = facePart.GetMatching();
            var rotatedTile = tile.GetRotated(rotate);
            _matchingTiles[matchingFacePart].Add(rotatedTile);
        }

        public IEnumerable<RotatedTile> GetPossibleTiles(FacePart upperFace, FacePart leftFace)
        {
            List<RotatedTile> allTiles = _matchingTiles[FacePart.Any];
            List<RotatedTile> upperPossibilities = _matchingTiles[upperFace];
            List<RotatedTile> leftPossibilities = _matchingTiles[leftFace];
            var leftRotatedPossibilities =
                leftPossibilities.Select(tile => tile.GetRotated(TileRotation.Left));
            
            if (Equals(allTiles, leftPossibilities)) 
                return upperPossibilities;
            if (Equals(allTiles, upperPossibilities)) 
                return leftRotatedPossibilities;
            return upperPossibilities.Intersect(leftRotatedPossibilities);
        }
    }
}