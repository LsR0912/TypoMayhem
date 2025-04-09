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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TypoMayhem.ViewModel;

namespace TypoMayhem.Pages
{
	/// <summary>
	/// Interaction logic for TypingEvaluation.xaml
	/// </summary>
	public partial class TypingEvaluation : Page
	{
		private EvaluationViewModel? _viewModel = new EvaluationViewModel();
		public TypingEvaluation()
		{
			InitializeComponent();
			DataContext = _viewModel;
		}
	}
}
