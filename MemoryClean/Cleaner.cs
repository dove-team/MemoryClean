using MemoryClean.Lib;
using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace MemoryClean
{
    public partial class Cleaner : Form
    {
        private Timer Timer { get; }
        public ScriptBuilder Builder { get; }
        public Config Config { get; private set; }
        public Cleaner()
        {
            InitializeComponent();
            Config = new Config();
            Builder = new ScriptBuilder();
            int timeSpan = Config.GetTimeSpan();
            if (timeSpan > 0)
            {
                Timer = new Timer { Interval = timeSpan * 60 * 1000 };
                Timer.Tick += TimerOnTick;
                Timer.Start();
            }
        }
        private void TimerOnTick(object sender, EventArgs e)
        {
            CleanToolStripMenuItemOnClick(sender, e);
        }
        private void CleanerOnLoad(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            Hide();
        }
        private void ExitToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            try
            {
                Close();
                Application.Exit();
            }
            catch
            {
                Environment.Exit(1);
            }
        }
        private void CleanToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            string path = Builder.CreateScript(false);
            using Task task = new Task(delegate
            {
                if (!string.IsNullOrEmpty(path))
                {
                    try
                    {
                        using Process process = new Process();
                        process.StartInfo.FileName = path;
                        process.StartInfo.CreateNoWindow = true;
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.Start();
                        process.WaitForExit();
                        process.Close();
                        File.Delete(path);
                        MessageBox.Show("清理内存完成！");
                    }
                    catch { }
                }
                else
                    MessageBox.Show("生成清理脚本时发生错误！");
            });
            task.Start();
            task.Wait();
        }
        private void SetToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            new Setting().Show();
        }
        private void CleanerOnFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Timer.Tick -= TimerOnTick;
                Timer?.Stop();
                Timer?.Dispose();
            }
            catch { }
        }
    }
}