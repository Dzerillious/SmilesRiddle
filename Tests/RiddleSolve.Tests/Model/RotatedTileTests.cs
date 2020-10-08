using NUnit.Framework;
using RiddleSolve.Model;
using static RiddleSolve.Model.ITile;

namespace RiddleSolve.Tests.Model
{
    public class RotatedTileTests
    {
        [Test]
        public void LeftRotated()
        {
            var left = new FacePart(FacePart.PartType.Any, FacePart.FaceColor.Any);
            var top = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Blue);
            var right = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Red);
            var bottom = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Any);
            var tile = new Tile((0, 0), left, top, right, bottom);
            
            var upRotated = new RotatedTile(tile, TileRotation.Left);
            Assert.AreEqual(top, upRotated.Left);
            Assert.AreEqual(right, upRotated.Top);
            Assert.AreEqual(bottom, upRotated.Right);
            Assert.AreEqual(left, upRotated.Bottom);
            Assert.AreEqual(upRotated.Right, upRotated.GetFacePart(TileSide.Right));
        }
        
        [Test]
        public void UpRotated()
        {
            var left = new FacePart(FacePart.PartType.Any, FacePart.FaceColor.Any);
            var top = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Blue);
            var right = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Red);
            var bottom = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Any);
            var tile = new Tile((0, 0), left, top, right, bottom);
            
            var upRotated = new RotatedTile(tile, TileRotation.None);
            Assert.AreEqual(left, upRotated.Left);
            Assert.AreEqual(top, upRotated.Top);
            Assert.AreEqual(right, upRotated.Right);
            Assert.AreEqual(bottom, upRotated.Bottom);
            Assert.AreEqual(upRotated.Right, upRotated.GetFacePart(TileSide.Right));
        }
        
        [Test]
        public void RightRotated()
        {
            var left = new FacePart(FacePart.PartType.Any, FacePart.FaceColor.Any);
            var top = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Blue);
            var right = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Red);
            var bottom = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Any);
            var tile = new Tile((0, 0), left, top, right, bottom);
            
            var upRotated = new RotatedTile(tile, TileRotation.Right);
            Assert.AreEqual(bottom, upRotated.Left);
            Assert.AreEqual(left, upRotated.Top);
            Assert.AreEqual(top, upRotated.Right);
            Assert.AreEqual(right, upRotated.Bottom);
            Assert.AreEqual(upRotated.Right, upRotated.GetFacePart(TileSide.Right));
        }
        
        [Test]
        public void DownRotated()
        {
            var left = new FacePart(FacePart.PartType.Any, FacePart.FaceColor.Any);
            var top = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Blue);
            var right = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Red);
            var bottom = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Any);
            var tile = new Tile((0, 0), left, top, right, bottom);
            
            var upRotated = new RotatedTile(tile, TileRotation.Down);
            Assert.AreEqual(right, upRotated.Left);
            Assert.AreEqual(bottom, upRotated.Top);
            Assert.AreEqual(left, upRotated.Right);
            Assert.AreEqual(top, upRotated.Bottom);
            Assert.AreEqual(upRotated.Right, upRotated.GetFacePart(TileSide.Right));
        }
        
        [Test]
        public void DownDownRotated()
        {
            var left = new FacePart(FacePart.PartType.Any, FacePart.FaceColor.Any);
            var top = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Blue);
            var right = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Red);
            var bottom = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Any);
            var tile = new Tile((0, 0), left, top, right, bottom);
            
            var upRotated = new RotatedTile(tile, TileRotation.Down).GetRotated(TileRotation.Down);
            Assert.AreEqual(left, upRotated.Left);
            Assert.AreEqual(top, upRotated.Top);
            Assert.AreEqual(right, upRotated.Right);
            Assert.AreEqual(bottom, upRotated.Bottom);
            Assert.AreEqual(upRotated.Right, upRotated.GetFacePart(TileSide.Right));
        }
        
        [Test]
        public void RightRightRotated()
        {
            var left = new FacePart(FacePart.PartType.Any, FacePart.FaceColor.Any);
            var top = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Blue);
            var right = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Red);
            var bottom = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Any);
            var tile = new Tile((0, 0), left, top, right, bottom);
            
            var upRotated = new RotatedTile(tile, TileRotation.Right).GetRotated(TileRotation.Right);
            Assert.AreEqual(right, upRotated.Left);
            Assert.AreEqual(bottom, upRotated.Top);
            Assert.AreEqual(left, upRotated.Right);
            Assert.AreEqual(top, upRotated.Bottom);
        }
        
        [Test]
        public void DownRightRotated()
        {
            var left = new FacePart(FacePart.PartType.Any, FacePart.FaceColor.Any);
            var top = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Blue);
            var right = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Red);
            var bottom = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Any);
            var tile = new Tile((0, 0), left, top, right, bottom);
            
            var upRotated = new RotatedTile(tile, TileRotation.Down).GetRotated(TileRotation.Right);
            Assert.AreEqual(top, upRotated.Left);
            Assert.AreEqual(right, upRotated.Top);
            Assert.AreEqual(bottom, upRotated.Right);
            Assert.AreEqual(left, upRotated.Bottom);
        }
        
        [Test]
        public void LeftLeftRotated()
        {
            var left = new FacePart(FacePart.PartType.Any, FacePart.FaceColor.Any);
            var top = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Blue);
            var right = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Red);
            var bottom = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Any);
            var tile = new Tile((0, 0), left, top, right, bottom);
            
            var upRotated = new RotatedTile(tile, TileRotation.Left).GetRotated(TileRotation.Left);
            Assert.AreEqual(right, upRotated.Left);
            Assert.AreEqual(bottom, upRotated.Top);
            Assert.AreEqual(left, upRotated.Right);
            Assert.AreEqual(top, upRotated.Bottom);
        }
        
        [Test]
        public void LeftRightRotated()
        {
            var left = new FacePart(FacePart.PartType.Any, FacePart.FaceColor.Any);
            var top = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Blue);
            var right = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Red);
            var bottom = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Any);
            var tile = new Tile((0, 0), left, top, right, bottom);
            
            var upRotated = new RotatedTile(tile, TileRotation.Left).GetRotated(TileRotation.Right);
            Assert.AreEqual(left, upRotated.Left);
            Assert.AreEqual(top, upRotated.Top);
            Assert.AreEqual(right, upRotated.Right);
            Assert.AreEqual(bottom, upRotated.Bottom);
        }
    }
}