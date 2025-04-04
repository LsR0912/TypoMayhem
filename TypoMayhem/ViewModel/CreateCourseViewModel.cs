using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TypoMayhem.Commands;
using TypoMayhem.Model;

namespace TypoMayhem.ViewModel
{
	public class CreateCourseViewModel : INotifyPropertyChanged
	{
		private string _courseName;
		private string _courseText;

		public string CourseName
		{
			get => _courseName;
			set => SetProperty(ref _courseName, value);
		}

		public string CourseText
		{
			get => _courseText;
			set => SetProperty(ref _courseText, value);
		}

		public ICommand CreateCourseCommand { get; }

		public event Action<TypingCourse> CourseCreated;

		public CreateCourseViewModel()
		{
			CreateCourseCommand = new RelayCommand(CreateCourse);
		}

		private void CreateCourse(object parameter)
		{
			var courseTextList = new List<string>(CourseText.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)).ToArray();
			var newCourse = new TypingCourse(CourseName, courseTextList);
			CourseCreated?.Invoke(newCourse);
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
	}
}
