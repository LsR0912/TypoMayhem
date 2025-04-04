using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypoMayhem.Model
{
	public class TypingCourse
	{
		public string? CourseName { get; set; }
		public string[]? CourseText { get; set; }

		public TypingCourse(string? courseName, string[]? courseText)
		{
			CourseName = courseName;
			CourseText = courseText;
		}
	}
}
