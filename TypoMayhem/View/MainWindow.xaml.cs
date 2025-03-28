using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TypoMayhem.ViewModel;

namespace TypoMayhem
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private TypingViewModel? _viewModel;
		public MainWindow()
		{
			InitializeComponent();
			InitialSettings();
			DataContext = _viewModel;
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
			if (_viewModel != null) _viewModel.SessionStarted += SessionStarted;
			if (_viewModel != null) _viewModel.SessionEnded += SessionEnded;
		}
		private void InitialSettings()
		{
			_viewModel = new TypingViewModel(txtMain);
			btnStart.Focusable = false;
			btnStop.Focusable = false;
			cbSessionDuration.Focusable = false;
		}
		protected override void OnKeyDown(KeyEventArgs e)
		{
			Key key = e.Key;

			if (key == Key.LeftShift || key == Key.RightShift) return;

			if (_viewModel != null) _viewModel.ProcessKeyPress(Keyboard.PrimaryDevice, key);
		}
		private void SessionStarted(object? sender, EventArgs e)
		{
			cbSessionDuration.IsEnabled = false;
		}
		private void SessionEnded(object? sender, EventArgs e)
		{
			cbSessionDuration.IsEnabled = true;
		}
	}
}