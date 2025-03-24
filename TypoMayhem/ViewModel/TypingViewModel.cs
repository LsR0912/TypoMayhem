using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using TypoMayhem.Commands;

namespace TypoMayhem.ViewModel
{
	public class TypingViewModel : INotifyPropertyChanged
	{
		// Variables
		private int _sessionDuration;
		private string? _currentText;
		private TimeSpan _remainingTime;
		private DispatcherTimer? _timer;
		private DateTime _startTime;

		// Array for Sessiondurations
		private int[] _sessionDurations = new int[] { 1, 2, 3, 4, 5, 10 };

		// Properties
		public int[] SessionDurations => _sessionDurations;
		public int SessionDuration { get => _sessionDuration; set => SetProperty(ref _sessionDuration, value); }
		public string? CurrentText { get => _currentText; set => SetProperty(ref _currentText, value); }
		public TimeSpan RemainingTime { get => _remainingTime; set => SetProperty(ref _remainingTime, value); }
		public DateTime StartTime { get => _startTime; set => SetProperty(ref _startTime, value); }


		// Constructor
		public TypingViewModel()
		{
			StartTypingCommand = new RelayCommand(StartTyping);
			StopTypingCommand = new RelayCommand(StopTyping);
			_timer = new DispatcherTimer()
			{
				Interval = TimeSpan.FromSeconds(1)
			};
			_timer.Tick += OnTimerTick;
		}

		// Commands
		public ICommand StartTypingCommand { get; set; }
		public ICommand StopTypingCommand { get; set; }

		// Events
		public event PropertyChangedEventHandler? PropertyChanged;

		// Methods
		private void StartTyping(object? sender)
		{
			RemainingTime = TimeSpan.FromMinutes(SessionDuration);
			_timer?.Start();
		}
		private void StopTyping(object? sender)
		{
			_timer?.Stop();
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
		private void OnTimerTick(object? sender, EventArgs e)
		{
			if (RemainingTime.TotalSeconds > 0)
			{
				RemainingTime = RemainingTime.Subtract(TimeSpan.FromSeconds(1));
			}
			else
			{
				if (_timer != null) _timer.Stop();
				MessageBox.Show("Time's up!");
			}
		}
	}
}
