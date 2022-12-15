
namespace Assignment_6
{
    partial class Form1
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
            this.button_LineGraph = new System.Windows.Forms.Button();
            this.button_BarGraph = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_RadarGraph = new System.Windows.Forms.Button();
            this.button_PieGraph = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_Index = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_LineGraph
            // 
            this.button_LineGraph.Location = new System.Drawing.Point(344, 204);
            this.button_LineGraph.Name = "button_LineGraph";
            this.button_LineGraph.Size = new System.Drawing.Size(75, 23);
            this.button_LineGraph.TabIndex = 4;
            this.button_LineGraph.Text = "Line Graph";
            this.button_LineGraph.UseVisualStyleBackColor = true;
            this.button_LineGraph.Click += new System.EventHandler(this.button_LineGraph_Click);
            // 
            // button_BarGraph
            // 
            this.button_BarGraph.Location = new System.Drawing.Point(344, 140);
            this.button_BarGraph.Name = "button_BarGraph";
            this.button_BarGraph.Size = new System.Drawing.Size(75, 23);
            this.button_BarGraph.TabIndex = 2;
            this.button_BarGraph.Text = "Bar Graph";
            this.button_BarGraph.UseVisualStyleBackColor = true;
            this.button_BarGraph.Click += new System.EventHandler(this.button_BarGraph_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(263, 169);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 23);
            this.button_Exit.TabIndex = 5;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_RadarGraph
            // 
            this.button_RadarGraph.Location = new System.Drawing.Point(182, 204);
            this.button_RadarGraph.Name = "button_RadarGraph";
            this.button_RadarGraph.Size = new System.Drawing.Size(75, 23);
            this.button_RadarGraph.TabIndex = 3;
            this.button_RadarGraph.Text = "Radar Graph";
            this.button_RadarGraph.UseVisualStyleBackColor = true;
            this.button_RadarGraph.Click += new System.EventHandler(this.button_RadarGraph_Click);
            // 
            // button_PieGraph
            // 
            this.button_PieGraph.Location = new System.Drawing.Point(182, 140);
            this.button_PieGraph.Name = "button_PieGraph";
            this.button_PieGraph.Size = new System.Drawing.Size(75, 23);
            this.button_PieGraph.TabIndex = 1;
            this.button_PieGraph.Text = "Pie Graph";
            this.button_PieGraph.UseVisualStyleBackColor = true;
            this.button_PieGraph.Click += new System.EventHandler(this.button_PieGraph_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Assignment_6.Properties.Resources.line_graph;
            this.pictureBox4.Location = new System.Drawing.Point(425, 233);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(150, 100);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Assignment_6.Properties.Resources.pie_graph;
            this.pictureBox3.Location = new System.Drawing.Point(26, 34);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(150, 100);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Assignment_6.Properties.Resources.radar_graph;
            this.pictureBox2.Location = new System.Drawing.Point(26, 233);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(150, 100);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Assignment_6.Properties.Resources.bar_graph;
            this.pictureBox1.Location = new System.Drawing.Point(425, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 100);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // button_Index
            // 
            this.button_Index.Location = new System.Drawing.Point(263, 169);
            this.button_Index.Name = "button_Index";
            this.button_Index.Size = new System.Drawing.Size(75, 23);
            this.button_Index.TabIndex = 0;
            this.button_Index.Text = " ";
            this.button_Index.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_PieGraph);
            this.Controls.Add(this.button_RadarGraph);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.button_BarGraph);
            this.Controls.Add(this.button_LineGraph);
            this.Controls.Add(this.button_Index);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Portal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_LineGraph;
        private System.Windows.Forms.Button button_BarGraph;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_RadarGraph;
        private System.Windows.Forms.Button button_PieGraph;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button button_Index;
    }
}

