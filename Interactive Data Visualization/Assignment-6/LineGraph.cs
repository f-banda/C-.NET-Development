/****************************************************************************
 *                                                                          *
 *  Made by:                                                                *
 *      Francisco Banda (Z1912220)                                          *
 *                 &                                                        *
 *      Kyle Saysavanh  (Z1911954)                                          *
 *                                                                          *
 *  CSCI 473                                                                *
 *  Assignment 6 - Uncharted                                                *
 *  Due: 3/3/22                                                             *
 *                                                                          *
 *  Data Used:                                                              *
 *  http://www.city-data.com/blog/4956-motorcycle-industry-united-states/   *
 *  https://ourworldindata.org/                                             *
 *                                                                          *
 ****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Assignment_6
{
    public partial class chart_LineGraph : Form
    {
        // Initializing Form and Lines
        Form portal = new Form1();
        public static Series Line1 = new Series();
        public static Series Line2 = new Series();
        public static Series Line3 = new Series();

        /***
         * 
         * Sets up the form (Line Graph) for displaying
         * 
         ****************************************************************************/
        public chart_LineGraph()
        {
            InitializeComponent();

            // Input data
            readFile();

            // Assign Chart Type to Line Graph
            Line1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Line2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Line3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            // Assign Series Names
            Line1.Name = "United States";
            Line1.BorderWidth = 2;
            Line2.Name = "France";
            Line2.BorderWidth = 2;
            Line3.Name = "Germany";
            Line3.BorderWidth = 2;

            // Configure Chart
            chart_Line.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
            chart_Line.ChartAreas["ChartArea1"].AxisY.Maximum = 1100;
            chart_Line.ChartAreas["ChartArea1"].AxisX.Minimum = 1;
            chart_Line.ChartAreas["ChartArea1"].AxisX.Maximum = 12;
            chart_Line.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            // Label chart
            chart_Line.ChartAreas[0].AxisX.Title = "Month";
            chart_Line.ChartAreas[0].AxisY.Title = "Confirmed Cases";

            // Add data to chart
            chart_Line.Series.Add(Line1);
            chart_Line.Series.Add(Line2);
            chart_Line.Series.Add(Line3);
        }

        /***
         * A function to read data, split it, and store it appropriately
         ****************************************************************************/
        public void readFile()
        {
            // Initialize Variables
            string line;

            using (StreamReader input = new StreamReader("lineData.txt"))
            {
                while ((line = input.ReadLine()) != null)
                {
                    // Initialize items
                    string[] items = line.Split('\t');

                    // Categorize items
                    string Item1 = items[0];
                    string Item2 = items[1];
                    string Item3 = items[2];

                    // Split data
                    string[] Item1Amount = Item1.Split(' ');
                    string[] Item2Amount = Item2.Split(' ');
                    string[] Item3Amount = Item3.Split(' ');

                    // Create data points
                    Line1 = drawPoints(Item1Amount);
                    Line2 = drawPoints(Item2Amount);
                    Line3 = drawPoints(Item3Amount);
                }
            }
        }

        /***
         * A function/button to return to the portal
         * 
         * @return Portal form
         ****************************************************************************/
        private void button_Portal_Click(object sender, EventArgs e)
        {
            // Open Portal
            portal.Show();

            // Close Bar Graph
            Close();
        }

        /***
         * A function/button to return to the portal, when form is closed
         * 
         * @return Portal form
         ****************************************************************************/
        private void LineGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Open portal
            portal.Show();
        }

        /***
         * 
         * Takes each data set, and formats them into coordinates for graphing
         * 
         * @return series (data)
         ****************************************************************************/
        public Series drawPoints(string[] contents)
        {
            // Series where data will be added to
            Series series = new Series();

            // Loop through contents
            for (int i = 0; i < contents.Length; i++)
            {
                // Split contents by comma
                string[] amount = contents[i].Split(',');

                // Store as x and y
                int x = int.Parse(amount[0]);
                int y = int.Parse(amount[1]);

                // Form coordinates
                series.Points.AddXY(x, y);
            }

            // Return series for displaying
            return series;
        }
    }
}
