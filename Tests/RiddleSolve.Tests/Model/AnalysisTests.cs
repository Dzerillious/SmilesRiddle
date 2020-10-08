using System;
using System.Linq;
using NUnit.Framework;
using RiddleSolve.Model;
using static RiddleSolve.Model.FacePart;

namespace RiddleSolve.Tests.Model
{
    public class AnalysisTests
    {
        [Test]
        public void EmptyAnalysisTest()
        {
            var analysis = new Analysis();
            
            foreach (PartType partType in Enum.GetValues(typeof(PartType)))
            foreach (FaceColor faceColor in Enum.GetValues(typeof(FaceColor)))
            {
                var facePart = new FacePart(partType, faceColor);
                var possibleTiles = analysis.GetPossibleTiles(Any, facePart);
                Assert.AreEqual(0, possibleTiles.Count());
            }
        }
        
        [Test]
        public void TileAnalysisAnyTest()
        {
            var analysis = new Analysis();
            var tile = new Tile((0, 0),
                                new FacePart(PartType.Eyes, FaceColor.Green), 
                                new FacePart(PartType.Mouth, FaceColor.Red), 
                                new FacePart(PartType.Eyes, FaceColor.Yellow), 
                                new FacePart(PartType.Mouth, FaceColor.Green));
            analysis.IncludeTile(tile);
            
            var possibleTiles = analysis.GetPossibleTiles(Any, Any);
            foreach (RotatedTile possibleTile in possibleTiles)
                Assert.AreEqual(possibleTile.Top, tile.Top);
        }
        
        [Test]
        public void TileAnalysisTopTest()
        {
            var analysis = new Analysis();
            var tile = new Tile((0, 0), 
                                new FacePart(PartType.Eyes, FaceColor.Green), 
                                new FacePart(PartType.Mouth, FaceColor.Red), 
                                new FacePart(PartType.Eyes, FaceColor.Yellow), 
                                new FacePart(PartType.Mouth, FaceColor.Green));
            analysis.IncludeTile(tile);
            
            foreach (PartType partType in Enum.GetValues(typeof(PartType)))
            foreach (FaceColor faceColor in Enum.GetValues(typeof(FaceColor)))
            {
                if (partType == PartType.Any || faceColor == FaceColor.Any)
                    continue;
                var facePart = new FacePart(partType, faceColor);
                var possibleTiles = analysis.GetPossibleTiles(facePart, Any);
                foreach (RotatedTile possibleTile in possibleTiles)
                    Assert.AreEqual(possibleTile.Top, facePart.GetMatching());
            }
        }
        
        [Test]
        public void TileAnalysisLeftTest()
        {
            var analysis = new Analysis();
            var tile = new Tile((0, 0), 
                                new FacePart(PartType.Eyes, FaceColor.Green), 
                                new FacePart(PartType.Mouth, FaceColor.Red), 
                                new FacePart(PartType.Eyes, FaceColor.Yellow), 
                                new FacePart(PartType.Mouth, FaceColor.Green));
            analysis.IncludeTile(tile);
            
            foreach (PartType partType in Enum.GetValues(typeof(PartType)))
            foreach (FaceColor faceColor in Enum.GetValues(typeof(FaceColor)))
            {
                if (partType == PartType.Any || faceColor == FaceColor.Any)
                    continue;
                var facePart = new FacePart(partType, faceColor);
                var possibleTiles = analysis.GetPossibleTiles(Any, facePart);
                foreach (RotatedTile possibleTile in possibleTiles)
                    Assert.AreEqual(possibleTile.Left, facePart.GetMatching());
            }
        }
        
        [Test]
        public void TileAnalysisBothTest()
        {
            var analysis = new Analysis();
            var tile = new Tile((0, 0), 
                                new FacePart(PartType.Eyes, FaceColor.Green), 
                                new FacePart(PartType.Mouth, FaceColor.Red), 
                                new FacePart(PartType.Eyes, FaceColor.Yellow), 
                                new FacePart(PartType.Mouth, FaceColor.Green));
            analysis.IncludeTile(tile);
            
            foreach (PartType partTypeTop in Enum.GetValues(typeof(PartType)))
            foreach (FaceColor faceColorTop in Enum.GetValues(typeof(FaceColor)))
            foreach (PartType partTypeLeft in Enum.GetValues(typeof(PartType)))
            foreach (FaceColor faceColorLeft in Enum.GetValues(typeof(FaceColor)))
            {
                if (partTypeTop == PartType.Any 
                 || faceColorTop == FaceColor.Any
                 || partTypeLeft == PartType.Any
                 || faceColorLeft == FaceColor.Any)
                    continue;
                var topFacePart = new FacePart(partTypeTop, faceColorLeft);
                var leftFacePart = new FacePart(partTypeLeft, faceColorLeft);
                var possibleTiles = analysis.GetPossibleTiles(topFacePart, leftFacePart);
                
                foreach (RotatedTile possibleTile in possibleTiles)
                {
                    Assert.AreEqual(possibleTile.Left, leftFacePart.GetMatching());
                    Assert.AreEqual(possibleTile.Top, topFacePart.GetMatching());
                }
            }
        }
    }
}