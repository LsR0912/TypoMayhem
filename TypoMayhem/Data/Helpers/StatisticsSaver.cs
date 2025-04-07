using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using TypoMayhem.Model;

namespace TypoMayhem.Data.Helpers
{
	public static class StatisticsSaver
	{
		public static string fileName = $"{DateTime.Now.Day}_{DateTime.Now.DayOfWeek}.txt";
		public static string folderPath = $"Statistics\\{DateTime.Now.Year}\\{DateTime.Now.ToString("MMMM")}";

		public static void SaveStatistics(UserStatistic statistic)
		{
			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}
		}
	}
}
