using NUnit.Framework;
using RiddleSolve.Model;
using static RiddleSolve.Model.RotatedTile;

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
            var tile = new Tile(0, 0, left, top, right, bottom);
            
            var upRotated = new RotatedTile(tile, TileRotation.Left);
            Assert.AreEqual(upRotated.Left, top);
            Assert.AreEqual(upRotated.Top, right);
            Assert.AreEqual(upRotated.Right, bottom);
            Assert.AreEqual(upRotated.Bottom, left);
            Assert.AreEqual(upRotated.GetFacePart(Side.Right), upRotated.Right);
        }
        
        [Test]
        public void UpRotated()
        {
            var left = new FacePart(FacePart.PartType.Any, FacePart.FaceColor.Any);
            var top = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Blue);
            var right = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Red);
            var bottom = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Any);
            var tile = new Tile(0, 0, left, top, right, bottom);
            
            var upRotated = new RotatedTile(tile, TileRotation.Up);
            Assert.AreEqual(upRotated.Left, left);
            Assert.AreEqual(upRotated.Top, top);
            Assert.AreEqual(upRotated.Right, right);
            Assert.AreEqual(upRotated.Bottom, bottom);
            Assert.AreEqual(upRotated.GetFacePart(Side.Right), upRotated.Right);
        }
        
        [Test]
        public void RightRotated()
        {
            var left = new FacePart(FacePart.PartType.Any, FacePart.FaceColor.Any);
            var top = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Blue);
            var right = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Red);
            var bottom = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Any);
            var tile = new Tile(0, 0, left, top, right, bottom);
            
            var upRotated = new RotatedTile(tile, TileRotation.Right);
            Assert.AreEqual(upRotated.Left, bottom);
            Assert.AreEqual(upRotated.Top, left);
            Assert.AreEqual(upRotated.Right, top);
            Assert.AreEqual(upRotated.Bottom, right);
            Assert.AreEqual(upRotated.GetFacePart(Side.Right), upRotated.Right);
        }
        
        [Test]
        public void DownRotated()
        {
            var left = new FacePart(FacePart.PartType.Any, FacePart.FaceColor.Any);
            var top = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Blue);
            var right = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Red);
            var bottom = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Any);
            var tile = new Tile(0, 0, left, top, right, bottom);
            
            var upRotated = new RotatedTile(tile, TileRotation.Down);
            Assert.AreEqual(upRotated.Left, right);
            Assert.AreEqual(upRotated.Top, bottom);
            Assert.AreEqual(upRotated.Right, left);
            Assert.AreEqual(upRotated.Bottom, top);
            Assert.AreEqual(upRotated.GetFacePart(Side.Right), upRotated.Right);
        }
        
        [Test]
        public void DownDownRotated()
        {
            var left = new FacePart(FacePart.PartType.Any, FacePart.FaceColor.Any);
            var top = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Blue);
            var right = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Red);
            var bottom = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Any);
            var tile = new Tile(0, 0, left, top, right, bottom);
            
            var upRotated = new RotatedTile(tile, TileRotation.Down).GetComposedRotation(TileRotation.Down);
            Assert.AreEqual(upRotated.Left, left);
            Assert.AreEqual(upRotated.Top, top);
            Assert.AreEqual(upRotated.Right, right);
            Assert.AreEqual(upRotated.Bottom, bottom);
            Assert.AreEqual(upRotated.GetFacePart(Side.Right), upRotated.Right);
        }
        
        [Test]
        public void RightRightRotated()
        {
            var left = new FacePart(FacePart.PartType.Any, FacePart.FaceColor.Any);
            var top = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Blue);
            var right = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Red);
            var bottom = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Any);
            var tile = new Tile(0, 0, left, top, right, bottom);
            
            var upRotated = new RotatedTile(tile, TileRotation.Right).GetComposedRotation(TileRotation.Right);
            Assert.AreEqual(upRotated.Left, right);
            Assert.AreEqual(upRotated.Top, bottom);
            Assert.AreEqual(upRotated.Right, left);
            Assert.AreEqual(upRotated.Bottom, top);
        }
        
        [Test]
        public void DownRightRotated()
        {
            var left = new FacePart(FacePart.PartType.Any, FacePart.FaceColor.Any);
            var top = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Blue);
            var right = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Red);
            var bottom = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Any);
            var tile = new Tile(0, 0, left, top, right, bottom);
            
            var upRotated = new RotatedTile(tile, TileRotation.Down).GetComposedRotation(TileRotation.Right);
            Assert.AreEqual(upRotated.Left, top);
            Assert.AreEqual(upRotated.Top, right);
            Assert.AreEqual(upRotated.Right, bottom);
            Assert.AreEqual(upRotated.Bottom, left);
        }
        
        [Test]
        public void LeftLeftRotated()
        {
            var left = new FacePart(FacePart.PartType.Any, FacePart.FaceColor.Any);
            var top = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Blue);
            var right = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Red);
            var bottom = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Any);
            var tile = new Tile(0, 0, left, top, right, bottom);
            
            var upRotated = new RotatedTile(tile, TileRotation.Left).GetComposedRotation(TileRotation.Left);
            Assert.AreEqual(upRotated.Left, right);
            Assert.AreEqual(upRotated.Top, bottom);
            Assert.AreEqual(upRotated.Right, left);
            Assert.AreEqual(upRotated.Bottom, top);
        }
        
        [Test]
        public void LeftRightRotated()
        {
            var left = new FacePart(FacePart.PartType.Any, FacePart.FaceColor.Any);
            var top = new FacePart(FacePart.PartType.Mouth, FacePart.FaceColor.Blue);
            var right = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Red);
            var bottom = new FacePart(FacePart.PartType.Eyes, FacePart.FaceColor.Any);
            var tile = new Tile(0, 0, left, top, right, bottom);
            
            var upRotated = new RotatedTile(tile, TileRotation.Left).GetComposedRotation(TileRotation.Right);
            Assert.AreEqual(upRotated.Left, left);
            Assert.AreEqual(upRotated.Top, top);
            Assert.AreEqual(upRotated.Right, right);
            Assert.AreEqual(upRotated.Bottom, bottom);
        }
    }
}