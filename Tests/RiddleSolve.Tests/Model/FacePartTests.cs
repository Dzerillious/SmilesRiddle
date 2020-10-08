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
            
            Assert.AreEqual(new FacePart(PartType.Any, FaceColor.Any), matching);
            Assert.AreNotEqual(new FacePart(PartType.Any, FaceColor.Blue), matching);
            Assert.AreNotEqual(new FacePart(PartType.Eyes, FaceColor.Any), matching);
            Assert.AreNotEqual(new FacePart(PartType.Eyes, FaceColor.Blue), matching);
            Assert.AreNotEqual(new FacePart(PartType.Mouth, FaceColor.Any), matching);
            Assert.AreNotEqual(new FacePart(PartType.Mouth, FaceColor.Yellow), matching);
        }

        [Test]
        public void MouthAnyMatching()
        {
            var mouthAny = new FacePart(PartType.Mouth, FaceColor.Any);
            var matching = mouthAny.GetMatching();
            
            Assert.AreEqual(new FacePart(PartType.Eyes, FaceColor.Any), matching);
            Assert.AreNotEqual(new FacePart(PartType.Any, FaceColor.Any), matching);
            Assert.AreNotEqual(new FacePart(PartType.Any, FaceColor.Green), matching);
            Assert.AreNotEqual(new FacePart(PartType.Eyes, FaceColor.Green), matching);
            Assert.AreNotEqual(new FacePart(PartType.Mouth, FaceColor.Any), matching);
            Assert.AreNotEqual(new FacePart(PartType.Mouth, FaceColor.Blue), matching);
        }

        [Test]
        public void MouthBlueMatching()
        {
            var mouthBlue = new FacePart(PartType.Mouth, FaceColor.Blue);
            var matching = mouthBlue.GetMatching();
            
            Assert.AreEqual(new FacePart(PartType.Eyes, FaceColor.Blue), matching);
            Assert.AreNotEqual(new FacePart(PartType.Any, FaceColor.Any), matching);
            Assert.AreNotEqual(new FacePart(PartType.Any, FaceColor.Red), matching);
            Assert.AreNotEqual(new FacePart(PartType.Eyes, FaceColor.Any), matching);
            Assert.AreNotEqual(new FacePart(PartType.Eyes, FaceColor.Green), matching);
            Assert.AreNotEqual(new FacePart(PartType.Mouth, FaceColor.Any), matching);
            Assert.AreNotEqual(new FacePart(PartType.Mouth, FaceColor.Yellow), matching);
        }

        [Test]
        public void AnyGreenMatching()
        {
            var anyGreen = new FacePart(PartType.Any, FaceColor.Green);
            var matching = anyGreen.GetMatching();
            
            Assert.AreNotEqual(new FacePart(PartType.Any, FaceColor.Any), matching);
            Assert.AreNotEqual(new FacePart(PartType.Any, FaceColor.Blue), matching);
            Assert.AreEqual(new FacePart(PartType.Any, FaceColor.Green), matching);
            Assert.AreNotEqual(new FacePart(PartType.Eyes, FaceColor.Any), matching);
            Assert.AreNotEqual(new FacePart(PartType.Eyes, FaceColor.Green), matching);
            Assert.AreNotEqual(new FacePart(PartType.Eyes, FaceColor.Yellow), matching);
            Assert.AreNotEqual(new FacePart(PartType.Mouth, FaceColor.Any), matching);
            Assert.AreNotEqual(new FacePart(PartType.Mouth, FaceColor.Red), matching);
            Assert.AreNotEqual(new FacePart(PartType.Mouth, FaceColor.Green), matching);
        }
    }
}