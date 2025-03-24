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
using TypoMayhem.Data.Helpers;

namespace TypoMayhem.ViewModel
{
	public class TypingViewModel : INotifyPropertyChanged
	{
		// Variables
		private int _sessionDuration;
		private int _currentPosition;
		private string? _currentText;
		private bool _isTyping;
		private TimeSpan _remainingTime;
		private DispatcherTimer? _timer;
		private DateTime _startTime;

		// Array for Sessiondurations
		private int[] _sessionDurations = new int[] { 1, 2, 3, 4, 5, 10 };

		// Properties
		public int[] SessionDurations => _sessionDurations;
		public int CurrentPosition { get => _currentPosition; set => SetProperty(ref _currentPosition, value); }
		public List<int> IncorrectPositions { get; set; } = new List<int>();
		public int SessionDuration { get => _sessionDuration; set => SetProperty(ref _sessionDuration, value); }
		public string? CurrentText { get => _currentText; set => SetProperty(ref _currentText, value); }
		public bool IsTyping { get => _isTyping; set => SetProperty(ref _isTyping, value); }
		public TimeSpan RemainingTime { get => _remainingTime; set => SetProperty(ref _remainingTime, value); }
		public DateTime StartTime { get => _startTime; set => SetProperty(ref _startTime, value); }


		// Constructor
		public TypingViewModel()
		{
			StartTypingCommand = new RelayCommand(StartTyping);
			StopTypingCommand = new RelayCommand(StopTyping);
			SessionDuration = _sessionDurations[0];
			_timer = new DispatcherTimer()
			{
				Interval = TimeSpan.FromSeconds(1)
			};
			_timer.Tick += OnTimerTick;
			TextGenerator.CourseText = ["The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog."];
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
			GenerateNewSentence();
		}
		private void StopTyping(object? sender)
		{
			_timer?.Stop();
		}
		public char GetActualCharacter(KeyboardDevice keyboard ,Key key)
		{
			if (key == Key.Space) return ' ';

			bool isShiftPressed = keyboard.IsKeyDown(Key.LeftShift) || keyboard.IsKeyDown(Key.RightShift);
			char character = key.ToString().ToLower()[0];
			return isShiftPressed ? char.ToUpper(character) : char.ToLower(character);
		}
		private void GenerateNewSentence()
		{
			CurrentText = TextGenerator.GenerateRandomCourseText(10);
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
