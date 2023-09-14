using Kursach_TP_Core.Context;
using Kursach_TP_Core.Models;
using Kursach_TP_Core.Forms;

namespace Kursach_TP_Core
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Start());
        }
    }
}