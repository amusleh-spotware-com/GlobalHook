using Gma.UserActivityMonitor;
using System.Windows.Forms;

namespace ConsoleTester
{
    class Program
    {
        //[STAThread]
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);


            HookManager.KeyUp += HookManager_KeyUp;

            Application.Run();

            //Console.ReadLine();
        }

        private static void HookManager_KeyUp(object sender, KeyEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine($"KeyCode: {e.KeyCode} | Modifiers: {e.Modifiers}");
        }
    }
}
