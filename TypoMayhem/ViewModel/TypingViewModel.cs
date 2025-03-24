using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
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
		private int _incorrectPosition;
		private string? _currentText;
		private string? _userInput;
		private char _typedCharacter;
		private bool _isTyping;
		private TimeSpan _remainingTime;
		private DispatcherTimer? _timer;
		private DateTime _startTime;

		// Array for Sessiondurations
		private int[] _sessionDurations = new int[] { 1, 2, 3, 4, 5, 10 };

		// Properties
		public int[] SessionDurations => _sessionDurations;
		public int CurrentPosition { get => _currentPosition; set => SetProperty(ref _currentPosition, value); }
		public int IncorrectPosition { get => _incorrectPosition; set => SetProperty(ref _incorrectPosition, value); }
		public List<int> IncorrectPositions { get; set; } = new List<int>();
		public int SessionDuration { get => _sessionDuration; set => SetProperty(ref _sessionDuration, value); }
		public string? CurrentText { get => _currentText; set => SetProperty(ref _currentText, value); }
		public string? UserInput { get => _userInput; set => SetProperty(ref _userInput, value); }
		public char TypedCharacter { get => _typedCharacter; set => _typedCharacter = value; }
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
			TextGenerator.CourseText = ["The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog"];
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
		public void ProcessKeyPress(KeyboardDevice keyboard, Key key, ref TextBlock textBlock)
		{
			if (CurrentPosition < CurrentText?.Length)
			{

				bool isShiftPressed = keyboard.IsKeyDown(Key.LeftShift) || keyboard.IsKeyDown(Key.RightShift);
				char character = key == Key.Space ? ' ' : key.ToString().ToLower()[0];
				char actualChar = isShiftPressed ? char.ToUpper(character) : character;

				if (CurrentText != null && CurrentPosition < CurrentText.Length)
				{
					char expectedChar = CurrentText[CurrentPosition];
					ValidateKey(actualChar, expectedChar);
					UpdateDisplay(ref textBlock);
				}
			}
			else
			{
				GenerateNewSentence();
				CurrentPosition = 0;
				UpdateDisplay(ref textBlock);
			}
		}

		public void ValidateKey(char actualChar, char expectedChar)
		{
			// Check this logic, it seems not to be right
			if (actualChar == expectedChar)
			{
				CurrentPosition++;
				UserInput += actualChar;
			}
			else
			{
				if (IncorrectPosition != CurrentPosition)
				{
					IncorrectPositions.Add(IncorrectPosition);
				}
			}
		}
		public void UpdateDisplay(ref TextBlock textBlock)
		{
			textBlock.Inlines.Clear();

			if (CurrentText == null) return;

			for (int i = 0; i < CurrentText.Length; i++)
			{
				var backgroundBrush = GetBackgroundBrush(i);
				var run = new Run(CurrentText[i].ToString()) { Background = backgroundBrush };
				var border = CreateTextBorder(run, backgroundBrush);
				textBlock.Inlines.Add(new InlineUIContainer(border));
			}
		}
		private Brush GetBackgroundBrush(int position)
		{
			if (position < CurrentPosition)
			{
				return IncorrectPositions.Contains(position) ? Brushes.Red : Brushes.LightGreen;
			}
			return position == CurrentPosition ? Brushes.Yellow : Brushes.Transparent;
		}
		private Border CreateTextBorder(Run run, Brush background)
		{
			return new Border
			{
				Child = new TextBlock(run),
				Background = background,
				Effect = new DropShadowEffect
				{
					Color = Colors.Wheat,
					Direction = 340,
					ShadowDepth = 2,
					Opacity = 0.8
				}
			};
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
