using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TypoMayhem.Model;
using TypoMayhem.View;

namespace TypoMayhem.ViewModel
{
	public class TypingViewModel : INotifyPropertyChanged
	{
		// Variables
		private int _sessionDuration;
		private int _currentPosition;
		private int _incorrectPosition;
		private int _errorCount;
		private double _wordsPerMinute;
		private double _signsPerMinute;
		private string? _currentText;
		private string? _userInput;
		private char _typedCharacter;
		private bool _isTyping;
		private TimeSpan _remainingTime;
		private DispatcherTimer? _timer;
		private DateTime _startTime;
		private TextBlock _textBlock;
		private ObservableCollection<TypingCourse> _typingCourses;
		private TypingCourse? _selectedCourse;

		// Array for Sessiondurations
		private int[] _sessionDurations = new int[] { 1, 2, 3, 4, 5, 10 };

		// Properties
		public int[] SessionDurations => _sessionDurations;
		public int CurrentPosition { get => _currentPosition; set => SetProperty(ref _currentPosition, value); }
		public int IncorrectPosition { get => _incorrectPosition; set => SetProperty(ref _incorrectPosition, value); }
		public int ErrorCount { get => _errorCount; set => SetProperty(ref _errorCount, value); }
		public double WordsPerMinute { get => _wordsPerMinute; set => SetProperty(ref _wordsPerMinute, value); }
		public double SignsPerMinute { get => _signsPerMinute; set => SetProperty(ref _signsPerMinute, value); }
		public List<int> IncorrectPositions { get; set; } = new List<int>();
		public int SessionDuration { get => _sessionDuration; set => SetProperty(ref _sessionDuration, value); }
		public string? CurrentText { get => _currentText; set => SetProperty(ref _currentText, value); }
		public string? UserInput { get => _userInput; set => SetProperty(ref _userInput, value); }
		public char TypedCharacter { get => _typedCharacter; set => _typedCharacter = value; }
		public bool IsTyping { get => _isTyping; set => SetProperty(ref _isTyping, value); }
		public TimeSpan RemainingTime { get => _remainingTime; set => SetProperty(ref _remainingTime, value); }
		public DateTime StartTime { get => _startTime; set => SetProperty(ref _startTime, value); }
		public ObservableCollection<TypingCourse> TypingCourses { get => _typingCourses; set => SetProperty(ref _typingCourses, value); }
		public TypingCourse? SelectedCourse { get => _selectedCourse; set => SetProperty(ref _selectedCourse, value); }


		// Constructor
		public TypingViewModel(TextBlock textBlock)
		{
			StartTypingCommand = new RelayCommand(StartTyping, CanExecute);
			StopTypingCommand = new RelayCommand(StopTyping);
			NewCourseCommand = new RelayCommand(CreateNewCourse);
			_typingCourses = new ObservableCollection<TypingCourse>();
			SessionDuration = _sessionDurations[0];
			_timer = new DispatcherTimer()
			{
				Interval = TimeSpan.FromSeconds(1)
			};
			_timer.Tick += OnTimerTick;
			TextGenerator.CourseText = ["The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog"];
			_textBlock = textBlock;
		}

		// Commands
		public ICommand StartTypingCommand { get; set; }
		public ICommand StopTypingCommand { get; set; }
		public ICommand NewCourseCommand { get; set; }
		public ICommand EditCourseCommand { get; set; }
		public ICommand DeleteCourseCommand { get; set; }

		// Events
		public event PropertyChangedEventHandler? PropertyChanged;
		public event EventHandler? SessionStarted;
		public event EventHandler? SessionEnded;

