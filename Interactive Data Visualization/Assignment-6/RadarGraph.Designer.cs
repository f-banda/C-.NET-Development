
namespace Assignment_6
{
    partial class RadarGraph
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.RadarChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_Portal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RadarChart)).BeginInit();
            this.SuspendLayout();
            // 
            // RadarChart
            // 
            this.RadarChart.BackColor = System.Drawing.Color.DimGray;
            chartArea1.Name = "ChartArea1";
            this.RadarChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.RadarChart.Legends.Add(legend1);
            this.RadarChart.Location = new System.Drawing.Point(12, 12);
            this.RadarChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RadarChart.Name = "RadarChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Radar;
            series1.Legend = "Legend1";
            series1.Name = "Hero\'s Status";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Radar;
            series2.Legend = "Legend1";
            series2.Name = "Kyle\'s Status";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Radar;
            series3.Legend = "Legend1";
            series3.Name = "Average Human Status";
            this.RadarChart.Series.Add(series1);
            this.RadarChart.Series.Add(series2);
            this.RadarChart.Series.Add(series3);
            this.RadarChart.Size = new System.Drawing.Size(576, 324);
            this.RadarChart.TabIndex = 0;
            this.RadarChart.Text = "RadarChart";
            // 
            // button_Portal
            // 
            this.button_Portal.Location = new System.Drawing.Point(263, 342);
            this.button_Portal.Name = "button_Portal";
            this.button_Portal.Size = new System.Drawing.Size(75, 23);
            this.button_Portal.TabIndex = 3;
            this.button_Portal.Text = "Portal";
            this.button_Portal.UseVisualStyleBackColor = true;
            this.button_Portal.Click += new System.EventHandler(this.button_Portal_Click);
            // 
            // RadarGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.button_Portal);
            this.Controls.Add(this.RadarChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "RadarGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Radar Graph";
            ((System.ComponentModel.ISupportInitialize)(this.RadarChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart RadarChart;
        private System.Windows.Forms.Button button_Portal;
    }
}