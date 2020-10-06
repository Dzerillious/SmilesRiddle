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
            var analysis = Analyser.Analyze(new[,]
            {
                {
                    new Tile(0, 0,
                             new FacePart(PartType.Eyes, FaceColor.Green),
                             new FacePart(PartType.Eyes, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue))
                }
            });
            var board = new RotatedTile[1, 1];
            var foundSolution = Solver.Solve(board, analysis, (0, 0));
            
            Assert.AreEqual(foundSolution, true);
            CheckSolution(board);
        }
        
        [Test]
        public void Solve12Test()
        {
            var analysis = Analyser.Analyze(new[,]
            {
                {
                    new Tile(0, 0,
                             new FacePart(PartType.Eyes, FaceColor.Green),
                             new FacePart(PartType.Eyes, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue)),
                    new Tile(0, 1,
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Mouth, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue))
                }
            });
            var board = new RotatedTile[1, 2];
            var foundSolution = Solver.Solve(board, analysis, (0, 0));
            
            Assert.AreEqual(foundSolution, true);
            CheckSolution(board);
        }
        
        [Test]
        public void Solve21Test()
        {
            var analysis = Analyser.Analyze(new[,]
            {
                {
                    new Tile(0, 0,
                             new FacePart(PartType.Eyes, FaceColor.Green),
                             new FacePart(PartType.Eyes, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue)),
                },
                {
                    new Tile(1, 0,
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Mouth, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue))
                }
            });
            var board = new RotatedTile[2, 1];
            var foundSolution = Solver.Solve(board, analysis, (0, 0));
            
            Assert.AreEqual(foundSolution, true);
            CheckSolution(board);
        }
        
        [Test]
        public void SolveFailTest()
        {
            var analysis = Analyser.Analyze(new[,]
            {
                {
                    new Tile(0, 0,
                             new FacePart(PartType.Eyes, FaceColor.Green),
                             new FacePart(PartType.Eyes, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue)),
                },
                {
                    new Tile(1, 0,
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Red),
                             new FacePart(PartType.Eyes, FaceColor.Green),
                             new FacePart(PartType.Eyes, FaceColor.Blue))
                }
            });
            var board = new RotatedTile[2, 1];
            var foundSolution = Solver.Solve(board, analysis, (0, 0));
            
            Assert.AreEqual(foundSolution, false);
        }
        
        [Test]
        public void Solve22Test()
        {
            var analysis = Analyser.Analyze(new[,]
            {
                {
                    new Tile(0, 0,
                             new FacePart(PartType.Eyes, FaceColor.Green),
                             new FacePart(PartType.Eyes, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue)),
                    new Tile(0, 1,
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue))
                },
                {
                    new Tile(1, 0,
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Mouth, FaceColor.Red),
                             new FacePart(PartType.Mouth, FaceColor.Yellow),
                             new FacePart(PartType.Eyes, FaceColor.Blue)),
                    new Tile(1, 1,
                             new FacePart(PartType.Mouth, FaceColor.Green),
                             new FacePart(PartType.Mouth, FaceColor.Blue),
                             new FacePart(PartType.Eyes, FaceColor.Yellow),
                             new FacePart(PartType.Mouth, FaceColor.Yellow)),
                }
            });
            var board = new RotatedTile[2, 2];
            var foundSolution = Solver.Solve(board, analysis, (0, 0));
            
            Assert.AreEqual(foundSolution, true);
            CheckSolution(board);
        }

        private void CheckSolution(RotatedTile[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);
            
            for (var row = 0; row < rows - 1; row++)
            for (var column = 0; column < columns - 1; column++)
            {
                var tile = board[row, column];
                var rightTile = board[row, column + 1];
                var bottomTile = board[row + 1, column];
                Assert.AreEqual(tile.Right, rightTile.Left.GetMatching());
                Assert.AreEqual(tile.Bottom, bottomTile.Top.GetMatching());
            }
        }
    }
}