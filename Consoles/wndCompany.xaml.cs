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
	/// Interaction logic for wndCompany.xaml
	/// </summary>
	public partial class wndCompany : Window
	{
		private CompaniesAdmin admin = new CompaniesAdmin ();

		public wndCompany()
		{
			InitializeComponent ();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			admin.ListUpdated += Admin_ListUpdated;
			Admin_ListUpdated ();
		}

		private void Add(object sender, RoutedEventArgs ev)
		{
			try
			{
				wndAddCompany newCompany = new wndAddCompany ();
				newCompany.admin = admin;
				newCompany.ShowDialog ();
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message, "Company", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}

		private void Edit(object sender, RoutedEventArgs ev)
		{
			try
			{
				if (dgCompanies.SelectedItem != null)
				{
					wndAddCompany newCompany = new wndAddCompany ();
					company selectedCompany = (company)dgCompanies.SelectedItem;
					newCompany.Company = admin.GetCompany (selectedCompany.ID);
					newCompany.admin = admin;
					newCompany.isEdit = true;
					newCompany.ShowDialog ();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message, "Company", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}

		private void Remove(object sender, RoutedEventArgs ev)
		{
			try
			{
				if (dgCompanies.SelectedItem != null)
				{
					if (MessageBox.Show (
						"Are you sure to remove this company?",
						"Company", MessageBoxButton.YesNo,
						MessageBoxImage.Question) == MessageBoxResult.Yes)
					{
						admin.RemoveCompany ((company)dgCompanies.SelectedItem);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message, "Company", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}

		private void Admin_ListUpdated()
		{
			try
			{
				dgCompanies.ItemsSource = null;
				dgCompanies.ItemsSource = admin.GetCompanies ();
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message, "Company", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}
	}
}