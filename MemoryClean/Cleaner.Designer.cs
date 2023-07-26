namespace MemoryClean
{
    partial class Cleaner
    {
        private System.ComponentModel.IContainer components = null;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 清理内存ToolStripMenuItem;
        private ToolStripMenuItem 退出ToolStripMenuItem;
        private ToolStripMenuItem 设置ToolStripMenuItem;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cleaner));
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            清理内存ToolStripMenuItem = new ToolStripMenuItem();
            设置ToolStripMenuItem = new ToolStripMenuItem();
            退出ToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "MemoryClean";
            notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 清理内存ToolStripMenuItem, 设置ToolStripMenuItem, 退出ToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(139, 76);
            // 
            // 清理内存ToolStripMenuItem
            // 
            清理内存ToolStripMenuItem.Name = "清理内存ToolStripMenuItem";
            清理内存ToolStripMenuItem.Size = new Size(138, 24);
            清理内存ToolStripMenuItem.Text = "清理内存";
            清理内存ToolStripMenuItem.Click += CleanToolStripMenuItemOnClick;
            // 
            // 设置ToolStripMenuItem
            // 
            设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            设置ToolStripMenuItem.Size = new Size(138, 24);
            设置ToolStripMenuItem.Text = "设置";
            设置ToolStripMenuItem.Click += SetToolStripMenuItemOnClick;
            // 
            // 退出ToolStripMenuItem
            // 
            退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            退出ToolStripMenuItem.Size = new Size(138, 24);
            退出ToolStripMenuItem.Text = "退出";
            退出ToolStripMenuItem.Click += ExitToolStripMenuItemOnClick;
            // 
            // Cleaner
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(15, 17);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Cleaner";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cleaner";
            WindowState = FormWindowState.Minimized;
            FormClosing += CleanerOnFormClosing;
            Load += CleanerOnLoad;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}