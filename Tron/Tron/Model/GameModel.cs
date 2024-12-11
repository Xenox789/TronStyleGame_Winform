using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Media;
//using System.Security.Cryptography.X509Certificates;
using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Serialization;
using Tron.Persistence;

namespace Tron.Model
{
    public class GameModel
    {
        public int gridsize { get; set; }
        public int level { get; set; }
        public int[,] grid { get; set; }
        public Player playerBlue { get; private set; }
        public Player playerRed { get; private set; }
        public bool gameover { get; private set; }
        public int winner { get; private set; }



        public GameModel(int gridsize, int level)
        {
            this.gridsize = gridsize;
            this.level = level;
            grid = new int[gridsize, gridsize];
            playerBlue = new Player(1, 0, gridsize / 2 - 1, 2);
            playerRed = new Player(2, gridsize - 1, gridsize / 2 - 1, 4);

            for (int x = 0; x < gridsize - 1; x++)
            {
                for (int y = 0; y < gridsize - 1; y++)
                {
                    grid[x, y] = 0;
                }
            }
            gameover = false;

        }
        public GameModel(int gridsize, int level, int bluePX, int bluePY, int bluePDir, int redPX, int redPY, int redPDir, int[,] grid)
        {
            this.gridsize = gridsize;
            this.level = level;
            this.grid = grid;
            playerBlue = new Player(1, bluePX, bluePY, bluePDir);
            playerRed = new Player(2, redPX, redPY, redPDir);

            gameover = false;
        }


        private void Hit()
        {

            //Checking if the players were outside

            if (playerBlue.x < 0 || playerBlue.y < 0 || playerBlue.x >= gridsize || playerBlue.y >= gridsize)
            {
                gameover = true;
                winner = 1;
            }

            else if (playerRed.x < 0 || playerRed.y < 0 || playerRed.x >= gridsize || playerRed.y >= gridsize)
            {
                gameover = true;
                winner = 2;
            }

            // Checking if the players hit eachother
            else if (grid[playerBlue.x, playerBlue.y] != 0)
            {
                gameover = true;
                winner = 1;
            }
            else if (grid[playerRed.x, playerRed.y] != 0)
            {
                gameover = true;
                winner = 2;
            }

            //Setting the proper value to the grid spaces

            else
            {
                grid[playerBlue.x, playerBlue.y] = 1;
                grid[playerRed.x, playerRed.y] = 2;
            }
        }

        public void Advance()
        {
            if (!gameover)
            {
                Hit();
                playerBlue.Move();
                playerRed.Move();
            }
        }
    }
}
