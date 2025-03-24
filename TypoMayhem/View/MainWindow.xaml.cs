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
        private TypingViewModel _viewModel = new TypingViewModel();
		public MainWindow()
        {
            InitializeComponent();
			DataContext = _viewModel;
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			Key key = e.Key;

			if (key == Key.LeftShift || key == Key.RightShift) return;
		}
	}
}