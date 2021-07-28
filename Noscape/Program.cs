using System;
using System.Windows.Forms;

namespace Noscape
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <remarks>
        /// Includes a fix for respecting Windows DPI-scaling from https://stackoverflow.com/a/52074624
        /// </remarks>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Noscape());
        }

        // Include dllimport of DPI scaling
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