		// Methods
		private void StartTyping(object? sender)
		{
			_isTyping = true;
			CurrentPosition = 0;
			ErrorCount = 0;
			RemainingTime = TimeSpan.FromMinutes(SessionDuration);
			GenerateNewSentence();
			UpdateDisplay();
			OnSessionStarted();
		}
		private void StopTyping(object? sender)
		{
			_timer?.Stop();
			_isTyping = false;
			RemainingTime = TimeSpan.Zero;
			ResetDisplay();
			OnSessionEnded();
		}
		private void ResetDisplay()
		{
			CurrentText = "Press Start to begin a new Session.";
			CurrentPosition = -1;
			IncorrectPositions.Clear();
			UpdateDisplay();
			CalculateWordsPerMinute();
			CalculateSignsPerMinute();
		}
		public void ProcessKeyPress(KeyboardDevice keyboard, Key key)
		{
			if (_isTyping == true)
			{
				if (CurrentPosition < CurrentText?.Length)
				{
					_timer?.Start();
					bool isShiftPressed = keyboard.IsKeyDown(Key.LeftShift) || keyboard.IsKeyDown(Key.RightShift);
					char character = key == Key.Space ? ' ' : key.ToString().ToLower()[0];
					char actualChar = isShiftPressed ? char.ToUpper(character) : character;

					if (CurrentText != null && CurrentPosition < CurrentText.Length)
					{
						char expectedChar = CurrentText[CurrentPosition];
						ValidateKey(actualChar, expectedChar);
						UpdateDisplay();
					}
				}
				else
				{
					GenerateNewSentence();
					IncorrectPositions.Clear();
					CurrentPosition = 0;
					UpdateDisplay();
				}
			}
		}
		public void ValidateKey(char actualChar, char expectedChar)
		{
			if (actualChar == expectedChar)
			{
				CurrentPosition++;
				UserInput += actualChar;
			}
			else
			{
				if (!IncorrectPositions.Contains(CurrentPosition))
				{
					IncorrectPositions.Add(CurrentPosition);
					ErrorCount++;
				}
			}
		}
		private void CalculateWordsPerMinute()
		{
			if (UserInput != null && !UserInput.Contains(' ')) { return; }
			WordsPerMinute = (UserInput?.Split(' ').Length ?? 0) / (SessionDuration);
		}
		private void CalculateSignsPerMinute()
		{
			if (UserInput != null && SessionDuration > 0)
				SignsPerMinute = (double)UserInput.Length / (SessionDuration);
			else
				SignsPerMinute = 0;
		}
		public void UpdateDisplay()
		{
			_textBlock.Inlines.Clear();

			if (CurrentText == null) return;

			for (int i = 0; i < CurrentText.Length; i++)
			{
				var backgroundBrush = GetBackgroundBrush(i);
				var run = new Run(CurrentText[i].ToString()) { Background = backgroundBrush };
				var border = CreateTextBorder(run, backgroundBrush);
				_textBlock.Inlines.Add(new InlineUIContainer(border));
			}
		}
		private void InitializeStatisticsWindow()
		{
			StatisticsWindow statisticsWindow = new StatisticsWindow();
			StatisticsViewModel statisticsViewModel = new()
			{
				SessionDuration = SessionDuration,
				ErrorCount = ErrorCount,
				WordsPerMinute = WordsPerMinute,
				SignsPerMinute = SignsPerMinute
			};
			statisticsWindow.DataContext = statisticsViewModel;
			statisticsWindow.Show();
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
			IncorrectPositions.Clear();
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
		private bool CanExecute(object? parameter)
		{
			if (_isTyping) return false;
			else return true;
		}
		protected virtual void OnSessionStarted()
		{
			SessionStarted?.Invoke(this, EventArgs.Empty);
		}
		protected virtual void OnSessionEnded()
		{
			SessionEnded?.Invoke(this, EventArgs.Empty);
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
				StopTyping(null);
				InitializeStatisticsWindow();
			}
		}
		public void CreateNewCourse(object sender)
		{
			var newCourseWindow = new NewCourseWindow()
			{
				DataContext = new CreateCourseViewModel()
			};
			if (newCourseWindow.DataContext is CreateCourseViewModel viewModel)
			{
				viewModel.CourseCreated += OnCourseCreated;
			}
			newCourseWindow.ShowDialog();
		}

		private void OnCourseCreated(TypingCourse course)
		{
			if (TypingCourses != null) TypingCourses.Add(course);
			CourseHandler.SaveCourseToFile(course);
			TypingCourses = CourseHandler.LoadCoursesFromDirectory();
			if (TypingCourses != null) SelectedCourse = TypingCourses.Last();
		}
	}
}
