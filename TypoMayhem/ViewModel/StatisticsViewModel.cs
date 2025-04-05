using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TypoMayhem.ViewModel
{
	public class StatisticsViewModel : INotifyPropertyChanged
	{
		// Variables
		private int _sessionDuration;
		private int _errorCount;
		private double _wordsPerMinute;
		private double _signsPerMinute;
		private string? _courseName;

		// Properties
		public int SessionDuration { get => _sessionDuration; set => SetProperty(ref _sessionDuration, value); }
		public int ErrorCount { get => _errorCount; set => SetProperty(ref _errorCount, value); }
		public double WordsPerMinute { get => _wordsPerMinute; set => SetProperty(ref _wordsPerMinute, value); }
		public double SignsPerMinute { get => _signsPerMinute; set => SetProperty(ref _signsPerMinute, value); }
		public string? CourseName { get => _courseName; set => SetProperty(ref _courseName, value); }

		public event PropertyChangedEventHandler? PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
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
