using NUnit.Framework;
using RiddleSolve.Calculation;
using RiddleSolve.Model;
using static RiddleSolve.Model.FacePart;

namespace RiddleSolve.Tests.Calculation
{
    public class SolverTests
    {
        [Test]
        public void Solve11Test()
        {
            var analysis = Analyser.Analyze(new ITile[,]
            {
                {
                    new Tile((0, 0),
                             new FacePart(PartType.Eyes, FaceColor.Green),
                             new FacePart(PartType.Eyes, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue))
                }
            });
            var board = new ITile[1, 1];
            var foundSolution = new Solver().Solve(board, analysis);
            
            Assert.AreEqual(true, foundSolution);
            CheckSolution(board);
        }
        
        [Test]
        public void Solve12Test()
        {
            var analysis = Analyser.Analyze(new ITile[,]
            {
                {
                    new Tile((0, 0),
                             new FacePart(PartType.Eyes, FaceColor.Green),
                             new FacePart(PartType.Eyes, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue)),
                    new Tile((0, 1),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Mouth, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue))
                }
            });
            var board = new ITile[1, 2];
            var foundSolution = new Solver().Solve(board, analysis);
            
            Assert.AreEqual(true, foundSolution);
            CheckSolution(board);
        }
        
        [Test]
        public void Solve21Test()
        {
            var analysis = Analyser.Analyze(new ITile[,]
            {
                {
                    new Tile((0, 0),
                             new FacePart(PartType.Eyes, FaceColor.Green),
                             new FacePart(PartType.Eyes, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue)),
                },
                {
                    new Tile((1, 0),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Mouth, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue))
                }
            });
            var board = new ITile[2, 1];
            var foundSolution = new Solver().Solve(board, analysis);
            
            Assert.AreEqual(true, foundSolution);
            CheckSolution(board);
        }
        
        [Test]
        public void SolveFailTest()
        {
            var analysis = Analyser.Analyze(new ITile[,]
            {
                {
                    new Tile((0, 0),
                             new FacePart(PartType.Eyes, FaceColor.Green),
                             new FacePart(PartType.Eyes, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue)),
                },
                {
                    new Tile((1, 0),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Red),
                             new FacePart(PartType.Eyes, FaceColor.Green),
                             new FacePart(PartType.Eyes, FaceColor.Blue))
                }
            });
            var board = new ITile[2, 1];
            var foundSolution = new Solver().Solve(board, analysis);
            
            Assert.AreEqual(false, foundSolution);
        }
        
        [Test]
        public void Solve22Test()
        {
            var analysis = Analyser.Analyze(new ITile[,]
            {
                {
                    new Tile((0, 0),
                             new FacePart(PartType.Eyes, FaceColor.Green),
                             new FacePart(PartType.Eyes, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue)),
                    new Tile((0, 1),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue))
                },
                {
                    new Tile((1, 0),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Mouth, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue)),
                    new Tile((1, 1),
                             new FacePart(PartType.Mouth, FaceColor.Green),
                             new FacePart(PartType.Mouth, FaceColor.Blue),
                             new FacePart(PartType.Eyes, FaceColor.Yellow),
                             new FacePart(PartType.Mouth, FaceColor.Yellow)),
                }
            });
            var board = new ITile[2, 2];
            var foundSolution = new Solver().Solve(board, analysis);
            
            Assert.AreEqual(true, foundSolution);
            CheckSolution(board);
        }

        private void CheckSolution(ITile[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);
            
            for (var row = 0; row < rows; row++)
            for (var column = 0; column < columns; column++)
            {
                var tile = board[row, column];
                if (column + 1 < columns)
                {
                    var rightTile = board[row, column + 1];
                    Assert.AreEqual(tile.Right, rightTile.Left.GetMatching());
                }
                if (row + 1 < rows)
                {
                    var bottomTile = board[row + 1, column];
                    Assert.AreEqual(tile.Bottom, bottomTile.Top.GetMatching());
                }
            }
        }
    }
}