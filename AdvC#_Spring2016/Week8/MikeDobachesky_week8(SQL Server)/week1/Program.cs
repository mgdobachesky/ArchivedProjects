using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace week1
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

            //Set the Control Panel window to run on program startup
            Application.Run(new ControlPanel());
        }
    }
}
