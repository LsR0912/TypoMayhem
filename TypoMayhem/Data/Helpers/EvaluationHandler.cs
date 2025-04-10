using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypoMayhem.Model;

namespace TypoMayhem.Data.Helpers
{
	public static class EvaluationHandler
	{
		private static string folderPath = $"Statistics";
		public static string year = DateTime.Now.Year.ToString();
		public static string month = DateTime.Now.ToString("MMMM");

		public static List<UserStatistic> GetUserStatistics(string year, string month)
		{
			var userStatistics = new List<UserStatistic>();
			var filePath = Path.Combine(folderPath, year, month);

			if (Directory.Exists(filePath))
			{
				var files = Directory.GetFiles(filePath);

				foreach (var file in files)
				{
					var fileContent = File.ReadAllText(file);
					var results = JsonConvert.DeserializeObject<List<UserStatistic>>(fileContent);
					if (results != null)
					{
						userStatistics.AddRange(results);
					}
				}
			}
			return userStatistics;
		}

		public static int GetTotalErrorCount()
		{
			var errorcount = 0;
			var statistics = GetUserStatistics(year, month);
			foreach (var userStatistic in statistics)
			{
				errorcount += userStatistic.ErrorCount;
			}
			return errorcount;
		}

		public static double GetAverageWPM()
		{
			var wpm = 0.0;
			var statistics = GetUserStatistics(year, month);
			foreach (var userStatistic in statistics)
			{
				wpm += userStatistic.WordsPerMinute;
			}
			return wpm / statistics.Count;
		}

		public static int GetTotalSessionDuration()
		{
			var sessionDuration = 0;
			var statistics = GetUserStatistics(year, month);
			foreach (var userStatistic in statistics)
			{
				sessionDuration += userStatistic.SessionDuration;
			}
			return sessionDuration;
		}
	}
}
