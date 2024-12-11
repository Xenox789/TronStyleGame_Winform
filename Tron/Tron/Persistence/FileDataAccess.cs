using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tron.Model;

namespace Tron.Persistence
{
    public class FileDataAccess
    {
        public async Task<GameModel> LoadAsync(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path)) // fájl megnyitása
                {
                    string line = await reader.ReadLineAsync() ?? string.Empty;
                    string[] numbers = line.Split(' '); // beolvasunk egy sort, és a szóköz mentén elválasztjuk azokat
                    // hibaellenőrzés 
                    int arraySize = numbers.Length;

                    if (arraySize != 8)
                    {
                        throw new FormatException("Wrong file format. First line must be included 7 numbers: \n" +
                            "{gridsize level player1_x player1_y player1_dr player2_x player2_y player2_dr}\nopposite of " + arraySize + "!");
                    }

                    int gridSize = int.Parse(numbers[0]); // beolvassuk a tábla méretét 12, 24 vagy csak 36 lehet

                    if (gridSize != 12 && gridSize != 24 && gridSize != 36)
                    {
                        throw new FormatException("Loaded gridsize not acceptable (12/24/36): " + gridSize);
                    }
                    int Level = int.Parse(numbers[1]);
                    int bluePlayerX = int.Parse(numbers[2]);
                    int bluePlayerY = int.Parse(numbers[3]);
                    int bluePlayerDir = int.Parse(numbers[4]);
                    int redPlayerX = int.Parse(numbers[5]);
                    int redPlayerY = int.Parse(numbers[6]);
                    int redPlayerDir = int.Parse(numbers[7]);

                    if (bluePlayerX < 1 || bluePlayerX > gridSize ||
                        bluePlayerY < 1 || bluePlayerY > gridSize ||
                        redPlayerX < 1 || redPlayerX > gridSize ||
                        redPlayerY < 1 || redPlayerY > gridSize ||
                        Level < 1 || Level > 19
                        )
                    {
                        throw new FormatException("Not acceptable level or player data: ");
                    }

                    int[,] grid = new int[gridSize, gridSize];
                    arraySize = 0;

                    for (int i = 0; i < gridSize; i++)
                    {
                        line = await reader.ReadLineAsync() ?? string.Empty;
                        numbers = line.Split(' ');
                        arraySize = numbers.Length;

                        if (arraySize != gridSize + 1)
                        {
                            throw new FormatException("Wrong file format. Field size have to " + gridSize + " ,opposite of " + arraySize);
                        }
                        int value;
                        for (int j = 0; j < gridSize; j++)
                        {
                            value = int.Parse(numbers[j]);
                            if (value != 0 && value != 1 && value != 2)
                            {
                                throw new FormatException("Wrong playfield value in file. Field value must be 0,1 or 2 ; opposite of " + value);
                            }
                            grid[i, j] = value;
                        }
                    }

                    GameModel model = new GameModel(gridSize, Level, bluePlayerX, bluePlayerY, bluePlayerDir, redPlayerX, redPlayerY, redPlayerDir, grid); // létrehozzuk a táblát
                    return model;
                }
            }

            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception(ex.Message);
            }
        }


        public async Task SaveAsync(string path, GameModel model)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path)) // fájl megnyitása
                {
                    writer.Write(model.gridsize + " " + model.level + " " + model.playerBlue.x + " " + model.playerBlue.y + " " + model.playerBlue.direction + " " + model.playerRed.x + " " + model.playerRed.y + " " + model.playerRed.direction); // kiírjuk a méreteket
                    await writer.WriteLineAsync();

                    for (int i = 0; i < model.gridsize; i++)
                    {
                        for (int j = 0; j < model.gridsize; j++)
                        {
                            await writer.WriteAsync(model.grid[i, j] + " "); // kiírjuk az értékeket
                        }
                        await writer.WriteLineAsync();
                    }
                }
            }
            catch
            {
                throw new Exception("Something went wrong with save.");
            }
        }
    }
}
