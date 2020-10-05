using NUnit.Framework;
using RiddleSolve.Model;

namespace RiddleSolve.Tests.Model
{
    public class PositionTests
    {
        [Test]
        public void EqualityTest()
        {
            Assert.AreEqual(new Position(0, 0), new Position(0, 0));
            Assert.AreNotEqual(new Position(1, 0), new Position(0, 0));
            Assert.AreNotEqual(new Position(0, 0), new Position(1, 0));
            Assert.AreNotEqual(new Position(0, 1), new Position(1, 0));
        }
        
        [Test]
        public void ArithmeticsTest()
        {
            var one = new Position(1, 1);
            
            Assert.AreEqual(one + (1, 1), new Position(2, 2));
            Assert.AreEqual(one + (1, 2), new Position(2, 3));
            Assert.AreEqual(one * 2, new Position(2, 2));
            Assert.AreEqual(one * (1, 2), new Position(1, 2));
            Assert.AreEqual(one - (1, 1), new Position(0, 0));
            Assert.AreEqual(one - (2, 1), new Position(-1, 0));
        }
        
        [Test]
        public void ArrayIterationTest()
        {
            var array = new int[3, 4];
            
            for (int i = 0; i < array.GetLength(0); i++)
            for (int j = 0; j < array.GetLength(1); j++)
                Assert.IsTrue(new Position(i, j).IsInside(array));
        }
        
        [Test]
        public void ArrayPositionIterationTest()
        {
            var array = new int[3, 4];

            var currentIndex = 0;
            for (Position position = (0, 0);
                 position.IsInside(array);
                 position = position.GetNext(array))
            {
                Assert.AreEqual(currentIndex, position.GetIndex(array));
                currentIndex++;
            }
            
            Assert.AreEqual(currentIndex, array.Length);
        }
    }
}