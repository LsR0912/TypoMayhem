﻿using System.Text;
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
		}
		private void SessionEnded(object? sender, EventArgs e)
		{
			cbSessionDuration.IsEnabled = true;
			cbCourses.IsEnabled = true;
			btnNewCourse.IsEnabled = true;
			btnEditCourse.IsEnabled = true;
			btnDeleteCourse.IsEnabled = true;
		}

		private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selected = sidebar.SelectedItem as NavButton;

			navframe.Navigate(selected?.Navlink);
			
			cbCourses.Visibility = Visibility.Collapsed;
			btnStart.Visibility = Visibility.Collapsed;
			btnStop.Visibility = Visibility.Collapsed;
			btnNewCourse.Visibility = Visibility.Collapsed;
			btnEditCourse.Visibility = Visibility.Collapsed;
			btnDeleteCourse.Visibility = Visibility.Collapsed;
			txtMain.Visibility = Visibility.Collapsed;
			animatedBorder.Visibility = Visibility.Collapsed;
		}
	}
}