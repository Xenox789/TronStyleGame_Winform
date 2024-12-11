using Tron.Model;
using Tron.Persistence;
using Moq;

namespace Test
{
    [TestClass]
    public class GameModelTest
    {
        [TestMethod]
        public void Player_TurnLeft()
        {
            Player player = new Player(1, 0, 0, 1);
            player.LeftTurn();
            Assert.AreEqual(4, player.direction);
        }

        [TestMethod]
        public void Player_TurnRight()
        {
            Player player = new Player(1, 0, 0, 1);
            player.RightTurn();
            Assert.AreEqual(2, player.direction);
        }

        [TestMethod]
        public void Player_Move()
        {
            Player player = new Player(1, 0, 0, 3);
            player.Move();
            Assert.AreEqual(1, player.y);
        }

        [TestMethod]
        public void GameModel_CorrectGridSize()
        {
            int gridSize = 12;
            GameModel model = new GameModel(gridSize, 1);
            Assert.AreEqual(gridSize, model.gridsize);
        }

        [TestMethod]
        public void GameModel_BluePlayerWins()
        {
            int gridSize = 12;
            int[,] grid = new int[gridSize, gridSize];
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    grid[i, j] = 0;
                }
            }

            GameModel model = new GameModel(gridSize, 1, 0, 0, 1, 6, 6, 1, grid);
            // Blue Player wins by reaching the edge
            model.Advance(); // To move the players
            model.Advance(); // To check if hit something
            Assert.IsTrue(model.gameover);
        }

        [TestMethod]
        public void GameModel_RedPlayerWins()
        {
            int gridSize = 12;
            GameModel model = new GameModel(gridSize, 1);
            model.playerBlue.Setup(0, 0, 1); // Red Player wins by reaching the edge
            model.Advance();
            model.Advance();
            Assert.IsTrue(model.gameover);
        }

        [TestMethod]
        public async Task FileDataAccess_SaveAndLoad()
        {
            // Mock a Stream
            var stream = new Mock<Stream>();

            // Mock a StreamWriter
            var writer = new Mock<StreamWriter>(stream.Object);
            writer.Setup(w => w.WriteAsync(It.IsAny<string>())).Returns(Task.CompletedTask);
            writer.Setup(w => w.WriteLineAsync()).Returns(Task.CompletedTask);

            // Mock a StreamReader
            var reader = new Mock<StreamReader>(stream.Object);
            reader.Setup(r => r.ReadLineAsync()).ReturnsAsync("12 1 2 3 4 5 2");
            reader.Setup(r => r.ReadLineAsync()).ReturnsAsync("1 0 0 0 0 0 0");
            reader.Setup(r => r.ReadLineAsync()).ReturnsAsync("null");

            var fileDataAccess = new FileDataAccess();


            string filePath = "test.txt";
            GameModel modelToSave = new GameModel(12, 1);
            modelToSave.playerBlue.Setup(1, 2, 3);
            modelToSave.playerRed.Setup(4, 5, 2);
            modelToSave.grid[0, 0] = 1;

            await fileDataAccess.SaveAsync(filePath, modelToSave);
            GameModel loadedModel = await fileDataAccess.LoadAsync(filePath);

            Assert.AreEqual(modelToSave.gridsize, loadedModel.gridsize);
            Assert.AreEqual(modelToSave.playerBlue.x, loadedModel.playerBlue.x);
            Assert.AreEqual(modelToSave.playerBlue.y, loadedModel.playerBlue.y);
            Assert.AreEqual(modelToSave.playerRed.x, loadedModel.playerRed.x);
            Assert.AreEqual(modelToSave.playerRed.y, loadedModel.playerRed.y);
            Assert.AreEqual(modelToSave.grid[0, 0], loadedModel.grid[0, 0]);
        }
    }

}