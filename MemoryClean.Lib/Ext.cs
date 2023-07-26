using System.Security.Principal;
using System.Xml.Linq;

namespace MemoryClean.Lib
{
	public static class Ext
	{
		public static bool IsAdministrator
		{
			get
			{
				using WindowsIdentity ntIdentity = WindowsIdentity.GetCurrent();
				return new WindowsPrincipal(ntIdentity).IsInRole(WindowsBuiltInRole.Administrator);
			}
		}
		public static int Count(this IEnumerable<XElement> elements) =>
			elements.Count();
		public static XElement Find(this IEnumerable<XElement> elements, string key) =>
			 elements?.FirstOrDefault(x => x.Name == key);
	}
}