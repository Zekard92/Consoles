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

namespace Consoles
{
	/// <summary>
	/// Interaction logic for AddConsole.xaml
	/// </summary>
	public partial class wndAddConsole : Window
	{
		public ConsolesAdmin consoleAdmin { get; set; }
		private CompaniesAdmin companyAdmin = new CompaniesAdmin ();
		public console Console { get; set; }
		public bool isEdit { get; set; }

		public wndAddConsole()
		{
			InitializeComponent ();
			DataContext = new console ();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			if (isEdit)
			{
				DataContext = Console;
				btnAdd.Content = "Update";
			}
			else
				DataContext = new console ();

			try
			{
				cmbCompany.DisplayMemberPath = "Company_Name";
				cmbCompany.SelectedValuePath = "ID";
				cmbCompany.ItemsSource = companyAdmin.GetCompanies ();
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message, "Console");
				Close ();
			}
		}

		public void Add(object sender, RoutedEventArgs ev)
		{
			try
			{
				if (isEdit)
					consoleAdmin.Update ((console)DataContext);
				else
					consoleAdmin.AddConsole ((console)DataContext);
				Close ();
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message, "Consoles", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}
		public void Cancel(object sender, RoutedEventArgs ev)
		{
			Close ();
		}
	}
}