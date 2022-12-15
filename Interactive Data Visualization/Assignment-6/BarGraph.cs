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
    public partial class chart_BarGraph : Form
    {
        // Initializing form and series
        Form portal = new Form1();
        public Series items = new Series();

        /***
         * 
         * Sets up the form (Bar Graph) for displaying
         * 
         ****************************************************************************/
        public chart_BarGraph()
        {
            InitializeComponent();

            // Input data
            readFile();

            // Assign Chart Type to Bar Graph
            items.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;

            // Define items
            items.Name = "Motorcycle(s)";

            // Add data to chart
            chart_Bar.Series.Add(items);

            // Change chart increment
            chart_Bar.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chart_Bar.ChartAreas["ChartArea1"].AxisY.Interval = 100000;
            chart_Bar.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
            chart_Bar.ChartAreas["ChartArea1"].AxisY.Maximum = 900000;

            // Label Chart
            chart_Bar.ChartAreas[0].AxisY.Title = "Amount of Motorcycles";
            chart_Bar.ChartAreas[0].AxisX.Title = "State";
        }

        /***
         * A function to read data, split it, and store it appropriately
         ****************************************************************************/
        public void readFile()
        {
            // Initialize Variables
            string line;

            using (StreamReader input = new StreamReader ("barData.txt"))
            {
                while ((line = input.ReadLine()) != null)
                {
                    string[] ratio = line.Split(',');
                    items.Points.AddXY(ratio[0], int.Parse(ratio[1]));
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
        private void BarGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Open portal
            portal.Show();
        }
    }
}
