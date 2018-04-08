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

namespace Consoles
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent ();
		}

		private void Consoles(object sender, RoutedEventArgs e)
		{
			wndConsole consoles = new wndConsole ();
			Hide ();
			consoles.ShowDialog ();
			Show ();
		}

		private void Companies(object sender, RoutedEventArgs e)
		{
			wndCompany companies = new wndCompany ();
			Hide ();
			companies.ShowDialog ();
			Show ();
		}
	}
}