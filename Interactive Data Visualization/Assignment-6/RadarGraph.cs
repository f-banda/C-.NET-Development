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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Assignment_6
{
    public partial class RadarGraph : Form
    {
        /**
         * Reads input file and organize data.
         * 
         * @param filename A string holding the name of the file.
         ****************************************************************************/
        void readData(string filename, string SeriesName)
        {
            foreach (string line in System.IO.File.ReadLines(filename))             // Read each line in file
            {
                string[] input = Regex.Split(line, @"\t");                      // Separate the line by the tabs to save each input

                if (input[0] == "Strength" || input[0] == "Intelligent" || input[0] == "Dexterity" || input[0] == "Vigor" || input[0] == "Luck")            // Check if first input matches one of the stats
                {
                    RadarChart.Series[SeriesName].Points.AddXY(input[0], input[1]);                                                                         // Add point to series name
                }
                if (input[0] == "Charm" || input[0] == "Endurance" || input[0] == "Arcane" || input[0] == "Faith" || input[0] == "Wisdom")
                {
                    RadarChart.Series[SeriesName].Points.AddXY(input[0], input[1]);
                }
            }
        }

        public RadarGraph()
        {
            InitializeComponent();

            RadarChart.Titles.Add("Status Board");                                                                                      // Add title

            readData("KyleStatus.txt", "Kyle's Status");                                                                                // Add Three overlapping dataset to compare status

            readData("HeroStatus.txt", "Hero's Status");

            readData("AverageHumanStatus.txt", "Average Human Status");
        }

        private void button_Portal_Click(object sender, EventArgs e)
        {
            var portal = new Form1();
            portal.Show();
            Close();
        }
    }
}
