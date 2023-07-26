using MemoryClean.Lib;

namespace MemoryClean
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(defaultValue: false);
            using Mutex mutex = new Mutex(initiallyOwned: true, "MemoryClean", out bool createdNew);
            if (createdNew)
            {
                if (!Ext.IsAdministrator)
                {
                    MessageBox.Show("请用管理员身份运行！");
                    Environment.Exit(0);
                }
                else
                {
                    Application.Run(new Cleaner());
                    mutex.ReleaseMutex();
                }
            }
            else
            {
                MessageBox.Show("程序已经在运行!");
                Environment.Exit(0);
            }
        }
    }
}