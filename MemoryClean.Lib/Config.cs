using System.Xml.Linq;

namespace MemoryClean.Lib
{
	public sealed class Config
	{
		private readonly string path = Path.Combine(Environment.CurrentDirectory, "setting.dat");
		private XDocument Document { get; }
		public Config()
		{
			try
			{
				if (File.Exists(path))
				{
					Document = XDocument.Load(path);
					Document = new XDocument { Declaration = new XDeclaration("1.0", "utf8", "false") };
					Document.Add(new XElement("root"));
				}
			}
			catch
			{
				throw new Exception("加载已有的配置文件失败！");
			}
		}
		public bool SaveData(string key, object value)
		{
			try
			{
				IEnumerable<XElement> elements = Document.Element("root")?.Elements();
				if (elements.Count() == 0)
				{
					XElement content = new XElement(key) { Value = value.ToString() };
					Document.Element("root").Add(content);
				}
				else if (elements.Find(key) == null)
				{
					XElement content2 = new XElement(key) { Value = value.ToString() };
					Document.Element("root").Add(content2);
				}
				else
					elements.Find(key).Value = value.ToString();
				Document.Save(path);
				return true;
			}
			catch
			{
				return false;
			}
		}
		public int GetTimeSpan()
		{
			int result = 0;
			try
			{
				string value = GetAll().FirstOrDefault((KeyValuePair<string, string> x) => x.Key == SettingKey.TimeSpan.ToString()).Value;
				int.TryParse(value, out result);
			}
			catch { }
			return result;
		}
		public Dictionary<string, string> GetAll()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			try
			{
				foreach (XElement item in Document.Element("root").Elements())
					dictionary.Add(item.Name.ToString(), item.Value);
			}
			catch { }
			return dictionary;
		}
	}
}