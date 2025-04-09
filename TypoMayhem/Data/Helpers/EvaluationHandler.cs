using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypoMayhem.Data.Helpers
{
	public static class EvaluationHandler
	{
		private static string folderPath = $"Statistics\\{DateTime.Now.Year}";

		public static void LoadCurrentMonth(string month)
		{
			var currentMonth = Path.Combine(folderPath, month);
			var files = Directory.GetFiles(currentMonth);
			foreach (var file in files)
			{
				var existingContent = File.ReadAllText(file);
			}
		}
	}
}
