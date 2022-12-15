
namespace Assignment_6
{
    partial class chart_LineGraph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.button_Portal = new System.Windows.Forms.Button();
            this.chart_Line = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Line)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Portal
            // 
            this.button_Portal.Location = new System.Drawing.Point(263, 342);
            this.button_Portal.Name = "button_Portal";
            this.button_Portal.Size = new System.Drawing.Size(75, 23);
            this.button_Portal.TabIndex = 1;
            this.button_Portal.Text = "Portal";
            this.button_Portal.UseVisualStyleBackColor = true;
            this.button_Portal.Click += new System.EventHandler(this.button_Portal_Click);
            // 
            // chart_Line
            // 
            this.chart_Line.BackColor = System.Drawing.Color.DimGray;
            chartArea1.Name = "ChartArea1";
            this.chart_Line.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_Line.Legends.Add(legend1);
            this.chart_Line.Location = new System.Drawing.Point(12, 12);
            this.chart_Line.Name = "chart_Line";
            this.chart_Line.Size = new System.Drawing.Size(576, 324);
            this.chart_Line.TabIndex = 0;
            this.chart_Line.Text = "Line Graph";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Daily new confirmed COVID-19 cases per million people (2021)";
            this.chart_Line.Titles.Add(title1);
            // 
            // chart_LineGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.chart_Line);
            this.Controls.Add(this.button_Portal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "chart_LineGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Line Graph";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LineGraph_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chart_Line)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Portal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Line;
    }
}