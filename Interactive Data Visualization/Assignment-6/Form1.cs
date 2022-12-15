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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /***
         * A function/button to close all forms, and exit program.
         * 
         * @return Exit
         ****************************************************************************/
        private void button_Exit_Click(object sender, EventArgs e)
        {
            // Exit application
            System.Windows.Forms.Application.Exit();
        }

        /***
         * A function/button to open the line graph form, and hide the portal
         * 
         * @return Line Graph Form
         ****************************************************************************/
        private void button_LineGraph_Click(object sender, EventArgs e)
        {
            // Create Line Graph Instance
            var lineGraph = new chart_LineGraph();

            // Hide portal
            Hide();

            // Open Line Graph
            lineGraph.Show();
        }

        /***
         * A function/button to open the bar graph form, and hide the portal
         * 
         * @return Bar Graph Form
         ****************************************************************************/
        private void button_BarGraph_Click(object sender, EventArgs e)
        {
            // Create Line Graph Instance
            var barGraph = new chart_BarGraph();

            // Hide portal
            Hide();

            // Open Line Graph
            barGraph.Show();
        }

        /***
         * A function/button to close all forms, and exit program.
         * 
         * @return Exit
         ****************************************************************************/
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Exit application
            System.Windows.Forms.Application.Exit();
        }

        private void button_PieGraph_Click(object sender, EventArgs e)
        {
            // Create Pie Graph Instance
            var pieGraph = new PieGraph();

            // Hide portal
            Hide();

            // Open Pie Graph
            pieGraph.Show();
        }

        private void button_RadarGraph_Click(object sender, EventArgs e)
        {
            // Create Radar Graph Instance
            var radarGraph = new RadarGraph();

            // Hide portal
            Hide();

            // Open Radar Graph
            radarGraph.Show();
        }
    }
}
