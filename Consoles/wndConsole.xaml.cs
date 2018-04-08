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
	/// Interaction logic for wndConsole.xaml
	/// </summary>
	public partial class wndConsole : Window
	{
		public ConsolesAdmin admin = new ConsolesAdmin ();

		public wndConsole()
		{
			InitializeComponent ();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			admin.ListUpdated += Console_ListUpdated;
			Console_ListUpdated ();
		}

		private void Agregar(object sender, RoutedEventArgs ev)
		{
			try
			{
				wndAddConsole newConsole = new wndAddConsole ();
				newConsole.consoleAdmin = admin;
				newConsole.ShowDialog ();
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message, "Console", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}

		private void Eliminar(object sender, RoutedEventArgs ev)
		{
			try
			{
				if (dgConsoles.SelectedItem != null)
					if (MessageBox.Show (
						"Are you sure to remove the console?",
						"Console", MessageBoxButton.YesNo,
						MessageBoxImage.Question) == MessageBoxResult.Yes)
						admin.RemoveConsole ((console)dgConsoles.SelectedItem);
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message, "Console", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}

		private void Edit(object sender, RoutedEventArgs ev)
		{
			try
			{
				wndAddConsole newConsole = new wndAddConsole ();
				console selectedConsole = (console)dgConsoles.SelectedItem;
				newConsole.Console = admin.GetConsole (selectedConsole.ID);
				newConsole.consoleAdmin = admin;
				newConsole.isEdit = true;
				newConsole.ShowDialog ();
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message, "Console", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}

		private void Console_ListUpdated()
		{
			try
			{
				dgConsoles.ItemsSource = null;
				dgConsoles.ItemsSource = admin.GetConsoles ();
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message, "Console", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}
	}
}