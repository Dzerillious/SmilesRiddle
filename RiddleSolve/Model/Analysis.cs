﻿using System;
using System.Collections.Generic;
using System.Linq;
using static RiddleSolve.Model.FacePart;
using static RiddleSolve.Model.RotatedTile;

namespace RiddleSolve.Model
{
    public class Analysis
    {
        private readonly Dictionary<FacePart, List<RotatedTile>> _matchingTiles 
            = new Dictionary<FacePart, List<RotatedTile>>();

        public Analysis()
        {
            foreach (PartType partType in Enum.GetValues(typeof(PartType)))
            foreach (FaceColor faceColor in Enum.GetValues(typeof(FaceColor)))
                _matchingTiles[new FacePart(partType, faceColor)] = new List<RotatedTile>();
        }

        public void IncludeTile(Tile tile)
        {
            AddMatchingTile(Any, tile, TileRotation.Up);
            AddMatchingTile(tile.Top, tile, TileRotation.Up);
            AddMatchingTile(tile.Right, tile, TileRotation.Left);
            AddMatchingTile(tile.Bottom, tile, TileRotation.Down);
            AddMatchingTile(tile.Left, tile, TileRotation.Right);
        }

        private void AddMatchingTile(FacePart facePart, Tile tile, TileRotation rotate)
        {
            var matchingFacePart = facePart.GetMatching();
            var rotatedTile = new RotatedTile(tile, rotate);
            _matchingTiles[matchingFacePart].Add(rotatedTile);
        }

        public IEnumerable<RotatedTile> GetPossibleTiles(FacePart upperMatchingFace, FacePart leftMatchingFace)
        {
            List<RotatedTile> allTiles = _matchingTiles[Any];
            List<RotatedTile> upperPossibilities = _matchingTiles[upperMatchingFace];
            List<RotatedTile> leftPossibilities = _matchingTiles[leftMatchingFace];
            var leftRotatedPossibilities =
                leftPossibilities.Select(tile => tile.GetComposedRotation(TileRotation.Left));
            
            if (Equals(allTiles, leftPossibilities)) 
                return upperPossibilities;
            if (Equals(allTiles, upperPossibilities)) 
                return leftRotatedPossibilities;
            return upperPossibilities.Intersect(leftRotatedPossibilities);
        }
    }
}