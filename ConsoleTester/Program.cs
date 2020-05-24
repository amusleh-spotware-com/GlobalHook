using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gma.UserActivityMonitor;
using System.Windows.Forms;
using System.Threading;

namespace ConsoleTester
{
    class Program
    {
        //[STAThread]
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);


            HookManager.KeyPress += HookManager_KeyPress; ;

            Application.Run();

            //Console.ReadLine();
        }

        private static void HookManager_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine($"Key Up: {e.KeyChar}");
        }
    }
}
