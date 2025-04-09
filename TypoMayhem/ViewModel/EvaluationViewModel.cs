using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TypoMayhem.ViewModel
{
	public class EvaluationViewModel : INotifyPropertyChanged
	{
		// Variables
		private int _totalSigns;
		private int _totalErrors;
		private double _avgWPM;

		// Properties
		public int TotalSigns { get => _totalSigns; set => SetProperty(ref _totalSigns, value); }
		public int TotalErrors { get => _totalErrors; set => SetProperty(ref _totalErrors, value); }
		public double AvgWPM { get => _avgWPM; set => SetProperty(ref _avgWPM, value); }

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
