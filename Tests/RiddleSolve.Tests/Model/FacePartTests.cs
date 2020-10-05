using NUnit.Framework;
using RiddleSolve.Model;
using static RiddleSolve.Model.FacePart;

namespace RiddleSolve.Tests.Model
{
    public class FacePartTests
    {
        [Test]
        public void AnyAnyMatching()
        {
            var anyAny = new FacePart(PartType.Any, FaceColor.Any);
            var matching = anyAny.GetMatching();
            
            Assert.AreEqual(matching, new FacePart(PartType.Any, FaceColor.Any));
            Assert.AreNotEqual(matching, new FacePart(PartType.Any, FaceColor.Blue));
            Assert.AreNotEqual(matching, new FacePart(PartType.Eyes, FaceColor.Any));
            Assert.AreNotEqual(matching, new FacePart(PartType.Eyes, FaceColor.Blue));
            Assert.AreNotEqual(matching, new FacePart(PartType.Mouth, FaceColor.Any));
            Assert.AreNotEqual(matching, new FacePart(PartType.Mouth, FaceColor.Yellow));
        }

        [Test]
        public void MouthAnyMatching()
        {
            var mouthAny = new FacePart(PartType.Mouth, FaceColor.Any);
            var matching = mouthAny.GetMatching();
            
            Assert.AreEqual(matching, new FacePart(PartType.Eyes, FaceColor.Any));
            Assert.AreNotEqual(matching, new FacePart(PartType.Any, FaceColor.Any));
            Assert.AreNotEqual(matching, new FacePart(PartType.Any, FaceColor.Green));
            Assert.AreNotEqual(matching, new FacePart(PartType.Eyes, FaceColor.Green));
            Assert.AreNotEqual(matching, new FacePart(PartType.Mouth, FaceColor.Any));
            Assert.AreNotEqual(matching, new FacePart(PartType.Mouth, FaceColor.Blue));
        }

        [Test]
        public void MouthBlueMatching()
        {
            var mouthBlue = new FacePart(PartType.Mouth, FaceColor.Blue);
            var matching = mouthBlue.GetMatching();
            
            Assert.AreEqual(matching, new FacePart(PartType.Eyes, FaceColor.Blue));
            Assert.AreNotEqual(matching, new FacePart(PartType.Any, FaceColor.Any));
            Assert.AreNotEqual(matching, new FacePart(PartType.Any, FaceColor.Red));
            Assert.AreNotEqual(matching, new FacePart(PartType.Eyes, FaceColor.Any));
            Assert.AreNotEqual(matching, new FacePart(PartType.Eyes, FaceColor.Green));
            Assert.AreNotEqual(matching, new FacePart(PartType.Mouth, FaceColor.Any));
            Assert.AreNotEqual(matching, new FacePart(PartType.Mouth, FaceColor.Yellow));
        }

        [Test]
        public void AnyGreenMatching()
        {
            var anyGreen = new FacePart(PartType.Any, FaceColor.Green);
            var matching = anyGreen.GetMatching();
            
            Assert.AreNotEqual(matching, new FacePart(PartType.Any, FaceColor.Any));
            Assert.AreNotEqual(matching, new FacePart(PartType.Any, FaceColor.Blue));
            Assert.AreEqual(matching, new FacePart(PartType.Any, FaceColor.Green));
            Assert.AreNotEqual(matching, new FacePart(PartType.Eyes, FaceColor.Any));
            Assert.AreNotEqual(matching, new FacePart(PartType.Eyes, FaceColor.Green));
            Assert.AreNotEqual(matching, new FacePart(PartType.Eyes, FaceColor.Yellow));
            Assert.AreNotEqual(matching, new FacePart(PartType.Mouth, FaceColor.Any));
            Assert.AreNotEqual(matching, new FacePart(PartType.Mouth, FaceColor.Red));
            Assert.AreNotEqual(matching, new FacePart(PartType.Mouth, FaceColor.Green));
        }
    }
}