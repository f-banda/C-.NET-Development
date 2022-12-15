
namespace Assignment_6
{
    partial class PieGraph
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.PieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_Portal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PieChart)).BeginInit();
            this.SuspendLayout();
            // 
            // PieChart
            // 
            this.PieChart.BackColor = System.Drawing.Color.DimGray;
            chartArea1.Name = "ChartArea1";
            this.PieChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.PieChart.Legends.Add(legend1);
            this.PieChart.Location = new System.Drawing.Point(12, 12);
            this.PieChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PieChart.Name = "PieChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series";
            this.PieChart.Series.Add(series1);
            this.PieChart.Size = new System.Drawing.Size(576, 324);
            this.PieChart.TabIndex = 0;
            this.PieChart.Text = "PieChart";
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
            // PieGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.button_Portal);
            this.Controls.Add(this.PieChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "PieGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pie Graph";
            ((System.ComponentModel.ISupportInitialize)(this.PieChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart PieChart;
        private System.Windows.Forms.Button button_Portal;
    }
}