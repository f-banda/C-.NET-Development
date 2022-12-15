/****************************************************************************
 *                                                                          *
 *  Made by:                                                                *
 *      Francisco Banda (Z1912220)                                          *
 *                 &                                                        *
 *      Kyle Saysavanh  (Z1911954)                                          *
 *                                                                          *
 *  CSCI 473                                                                *
 *  Assignment 4 - The Bigger Picture                                       *
 *  Due: 3/31/22                                                            *
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

namespace mathteam_Assign4
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
