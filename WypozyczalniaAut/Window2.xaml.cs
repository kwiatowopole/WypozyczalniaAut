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


namespace WypozyczalniaAut
{
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

       
        private void btnBackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                this.Close();

                
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string imie = txtClientFirstName.Text;
                string nazwisko = txtClientLastName.Text;
                string numerPrawaJazdy = txtDrivingLicenseNumber.Text;

                if (string.IsNullOrWhiteSpace(imie) || string.IsNullOrWhiteSpace(nazwisko) || string.IsNullOrWhiteSpace(numerPrawaJazdy))
                {
                    MessageBox.Show("Wszystkie pola muszą być wypełnione!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                Klient nowyKlient = new Klient
                {
                    Imie = imie,
                    Nazwisko = nazwisko,
                    NumerPrawaJazdy = numerPrawaJazdy
                };

                Klient.DodajKlienta(nowyKlient);

                txtClientFirstName.Clear();
                txtClientLastName.Clear();
                txtDrivingLicenseNumber.Clear();

                MessageBox.Show("Klient został dodany!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string numerPrawaJazdy = txtDrivingLicenseNumber.Text;

                if (string.IsNullOrWhiteSpace(numerPrawaJazdy))
                {
                    MessageBox.Show("Podaj numer prawa jazdy klienta do usunięcia!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                Klient.UsunKlienta(numerPrawaJazdy);

                txtDrivingLicenseNumber.Clear();

                MessageBox.Show("Klient został usunięty!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDisplayClients_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lstClients.Items.Clear();

                foreach (var klient in Klient.ListaKlientow)
                {
                    lstClients.Items.Add(klient.PobierzInformacje());
                }

                if (Klient.ListaKlientow.Count == 0)
                {
                    lstClients.Items.Add("Brak klientów do wyświetlenia.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}



