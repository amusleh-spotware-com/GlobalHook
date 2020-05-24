using System;

namespace Gma.UserActivityMonitorDemo
{
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            new TestFormStatic().ShowDialog();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run();
            //Application.Run(new TestFormComponent());
        }
    }
}