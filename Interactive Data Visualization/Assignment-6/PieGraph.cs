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
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text.RegularExpressions;

namespace Assignment_6
{
    public partial class PieGraph : Form
    {
        /**
         * Reads input file and organize data.
         * 
         * @param filename A string holding the name of the file.
         ****************************************************************************/
        void readData(string filename)
        {
            bool firstLine = true;                                                  // For store title
            int classNum = 0;                                                       // Increment for each society class

            foreach (string line in System.IO.File.ReadLines(filename))             // Read each line in file
            {
                if (firstLine)                                                      // Store title from first line
                {
                    title = line;                                                   // Save title name
                    firstLine = false;                                              // Set to false to store the rest of the data
                }
                else
                {
                    string[] input = Regex.Split(line, @"\t");                      // Separate the line by the tabs to save each input

                    dataset.Add(new List<string>());                                // Add a new list in dataset, adding a new society class

                    foreach (string word in input)                                  // Read each word in the string array
                    {
                        dataset[classNum].Add(word);                                // Save each word to dataset List
                    }

                    classNum++;                                                     // Increment society class number
                }
            }
        }

        string title = "";                                                          // Title
        List<List<string>> dataset = new List<List<string>>();                      // Dataset matrix

        public PieGraph()
        {
            InitializeComponent();

            readData("SocietyClassificationDataSet.txt");                           // Read data

            PieChart.Titles.Add(title);                                             // Add title

            PieChart.Series["Series"].IsValueShownAsLabel = true;                   // Show data in percent
            PieChart.Series["Series"].Label = "#PERCENT";

            for (int num = 0; num < dataset.Count; num++)                                               // Loop through matrix on each row
            {
                int percent = (dataset[num].Count - 1);                                                 // Find the total number of people in that social class(row)
                PieChart.Series["Series"].Points.AddXY(dataset[num][0], percent.ToString());            // Add point to series
                PieChart.Series["Series"].Points[num].LegendText = dataset[num][0];                     // Add Social Class to legend
            }
        }

        private void button_Portal_Click(object sender, EventArgs e)
        {
            var portal = new Form1();
            portal.Show();
            Close();
        }
    }
}
