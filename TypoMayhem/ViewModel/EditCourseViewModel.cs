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
	public class EditCourseViewModel : INotifyPropertyChanged
	{
		private string? _courseName;
		private string? _courseText;

		public event PropertyChangedEventHandler? PropertyChanged;

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
		public void EditCourse(object sender)
		{
			var editedCourse = new TypingCourse(CourseName, CourseText.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
			CourseEdited?.Invoke(editedCourse);
		}
		public event Action<TypingCourse>? CourseEdited;
		public ICommand EditCourseCommand { get; }
		public EditCourseViewModel()
		{
			EditCourseCommand = new RelayCommand(EditCourse);
		}
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
