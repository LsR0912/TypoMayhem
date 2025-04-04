using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TypoMayhem.Model;

namespace TypoMayhem.Data.Helpers
{
	public static class CourseHandler
	{
		public static string directoryPath = "Courses";

		public static void SaveCourseToFile(TypingCourse course)
		{
			try
			{
				if (!Directory.Exists(directoryPath))
				{
					Directory.CreateDirectory(directoryPath);
				}

				var filePath = Path.Combine(directoryPath, $"{course.CourseName}.txt");
				using (var writer = new StreamWriter(filePath))
				{
					writer.WriteLine(course.CourseName);
					foreach (var line in course.CourseText)
					{
						writer.WriteLine(line);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error saving course: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public static ObservableCollection<TypingCourse> LoadCoursesFromDirectory()
		{
			try
			{
				var courseFiles = Directory.GetFiles(directoryPath, "*.txt");
				var courses = new ObservableCollection<TypingCourse>();

				foreach (var file in courseFiles)
				{
					var lines = File.ReadAllLines(file);
					if (lines.Length > 0)
					{
						var courseName = lines[0];
						var courseText = lines.Skip(1).ToArray();
						var typingCourse = new TypingCourse(courseName, courseText);
						courses.Add(typingCourse);
					}
				}

				return courses;
			}
			catch (Exception ex)
			{

				MessageBox.Show("Error loading courses: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return new ObservableCollection<TypingCourse>();
			}
		}
	}
}
