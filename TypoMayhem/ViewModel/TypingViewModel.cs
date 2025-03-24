using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TypoMayhem.ViewModel
{
	public class TypingViewModel : INotifyPropertyChanged
	{
		// Variables
		private int _sessionDuration;
		private string? _currentText;
		private TimeSpan _remainingTime;
		private DispatcherTimer? _timer;

		// Array for Sessiondurations
		private int[] _sessionDurations = new int[] { 1, 2, 3, 4, 5, 10 };

		// Properties
		public int[] SessionDurations => _sessionDurations;
		public int SessionDuration { get => _sessionDuration; set => SetProperty(ref _sessionDuration, value); }
		public string? CurrentText { get => _currentText; set => SetProperty(ref _currentText, value); }
		public TimeSpan RemainingTime { get => _remainingTime; set => SetProperty(ref _remainingTime, value); }

		// Constructor
		public TypingViewModel()
		{
			
		}
		// Events
		public event PropertyChangedEventHandler? PropertyChanged;

		// Methods
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
