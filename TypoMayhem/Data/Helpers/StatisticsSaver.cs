using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TypoMayhem.Model;

namespace TypoMayhem.Data.Helpers
{
	public static class StatisticsSaver
	{
		public static string fileName = $"{DateTime.Now.Day}_{DateTime.Now.DayOfWeek}.json";
		public static string folderPath = $"Statistics\\{DateTime.Now.Year}\\{DateTime.Now.ToString("MMMM")}";

		public static void SaveStatistics(UserStatistic statistic)
		{
			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}

			var filePath = Path.Combine(folderPath, fileName);
			string jsonString = JsonConvert.SerializeObject(statistic, Formatting.Indented);
			if (File.Exists(filePath))
			{
				var existingContent = File.ReadAllText(filePath);
				var typingResults = JsonConvert.DeserializeObject<List<UserStatistic>>(existingContent) ?? new List<UserStatistic>();
				typingResults.Add(statistic);
				File.WriteAllText(filePath, JsonConvert.SerializeObject(typingResults, Formatting.Indented));
			}
			else
			{
				var typingResults = new List<UserStatistic> { statistic };
				File.WriteAllText(filePath, JsonConvert.SerializeObject(typingResults, Formatting.Indented));
			}
		}
	}
}
