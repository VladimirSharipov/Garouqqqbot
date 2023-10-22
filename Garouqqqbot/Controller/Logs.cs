using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garouqqqbot.Controller
{
	public static  class Logs
	{
		static string? LocalPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
		static string? LocalDerictoriPath = Path.Combine(LocalPath, "Logs");
		public async static Task Erorr(string text)
		{
			string txt = $"[{DateTime.Now}] [Erorr]: \r\n [{text}]";
			await Task.Run(() =>
			{
				string path = Path.Combine(LocalDerictoriPath, $"Erorr_{DateTime.Now.ToString("dd.MM.yyyy_HH.mm.ss")}.txt");
				if (!Directory.Exists(LocalDerictoriPath))
				{
					Directory.CreateDirectory(LocalDerictoriPath);
				}
				if (!File.Exists(path))
				{
					File.Create(path).Close();

				}
				using (StreamWriter a = new StreamWriter(path, true))
				{

					a.AutoFlush = true;
					a.WriteLine(txt);
				}
			});
		}	
	}
}
