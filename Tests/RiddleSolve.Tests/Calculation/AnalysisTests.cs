using System;
using NUnit.Framework;
using RiddleSolve.Calculation;
using RiddleSolve.Model;
using static RiddleSolve.Model.FacePart;

namespace RiddleSolve.Tests.Calculation
{
    public class AnalyserTests
    {
        [Test]
        public void AnalyzeTileTest()
        {
            var analysis = Analyser.Analyze(new[,]
            {
                {
                    new Tile(new FacePart(PartType.Eyes, FaceColor.Green),
                             new FacePart(PartType.Eyes, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue))
                }
            });
            CheckAnalysis(analysis);
        }
        
        [Test]
        public void Analyze2TilesTest()
        {
            var analysis = Analyser.Analyze(new[,]
            {
                {
                    new Tile(new FacePart(PartType.Eyes, FaceColor.Green),
                             new FacePart(PartType.Eyes, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue)),
                    
                    new Tile(new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Mouth, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue))
                }
            });
            CheckAnalysis(analysis);
        }
        
        [Test]
        public void Analyze4TilesTest()
        {
            var analysis = Analyser.Analyze(new[,]
            {
                {
                    new Tile(new FacePart(PartType.Eyes, FaceColor.Green),
                             new FacePart(PartType.Eyes, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue)),
                    
                    new Tile(new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Mouth, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue))
                },
                {
                    new Tile(new FacePart(PartType.Mouth, FaceColor.Blue),
                             new FacePart(PartType.Eyes, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Green),
                             new FacePart(PartType.Eyes, FaceColor.Blue)),
                    
                    new Tile(new FacePart(PartType.Eyes, FaceColor.Yellow),
                             new FacePart(PartType.Mouth, FaceColor.Blue),
                             new FacePart(PartType.Eyes, FaceColor.Green),
                             new FacePart(PartType.Eyes, FaceColor.Red))
                }
            });
            CheckAnalysis(analysis);
        }

        private void CheckAnalysis(Analysis analysis)
        {
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