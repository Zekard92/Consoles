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
	/// Interaction logic for wndAddCompany.xaml
	/// </summary>
	public partial class wndAddCompany : Window
	{
		public CompaniesAdmin admin { get; set; }
		public company Company { get; set; }
		public bool isEdit { get; set; }

		public wndAddCompany()
		{
			InitializeComponent ();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			if (isEdit)
			{
				DataContext = Company;
				btnAdd.Content = "Update";
			}
			else
			{
				DataContext = new company ();
			}
		}

		private void Add(object sender, RoutedEventArgs ev)
		{
			try
			{
				if (isEdit)
					admin.UpdateCompany ((company)DataContext);
				else
					admin.AddCompany ((company)DataContext);
				Close ();
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message, "Company", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}

		private void Cancel(object sender, RoutedEventArgs ev)
		{
			Close ();
		}
	}
}