/****************************************************************************
 *                                                                          *
 *  Kyle Saysavanh & Francisco Banda                                        *
 *  CSCI 473                                                                *
 *  Assignment 3 - Building a Application for Real Estate                   *
 *  2/26/2022                                                               *
 *                                                                          *
 *  Individual work is separated by initials in comments                    *
 *  Ex:   // K.S - Declaring Example Class                                  *
 *                                                                          *
 ****************************************************************************/

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mathteam_Assign3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new QueryForm());
        }
    }
}
