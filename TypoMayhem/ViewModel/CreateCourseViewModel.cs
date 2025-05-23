﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TypoMayhem.Commands;
using TypoMayhem.Model;

namespace TypoMayhem.ViewModel
{
	public class CreateCourseViewModel : INotifyPropertyChanged
	{
		private string? _courseName;
		private string? _courseText;

		public string? CourseName
		{
			get => _courseName;
			set => SetProperty(ref _courseName, value);
		}

		public string? CourseText
		{
			get => _courseText;
			set => SetProperty(ref _courseText, value);
		}

		public ICommand? CreateCourseCommand { get; set; }

		public event Action<TypingCourse>? CourseCreated;

		public CreateCourseViewModel()
		{
			CreateCourseCommand = new RelayCommand(CreateCourse);
		}

		private void CreateCourse(object? parameter)
		{
			if (CourseName != null && CourseName != string.Empty && CourseText != null && CourseText != string.Empty)
			{
				var courseTextList = new List<string>(CourseText.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)).ToArray();
				var newCourse = new TypingCourse(CourseName, courseTextList);
				CourseCreated?.Invoke(newCourse);
			}
			else if (CourseName == null || CourseName == string.Empty)
			{
				MessageBox.Show("Course name cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else
			{
				MessageBox.Show("Invalid input. Please enter only alphanumeric characters.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(field, value)) return false;
			field = value;
			OnPropertyChanged(propertyName);
			return true;
		}

		public static bool IsValidInput(string input)
		{
			if (input == null) return false;
			// Create a Regex object
			Regex regex = new Regex("^[a-z0-9\\s]+$", RegexOptions.IgnoreCase);

			// Match the input string against the regex
			return regex.IsMatch(input);
		}
	}
}
