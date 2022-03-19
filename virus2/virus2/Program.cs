using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace virus2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Gets the path for configuration file.
            string Path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\ScreensaverConfig.txt";
            //Checks if the file exists and if not the app will run only with administrative privileges.
            if (!File.Exists(Path))
            {
                Process.EnterDebugMode();
            }
            //This is auto-generated and will create the UI(user-interface).
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
