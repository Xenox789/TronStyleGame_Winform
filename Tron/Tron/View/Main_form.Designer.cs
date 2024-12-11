namespace Tron.View
{
    partial class Main_form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Text_label = new Label();
            Size_label = new Label();
            gridsize_box = new ComboBox();
            Start_button = new Button();
            Load_button = new Button();
            Game_panel = new Panel();
            timer = new System.Windows.Forms.Timer(components);
            Menu_panel = new Panel();
            Close_button = new Button();
            Pause_label = new Label();
            Save_button = new Button();
            Resume_button = new Button();
            Exit_button = new Button();
            Pause_panel = new Panel();
            leveltimer = new System.Windows.Forms.Timer(components);
            Level_Text = new Label();
            Menu_panel.SuspendLayout();
            Pause_panel.SuspendLayout();
            SuspendLayout();
            // 
            // Text_label
            // 
            Text_label.AutoSize = true;
            Text_label.Font = new Font("Stencil", 60F, FontStyle.Italic, GraphicsUnit.Point);
            Text_label.Location = new Point(125, 48);
            Text_label.Name = "Text_label";
            Text_label.Size = new Size(249, 95);
            Text_label.TabIndex = 0;
            Text_label.Text = "Tron";
            // 
            // Size_label
            // 
            Size_label.AutoSize = true;
            Size_label.Font = new Font("Showcard Gothic", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            Size_label.Location = new Point(224, 172);
            Size_label.Name = "Size_label";
            Size_label.Size = new Size(51, 21);
            Size_label.TabIndex = 1;
            Size_label.Text = "Size:";
            // 
            // gridsize_box
            // 
            gridsize_box.FormattingEnabled = true;
            gridsize_box.Location = new Point(187, 196);
            gridsize_box.Name = "gridsize_box";
            gridsize_box.Size = new Size(121, 23);
            gridsize_box.TabIndex = 2;
            // 
            // Start_button
            // 
            Start_button.Location = new Point(187, 245);
            Start_button.Name = "Start_button";
            Start_button.Size = new Size(121, 36);
            Start_button.TabIndex = 3;
            Start_button.Text = "Start";
            Start_button.UseVisualStyleBackColor = true;
            Start_button.Click += Start_button_Click;
            // 
            // Load_button
            // 
            Load_button.Location = new Point(187, 287);
            Load_button.Name = "Load_button";
            Load_button.Size = new Size(121, 36);
            Load_button.TabIndex = 4;
            Load_button.Text = "Load";
            Load_button.UseVisualStyleBackColor = true;
            Load_button.Click += Load_button_Click;
            // 
            // Game_panel
            // 
            Game_panel.Anchor = AnchorStyles.None;
            Game_panel.Location = new Point(277, 12);
            Game_panel.MinimumSize = new Size(360, 360);
            Game_panel.Name = "Game_panel";
            Game_panel.Size = new Size(720, 720);
            Game_panel.TabIndex = 5;
            Game_panel.Visible = false;
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // Menu_panel
            // 
            Menu_panel.Anchor = AnchorStyles.None;
            Menu_panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Menu_panel.Controls.Add(Close_button);
            Menu_panel.Controls.Add(Size_label);
            Menu_panel.Controls.Add(gridsize_box);
            Menu_panel.Controls.Add(Text_label);
            Menu_panel.Controls.Add(Load_button);
            Menu_panel.Controls.Add(Start_button);
            Menu_panel.Location = new Point(427, 100);
            Menu_panel.Name = "Menu_panel";
            Menu_panel.Size = new Size(500, 500);
            Menu_panel.TabIndex = 0;
            // 
            // Close_button
            // 
            Close_button.Location = new Point(187, 388);
            Close_button.Name = "Close_button";
            Close_button.Size = new Size(121, 36);
            Close_button.TabIndex = 5;
            Close_button.Text = "Close";
            Close_button.UseVisualStyleBackColor = true;
            Close_button.Click += Close_button_Click;
            // 
            // Pause_label
            // 
            Pause_label.AutoSize = true;
            Pause_label.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            Pause_label.Location = new Point(116, 13);
            Pause_label.Name = "Pause_label";
            Pause_label.Size = new Size(86, 30);
            Pause_label.TabIndex = 0;
            Pause_label.Text = "PAUSE";
            // 
            // Save_button
            // 
            Save_button.Location = new Point(35, 95);
            Save_button.Name = "Save_button";
            Save_button.Size = new Size(80, 36);
            Save_button.TabIndex = 1;
            Save_button.Text = "Save";
            Save_button.UseVisualStyleBackColor = true;
            Save_button.Click += Save_button_Click;
            // 
            // Resume_button
            // 
            Resume_button.Location = new Point(116, 53);
            Resume_button.Name = "Resume_button";
            Resume_button.Size = new Size(80, 36);
            Resume_button.TabIndex = 2;
            Resume_button.Text = "Resume";
            Resume_button.UseVisualStyleBackColor = true;
            Resume_button.Click += Resume_button_Click;
            // 
            // Exit_button
            // 
            Exit_button.Location = new Point(198, 95);
            Exit_button.Name = "Exit_button";
            Exit_button.Size = new Size(80, 36);
            Exit_button.TabIndex = 3;
            Exit_button.Text = "Exit";
            Exit_button.UseVisualStyleBackColor = true;
            Exit_button.Click += Exit_button_Click;
            // 
            // Pause_panel
            // 
            Pause_panel.Anchor = AnchorStyles.None;
            Pause_panel.Controls.Add(Exit_button);
            Pause_panel.Controls.Add(Resume_button);
            Pause_panel.Controls.Add(Save_button);
            Pause_panel.Controls.Add(Pause_label);
            Pause_panel.Enabled = false;
            Pause_panel.Location = new Point(201, 250);
            Pause_panel.Name = "Pause_panel";
            Pause_panel.Size = new Size(300, 150);
            Pause_panel.TabIndex = 0;
            Pause_panel.Visible = false;
            // 
            // leveltimer
            // 
            leveltimer.Interval = 5000;
            leveltimer.Tick += leveltimer_Tick;
            // 
            // Level_Text
            // 
            Level_Text.AutoSize = true;
            Level_Text.BorderStyle = BorderStyle.FixedSingle;
            Level_Text.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            Level_Text.ForeColor = SystemColors.MenuHighlight;
            Level_Text.Location = new Point(1003, 27);
            Level_Text.Name = "Level_Text";
            Level_Text.Size = new Size(69, 26);
            Level_Text.TabIndex = 6;
            Level_Text.Text = "Level:";
            Level_Text.Visible = false;
            // 
            // Main_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1238, 761);
            Controls.Add(Level_Text);
            Controls.Add(Pause_panel);
            Controls.Add(Menu_panel);
            Controls.Add(Game_panel);
            MinimumSize = new Size(500, 400);
            Name = "Main_form";
            Text = "Fénymotor párbaj";
            KeyDown += Main_form_KeyDown;
            Menu_panel.ResumeLayout(false);
            Menu_panel.PerformLayout();
            Pause_panel.ResumeLayout(false);
            Pause_panel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();



        }

        #endregion

        private Label Text_label;
        private Label Size_label;
        private ComboBox gridsize_box;
        private Button Start_button;
        private Button Load_button;
        private Panel Game_panel;
        public System.Windows.Forms.Timer timer;
        private Panel Menu_panel;
        private Label Pause_label;
        private Button Save_button;
        private Button Resume_button;
        private Button Exit_button;
        private Panel Pause_panel;
        private Button Close_button;
        public System.Windows.Forms.Timer leveltimer;
        private Label Level_Text;
    }
}