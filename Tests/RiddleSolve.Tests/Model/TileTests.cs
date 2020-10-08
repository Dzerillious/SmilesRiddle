using NUnit.Framework;
using RiddleSolve.Model;

namespace RiddleSolve.Tests.Model
{
    public class TileTests
    {
        [Test]
        public void TileSidesMatching()
        {
            var left = new FacePart(FacePart.PartType.Any, FacePart.FaceColor.Any);
            var top = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Blue);
            var right = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Red);
            var bottom = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Any);
            var tile = new Tile((0, 0), left, top, right, bottom);
            
            Assert.AreEqual(left, tile.Left);
            Assert.AreEqual(top, tile.Top);
            Assert.AreEqual(right, tile.Right);
            Assert.AreEqual(bottom, tile.Bottom);
            Assert.AreEqual(right, tile.GetFacePart(ITile.Side.Right));
        }

        [Test]
        public void TileSidesMatching2()
        {
            var left = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Red);
            var top = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Green);
            var right = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Yellow);
            var bottom = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Any);
            var tile = new Tile((0, 0), left, top, right, bottom);
            
            Assert.AreEqual(left, tile.Left);
            Assert.AreEqual(top, tile.Top);
            Assert.AreEqual(right, tile.Right);
            Assert.AreEqual(bottom, tile.Bottom);
            Assert.AreEqual(right, tile.GetFacePart(ITile.Side.Right));
        }
    }
}