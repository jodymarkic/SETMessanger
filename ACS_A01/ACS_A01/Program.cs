/*
 *  FILENAME:  Program.cs
 *  PROJECT: ACS_A01
 *  PROGRAMMER: Jody Markic and Leveson Cocarell
 *  FIRST VERSION: 3/27/2017
 *  DESCRIPTION: Main Entry point into the ACS_A01 project.
 */

using System;
using System.Windows.Forms;

namespace ACS_A01
{
    //
    //  CLASS: Program
    //  DESCRIPTION: Main Entry point into the ACS_A01 project.
    //
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
            Application.Run(new Form1());
        }
    }
}
