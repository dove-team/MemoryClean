using MemoryClean.Lib;

namespace MemoryClean
{
    public partial class Setting : Form
    {
        public Config Config { get; private set; }
        public Setting()
        {
            InitializeComponent();
            Config = new Config();
        }
        private void SettingOnLoad(object sender, EventArgs e)
        {
            try
            {
                foreach (KeyValuePair<string, string> item in Config.GetAll())
                {
                    string key = item.Key;
                    if (!(key == "IsForce"))
                    {
                        if (key == "TimeSpan")
                            textBox1.Text = item.Value;
                    }
                    else if (Convert.ToBoolean(item.Value))
                        radioButton1.Checked = true;
                    else
                        radioButton2.Checked = true;
                }
            }
            catch
            {
                MessageBox.Show("加载数据时发生问题！");
                Close();
            }
        }
        private void ButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(textBox1.Text.Trim(), out var result))
                    Config.SaveData(SettingKey.TimeSpan.ToString(), result);
                bool @checked = radioButton1.Checked;
                Config.SaveData(SettingKey.IsForce.ToString(), @checked);
                MessageBox.Show("保存成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！" + ex.Message);
            }
        }
    }
}
