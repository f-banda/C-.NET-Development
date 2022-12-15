
namespace Assignment_5
{
    partial class ChessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessForm));
            this.Player1_Name = new System.Windows.Forms.TextBox();
            this.Player2_Name = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ChessBackground = new System.Windows.Forms.PictureBox();
            this.label_Player1 = new System.Windows.Forms.Label();
            this.label_Player2 = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChessBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // Player1_Name
            // 
            this.Player1_Name.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1_Name.Location = new System.Drawing.Point(169, 330);
            this.Player1_Name.Name = "Player1_Name";
            this.Player1_Name.Size = new System.Drawing.Size(307, 30);
            this.Player1_Name.TabIndex = 0;
            // 
            // Player2_Name
            // 
            this.Player2_Name.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2_Name.Location = new System.Drawing.Point(169, 391);
            this.Player2_Name.Name = "Player2_Name";
            this.Player2_Name.Size = new System.Drawing.Size(307, 30);
            this.Player2_Name.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(192, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 249);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // ChessBackground
            // 
            this.ChessBackground.Image = ((System.Drawing.Image)(resources.GetObject("ChessBackground.Image")));
            this.ChessBackground.Location = new System.Drawing.Point(-9, -1);
            this.ChessBackground.Name = "ChessBackground";
            this.ChessBackground.Size = new System.Drawing.Size(650, 563);
            this.ChessBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ChessBackground.TabIndex = 4;
            this.ChessBackground.TabStop = false;
            // 
            // label_Player1
            // 
            this.label_Player1.AutoSize = true;
            this.label_Player1.BackColor = System.Drawing.Color.Transparent;
            this.label_Player1.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Player1.Location = new System.Drawing.Point(164, 300);
            this.label_Player1.Name = "label_Player1";
            this.label_Player1.Size = new System.Drawing.Size(96, 26);
            this.label_Player1.TabIndex = 5;
            this.label_Player1.Text = "Player 1";
            // 
            // label_Player2
            // 
            this.label_Player2.AutoSize = true;
            this.label_Player2.BackColor = System.Drawing.Color.Transparent;
            this.label_Player2.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Player2.Location = new System.Drawing.Point(164, 363);
            this.label_Player2.Name = "label_Player2";
            this.label_Player2.Size = new System.Drawing.Size(101, 26);
            this.label_Player2.TabIndex = 6;
            this.label_Player2.Text = "Player 2";
            // 
            // button_Start
            // 
            this.button_Start.BackColor = System.Drawing.Color.Aqua;
            this.button_Start.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Start.Location = new System.Drawing.Point(237, 436);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(172, 54);
            this.button_Start.TabIndex = 7;
            this.button_Start.Text = "Start Game";
            this.button_Start.UseVisualStyleBackColor = false;
            // 
            // ChessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(632, 553);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.label_Player2);
            this.Controls.Add(this.label_Player1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Player2_Name);
            this.Controls.Add(this.Player1_Name);
            this.Controls.Add(this.ChessBackground);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 600);
            this.MinimumSize = new System.Drawing.Size(650, 600);
            this.Name = "ChessForm";
            this.Text = "Chess Game";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChessBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Player1_Name;
        private System.Windows.Forms.TextBox Player2_Name;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox ChessBackground;
        private System.Windows.Forms.Label label_Player1;
        private System.Windows.Forms.Label label_Player2;
        private System.Windows.Forms.Button button_Start;
    }
}

