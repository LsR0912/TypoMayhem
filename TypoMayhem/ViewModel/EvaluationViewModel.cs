using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TypoMayhem.Data.Helpers;

namespace TypoMayhem.ViewModel
{
	public class EvaluationViewModel : INotifyPropertyChanged
	{
		// Variables
		private int _totalSigns;
		private int _totalErrors;
		private int _totalSessionDuration;
		private double _avgWPM;
		private string? _currentMonth;

		// Properties
		public int TotalSigns { get => _totalSigns; set => SetProperty(ref _totalSigns, value); }
		public int TotalErrors { get => _totalErrors; set => SetProperty(ref _totalErrors, value); }
		public double AvgWPM { get => _avgWPM; set => SetProperty(ref _avgWPM, value); }
		public int TotalSessionDuration { get => _totalSessionDuration; set => SetProperty(ref _totalSessionDuration, value); }
		public string? CurrentMonth { get => _currentMonth; set => SetProperty(ref _currentMonth, value); }

		// Constructor
		public EvaluationViewModel()
		{
			TotalErrors = EvaluationHandler.GetTotalErrorCount();
			TotalSessionDuration = EvaluationHandler.GetTotalSessionDuration();
			AvgWPM = Math.Round(EvaluationHandler.GetAverageWPM(), 2);
			CurrentMonth = DateTime.Now.ToString("MMMM");
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
