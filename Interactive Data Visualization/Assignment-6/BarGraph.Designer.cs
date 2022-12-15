
namespace Assignment_6
{
    partial class chart_BarGraph
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
            this.chart_Bar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Bar)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Portal
            // 
            this.button_Portal.Location = new System.Drawing.Point(263, 342);
            this.button_Portal.Name = "button_Portal";
            this.button_Portal.Size = new System.Drawing.Size(75, 23);
            this.button_Portal.TabIndex = 0;
            this.button_Portal.Text = "Portal";
            this.button_Portal.UseVisualStyleBackColor = true;
            this.button_Portal.Click += new System.EventHandler(this.button_Portal_Click);
            // 
            // chart_Bar
            // 
            this.chart_Bar.BackColor = System.Drawing.Color.DimGray;
            chartArea1.Name = "ChartArea1";
            this.chart_Bar.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_Bar.Legends.Add(legend1);
            this.chart_Bar.Location = new System.Drawing.Point(12, 12);
            this.chart_Bar.Name = "chart_Bar";
            this.chart_Bar.Size = new System.Drawing.Size(576, 324);
            this.chart_Bar.TabIndex = 0;
            this.chart_Bar.Text = "Bar Graph";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Number of Motorcycles in the U.S.";
            this.chart_Bar.Titles.Add(title1);
            // 
            // chart_BarGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.chart_Bar);
            this.Controls.Add(this.button_Portal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "chart_BarGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bar Graph";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BarGraph_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chart_Bar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Portal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Bar;
    }
}