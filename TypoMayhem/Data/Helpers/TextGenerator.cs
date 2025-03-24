using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypoMayhem.Data.Helpers
{
	public static class TextGenerator
	{
		// Properties
		public static string[]? CourseText { get;  set; }

		// Methods
		public static string GenerateRandomCourseText(int wordCount)
		{
			Random rnd = new Random();
			return string.Join(" ", Enumerable.Range(0, wordCount).Select(i => CourseText?[rnd.Next(CourseText.Length)]));
		}
	}
}
