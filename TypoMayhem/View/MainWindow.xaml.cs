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
using TypoMayhem.Buttons;
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
			if (key == Key.LeftCtrl || key == Key.RightCtrl) return;
			if (key == Key.LeftAlt || key == Key.RightAlt) return;

			if (_viewModel != null) _viewModel.ProcessKeyPress(Keyboard.PrimaryDevice, key);
		}
		private void SessionStarted(object? sender, EventArgs e)
		{
			cbSessionDuration.IsEnabled = false;
			cbCourses.IsEnabled = false;
			btnNewCourse.IsEnabled = false;
			btnEditCourse.IsEnabled = false;
			btnDeleteCourse.IsEnabled = false;
			btnMainWindow.IsEnabled = false;
			btnEvaluate.IsEnabled = false;
		}
		private void SessionEnded(object? sender, EventArgs e)
		{
			cbSessionDuration.IsEnabled = true;
			cbCourses.IsEnabled = true;
			btnNewCourse.IsEnabled = true;
			btnEditCourse.IsEnabled = true;
			btnDeleteCourse.IsEnabled = true;
			btnMainWindow.IsEnabled = true;
			btnEvaluate.IsEnabled = true;
		}

		private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selected = sidebar.SelectedItem as NavButton;

			if (selected == null) return;
			switch (selected.Name)
			{
				case "btnMainWindow": ShowMainWindow(); break;
				case "btnEvaluate":
					ShowEvaluationPage(selected);
					break;
			}
		}
		private void HideMainWindow()
		{
			stkHeader.Visibility = Visibility.Collapsed;
			stkFooter.Visibility = Visibility.Collapsed;
			txtMain.Visibility = Visibility.Collapsed;
			animatedBorder.Visibility = Visibility.Collapsed;
			stkCombobox.Visibility = Visibility.Collapsed;
			statusbar.Visibility = Visibility.Collapsed;
		}
		private void ShowMainWindow()
		{
			stkHeader.Visibility = Visibility.Visible;
			stkFooter.Visibility = Visibility.Visible;
			txtMain.Visibility = Visibility.Visible;
			animatedBorder.Visibility = Visibility.Visible;
			stkCombobox.Visibility = Visibility.Visible;
			statusbar.Visibility = Visibility.Visible;
		}
		private void ShowEvaluationPage(object? obj)
		{
			var sender = obj as NavButton;
			HideMainWindow();
			if (sender != null) navframe.Navigate(sender.Navlink);
		}
	}
}