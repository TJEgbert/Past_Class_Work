namespace DiceGame
{
    partial class Form1
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
            gb_gameState = new GroupBox();
            lbl_numLost = new Label();
            lbl_timesLost = new Label();
            lbl_numWon = new Label();
            lbl_timesWon = new Label();
            lbl_numPlayed = new Label();
            lbl_timePlayed = new Label();
            lbl_guess = new Label();
            cmd_Roll = new Button();
            cmd_reset = new Button();
            txt_guess = new TextBox();
            lbl_invalidGuess = new Label();
            pb_dieImage = new PictureBox();
            rtb_gameStats = new RichTextBox();
            gb_gameState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_dieImage).BeginInit();
            SuspendLayout();
            // 
            // gb_gameState
            // 
            gb_gameState.Controls.Add(lbl_numLost);
            gb_gameState.Controls.Add(lbl_timesLost);
            gb_gameState.Controls.Add(lbl_numWon);
            gb_gameState.Controls.Add(lbl_timesWon);
            gb_gameState.Controls.Add(lbl_numPlayed);
            gb_gameState.Controls.Add(lbl_timePlayed);
            gb_gameState.Location = new Point(12, 24);
            gb_gameState.Name = "gb_gameState";
            gb_gameState.Size = new Size(206, 118);
            gb_gameState.TabIndex = 0;
            gb_gameState.TabStop = false;
            gb_gameState.Text = "Game State";
            // 
            // lbl_numLost
            // 
            lbl_numLost.AutoSize = true;
            lbl_numLost.Location = new Point(187, 87);
            lbl_numLost.Name = "lbl_numLost";
            lbl_numLost.Size = new Size(13, 15);
            lbl_numLost.TabIndex = 5;
            lbl_numLost.Text = "0";
            // 
            // lbl_timesLost
            // 
            lbl_timesLost.AutoSize = true;
            lbl_timesLost.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_timesLost.Location = new Point(6, 85);
            lbl_timesLost.Name = "lbl_timesLost";
            lbl_timesLost.Size = new Size(160, 19);
            lbl_timesLost.TabIndex = 4;
            lbl_timesLost.Text = "Number of Times Lost:";
            // 
            // lbl_numWon
            // 
            lbl_numWon.AutoSize = true;
            lbl_numWon.Location = new Point(187, 58);
            lbl_numWon.Name = "lbl_numWon";
            lbl_numWon.Size = new Size(13, 15);
            lbl_numWon.TabIndex = 3;
            lbl_numWon.Text = "0";
            // 
            // lbl_timesWon
            // 
            lbl_timesWon.AutoSize = true;
            lbl_timesWon.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_timesWon.Location = new Point(6, 56);
            lbl_timesWon.Name = "lbl_timesWon";
            lbl_timesWon.Size = new Size(158, 19);
            lbl_timesWon.TabIndex = 2;
            lbl_timesWon.Text = "Number of Time Won:";
            // 
            // lbl_numPlayed
            // 
            lbl_numPlayed.AutoSize = true;
            lbl_numPlayed.Location = new Point(187, 31);
            lbl_numPlayed.Name = "lbl_numPlayed";
            lbl_numPlayed.Size = new Size(13, 15);
            lbl_numPlayed.TabIndex = 1;
            lbl_numPlayed.Text = "0";
            // 
            // lbl_timePlayed
            // 
            lbl_timePlayed.AutoSize = true;
            lbl_timePlayed.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_timePlayed.Location = new Point(6, 27);
            lbl_timePlayed.Name = "lbl_timePlayed";
            lbl_timePlayed.Size = new Size(179, 19);
            lbl_timePlayed.TabIndex = 0;
            lbl_timePlayed.Text = "Number of Times Played:";
            // 
            // lbl_guess
            // 
            lbl_guess.AutoSize = true;
            lbl_guess.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_guess.Location = new Point(224, 35);
            lbl_guess.Name = "lbl_guess";
            lbl_guess.Size = new Size(146, 19);
            lbl_guess.TabIndex = 1;
            lbl_guess.Text = "Enter your guess (1-6)";
            // 
            // cmd_Roll
            // 
            cmd_Roll.Location = new Point(345, 119);
            cmd_Roll.Name = "cmd_Roll";
            cmd_Roll.Size = new Size(96, 23);
            cmd_Roll.TabIndex = 2;
            cmd_Roll.Text = "Roll Dice";
            cmd_Roll.UseVisualStyleBackColor = true;
            cmd_Roll.Click += cmd_Roll_Click;
            // 
            // cmd_reset
            // 
            cmd_reset.Location = new Point(345, 171);
            cmd_reset.Name = "cmd_reset";
            cmd_reset.Size = new Size(96, 23);
            cmd_reset.TabIndex = 3;
            cmd_reset.Text = "Reset Game";
            cmd_reset.UseVisualStyleBackColor = true;
            cmd_reset.Click += cmd_reset_Click;
            // 
            // txt_guess
            // 
            txt_guess.Location = new Point(390, 35);
            txt_guess.MaxLength = 1;
            txt_guess.Name = "txt_guess";
            txt_guess.Size = new Size(51, 23);
            txt_guess.TabIndex = 4;
            txt_guess.TextChanged += txt_guess_TextChanged;
            // 
            // lbl_invalidGuess
            // 
            lbl_invalidGuess.AutoSize = true;
            lbl_invalidGuess.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_invalidGuess.ForeColor = Color.Red;
            lbl_invalidGuess.Location = new Point(242, 71);
            lbl_invalidGuess.Name = "lbl_invalidGuess";
            lbl_invalidGuess.Size = new Size(0, 17);
            lbl_invalidGuess.TabIndex = 6;
            // 
            // pb_dieImage
            // 
            pb_dieImage.BackgroundImageLayout = ImageLayout.Center;
            pb_dieImage.ImageLocation = "";
            pb_dieImage.InitialImage = null;
            pb_dieImage.Location = new Point(233, 119);
            pb_dieImage.Name = "pb_dieImage";
            pb_dieImage.Size = new Size(89, 84);
            pb_dieImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_dieImage.TabIndex = 7;
            pb_dieImage.TabStop = false;
            // 
            // rtb_gameStats
            // 
            rtb_gameStats.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rtb_gameStats.Location = new Point(27, 230);
            rtb_gameStats.Name = "rtb_gameStats";
            rtb_gameStats.Size = new Size(414, 181);
            rtb_gameStats.TabIndex = 8;
            rtb_gameStats.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 423);
            Controls.Add(rtb_gameStats);
            Controls.Add(pb_dieImage);
            Controls.Add(lbl_invalidGuess);
            Controls.Add(txt_guess);
            Controls.Add(cmd_reset);
            Controls.Add(cmd_Roll);
            Controls.Add(lbl_guess);
            Controls.Add(gb_gameState);
            Name = "Form1";
            Text = "Form1";
            gb_gameState.ResumeLayout(false);
            gb_gameState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_dieImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gb_gameState;
        private Label lbl_guess;
        private Button cmd_Roll;
        private Button cmd_reset;
        private TextBox txt_guess;
        private Label lbl_invalidGuess;
        private PictureBox pb_dieImage;
        private RichTextBox rtb_gameStats;
        private Label lbl_numLost;
        private Label lbl_timesLost;
        private Label lbl_numWon;
        private Label lbl_timesWon;
        private Label lbl_numPlayed;
        private Label lbl_timePlayed;
    }
}