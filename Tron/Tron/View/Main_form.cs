using System.ComponentModel;
using System.Numerics;
using Tron.Model;
using Tron.Persistence;

namespace Tron.View
{
    public delegate void Notify();

    public partial class Main_form : Form
    {

        private GameModel? model;
        private FileDataAccess _dataAccess;
        private int Level = 1;
        private bool BluePressed = false;
        private bool RedPressed = false;


        public Main_form()
        {
            InitializeComponent();

            gridsize_box.Items.Add("12x12");
            gridsize_box.Items.Add("24x24");
            gridsize_box.Items.Add("36x36");
            Game_panel.Size = new Size(730, 730);
            Menu_panel.Size = new Size(500, 500);
            BackColor = Color.Black;
            Menu_panel.BackColor = Color.Blue;
            Game_panel.BackColor = Color.Green;
            Game_panel.Location = new Point((ClientSize.Width - Game_panel.Width) / 2, (ClientSize.Height - Game_panel.Height) / 2);
            Menu_panel.Location = new Point((ClientSize.Width - Menu_panel.Width) / 2, (ClientSize.Height - Menu_panel.Height) / 2);
            Pause_panel.Location = new Point((ClientSize.Width - Pause_panel.Width) / 2, (ClientSize.Height - Pause_panel.Height) / 2);
            _dataAccess = new FileDataAccess();
        }



        private void Start_button_Click(object sender, EventArgs e)
        {
            int gridsize = gridsize_box.SelectedIndex;
            if (gridsize == -1)
            {
                MessageBox.Show("No gridsize selected.");
            }
            else
            {
                gridsize = (gridsize + 1) * 12; //combobox row number and meanings are: 0 = "12x12" , 1 = "24x24", 2 = "36x36"
                Menu_panel.Enabled = false;
                Menu_panel.Visible = false;
                Level = 1;
                Level_Text.Text = "Level: " + Level;
                Level_Text.Visible = true;
                model = new GameModel(gridsize, Level);
                Game_panel.Visible = true;
                timer.Interval = 800;
                leveltimer.Interval = 4000;
                model.Advance();
                Refill();
                Thread.Sleep(1000);
                timer.Start();
                leveltimer.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (model != null)
            { 
                if(model.gameover)
                {
                    timer.Stop();
                    leveltimer.Stop();
                    GameOver(model.winner);
                }
                RedPressed = false;
                BluePressed = false;
                model.Advance();
                Refill();
            }
        }

        private void leveltimer_Tick(object sender, EventArgs e)
        {
            if (model != null)
            {

                Level_Text.Text = "Level: " + Level;
                if (Level < 19) { Level += 1; }
                timer.Interval = 800 - Level * 40;
                model.level = Level;
            }
        }

        private void Main_form_KeyDown(object sender, KeyEventArgs e)
        {
            if (model != null)
            {
                if (e.KeyCode == Keys.A && !BluePressed)
                {
                    model.playerBlue.LeftTurn();
                    BluePressed = true;

                }
                if (e.KeyCode == Keys.D && !BluePressed)
                {
                    model.playerBlue.RightTurn();
                    BluePressed = true;
                }
                if (e.KeyCode == Keys.Left && !RedPressed)
                {
                    model.playerRed.LeftTurn();
                    RedPressed = true;
                }
                if (e.KeyCode == Keys.Right && !RedPressed)
                {
                    model.playerRed.RightTurn();
                    RedPressed = true;
                }
                if (e.KeyCode == Keys.Space)
                {
                    timer.Stop();
                    leveltimer.Stop();
                    Pause_panel.Visible = true;
                    Pause_panel.Enabled = true;
                }
            }
        }

        private void Resume_button_Click(object sender, EventArgs e)
        {
            Pause_panel.Enabled = false;
            Pause_panel.Visible = false;
            timer.Start();
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            Pause_panel.Enabled = false; Pause_panel.Visible = false;
            Game_panel.Enabled = false; Game_panel.Visible = false;
            Menu_panel.Enabled = true; Menu_panel.Visible = true;
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void Save_button_Click(object sender, EventArgs e)
        {
            if (model != null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
                    saveFileDialog.Title = "Save a Text File";
                    saveFileDialog.FileName = "SaveFile.txt";

                    DialogResult result = saveFileDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        await _dataAccess.SaveAsync(filePath, model);
                    }
                }
            }
        }

        private async void Load_button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a File";
                openFileDialog.Filter = "Text Files|*.txt";

                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    model = await _dataAccess.LoadAsync(filePath);
                }
            }

            if (model != null)
            {

                Menu_panel.Enabled = false;
                Menu_panel.Visible = false;
                Game_panel.Visible = true;
                Level = model.level;
                timer.Interval = 1000 - (Level - 1) * 50;
                leveltimer.Interval = 5000;
                model.Advance();
                Refill();
                Thread.Sleep(1000);
                timer.Start();
                leveltimer.Start();
            }

        }

        

        private void Refill()
        {
            if (model != null)
            {
                int blocksize = (Game_panel.Width - 10) / model.gridsize;
                Color color = new Color();
                int x1, y1, x2, y2;
                using (Graphics g = Game_panel.CreateGraphics())
                {
                    for (int i = 0; i < model.gridsize; i++)
                    {
                        for (int j = 0; j < model.gridsize; j++)
                        {
                            if (model.grid[i, j] == 0)
                            {
                                color = Color.Black;
                            }
                            else if (model.grid[i, j] == 1)
                            {
                                color = Color.Blue;
                            }
                            else if (model.grid[i, j] == 2)
                            {
                                color = Color.Red;
                            }
                            using (SolidBrush brush = new SolidBrush(color))
                            {
                                x1 = i * blocksize + 5;
                                y1 = j * blocksize + 5;
                                x2 = blocksize;
                                y2 = blocksize;
                                Rectangle rect = new Rectangle(x1, y1, x2, y2);
                                g.FillRectangle(brush, rect);
                            }
                        }
                    }
                }
            }
        }
        public void GameOver(int id)
        {

            //If Blue hit something
            if (id == 1)
            {
                MessageBox.Show("Game Over." + "Red Won");
                Game_panel.Enabled = false; Game_panel.Visible = false;
                Menu_panel.Enabled = true; Menu_panel.Visible = true;
                Level_Text.Text = "Level: ";
                Level_Text.Visible = false;
            }
            //If Red hit something
            else if (id == 2)
            {
                MessageBox.Show("Game Over." + "Blue Won");
                Game_panel.Enabled = false; Game_panel.Visible = false;
                Menu_panel.Enabled = true; Menu_panel.Visible = true;
                Level_Text.Text = "Level: ";
                Level_Text.Visible = false;
            }
            else
            {
                throw new Exception("Bad player id");
            }
        }
    }
}