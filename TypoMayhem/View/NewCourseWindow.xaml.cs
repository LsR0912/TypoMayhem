using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TypoMayhem.ViewModel;

namespace TypoMayhem.View
{
	/// <summary>
	/// Interaction logic for NewCourseWindow.xaml
	/// </summary>
	public partial class NewCourseWindow : Window
	{
		public NewCourseWindow()
		{
			InitializeComponent();
			Owner = Application.Current.MainWindow;
			WindowStartupLocation = WindowStartupLocation.CenterOwner;
			DataContext = new CreateCourseViewModel();
		}

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
