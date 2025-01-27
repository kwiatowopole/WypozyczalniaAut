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


using System.Windows;

namespace WypozyczalniaAut
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent(); 
            WyswietlAdministratorow(); 
        }

        private void WyswietlAdministratorow()
        {
            lstAdmins.Items.Clear(); 

            foreach (var admin in Admin.ListaAdministratorow)
            {
                lstAdmins.Items.Add(admin.PobierzInformacje()); 
            }
        }

        private void btnBackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show(); 
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
