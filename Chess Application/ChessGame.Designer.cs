
namespace Assignment_5
{
    partial class ChessGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessGame));
            this.ChessBoard = new System.Windows.Forms.PictureBox();
            this.ConsoleOutput = new System.Windows.Forms.TextBox();
            this.surrenderButton = new System.Windows.Forms.Button();
            this.turnLabel = new System.Windows.Forms.Label();
            this.winnerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ChessBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // ChessBoard
            // 
            this.ChessBoard.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ChessBoard.Location = new System.Drawing.Point(0, 0);
            this.ChessBoard.Name = "ChessBoard";
            this.ChessBoard.Size = new System.Drawing.Size(512, 512);
            this.ChessBoard.TabIndex = 1;
            this.ChessBoard.TabStop = false;
            this.ChessBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.ChessBoard_Paint);
            this.ChessBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChessBoard_MouseClick);
            // 
            // ConsoleOutput
            // 
            this.ConsoleOutput.Enabled = false;
            this.ConsoleOutput.Location = new System.Drawing.Point(518, 300);
            this.ConsoleOutput.Multiline = true;
            this.ConsoleOutput.Name = "ConsoleOutput";
            this.ConsoleOutput.ReadOnly = true;
            this.ConsoleOutput.Size = new System.Drawing.Size(208, 212);
            this.ConsoleOutput.TabIndex = 2;
            // 
            // surrenderButton
            // 
            this.surrenderButton.Location = new System.Drawing.Point(581, 271);
            this.surrenderButton.Name = "surrenderButton";
            this.surrenderButton.Size = new System.Drawing.Size(75, 23);
            this.surrenderButton.TabIndex = 3;
            this.surrenderButton.Text = "Surrender";
            this.surrenderButton.UseVisualStyleBackColor = true;
            this.surrenderButton.Click += new System.EventHandler(this.surrenderButton_Click);
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnLabel.Location = new System.Drawing.Point(578, 77);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(42, 18);
            this.turnLabel.TabIndex = 4;
            this.turnLabel.Text = "Turn:";
            // 
            // winnerLabel
            // 
            this.winnerLabel.AutoSize = true;
            this.winnerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winnerLabel.Location = new System.Drawing.Point(577, 182);
            this.winnerLabel.Name = "winnerLabel";
            this.winnerLabel.Size = new System.Drawing.Size(63, 20);
            this.winnerLabel.TabIndex = 5;
            this.winnerLabel.Text = "Winner:";
            this.winnerLabel.Visible = false;
            // 
            // ChessGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 512);
            this.Controls.Add(this.ChessBoard);
            this.Controls.Add(this.winnerLabel);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.surrenderButton);
            this.Controls.Add(this.ConsoleOutput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(742, 551);
            this.MinimumSize = new System.Drawing.Size(742, 551);
            this.Name = "ChessGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chess Game";
            ((System.ComponentModel.ISupportInitialize)(this.ChessBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox ChessBoard;
        private System.Windows.Forms.TextBox ConsoleOutput;
        private System.Windows.Forms.Button surrenderButton;
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.Label winnerLabel;
    }
}