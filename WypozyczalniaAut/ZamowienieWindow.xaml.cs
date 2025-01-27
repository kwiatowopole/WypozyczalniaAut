using System;
using System.Linq;
using System.Net;
using System.Windows;
using WypozyczalniaAut.classes;

namespace WypozyczalniaAut
{
    public partial class ZamowienieWindow : Window
    {
        private Samochody Samochody;

        public ZamowienieWindow()
        {
            InitializeComponent();

            // Ładowanie klientów do ComboBox
            cmbClient.ItemsSource = Klient.ListaKlientow;
            cmbClient.DisplayMemberPath = "PobierzInformacje"; // Wybieramy metodę, która pokazuje pełne dane klienta
            cmbClient.SelectedIndex = 0;

            // Ładowanie samochodów do ComboBox
            cmbCar.ItemsSource = Samochody.ListaSamochodow;
            cmbCar.DisplayMemberPath = "BrandAndModel";
            cmbCar.SelectedIndex = 0;
        }

        private void btnSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdzamy, czy wszystkie pola zostały wypełnione
            if (cmbClient.SelectedItem == null || cmbCar.SelectedItem == null || pickupDate.SelectedDate == null || returnDate.SelectedDate == null)
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Klient selectedClient = (Klient)cmbClient.SelectedItem;
            Samochod selectedCar = (Samochod)cmbCar.SelectedItem;

            Zamowienie noweZamowienie = new Zamowienie(klient: selectedClient,
                pickupDate: (DateTime)pickupDate.SelectedDate,
                returnDate: (DateTime)returnDate.SelectedDate,
                zaplacony: false);

            MessageBox.Show($"Zamówienie dla klienta {selectedClient.Imie} {selectedClient.Nazwisko} na samochód {selectedCar.BrandAndModel} zostało zapisane.",
                             "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

            // Zamykamy okno po zapisaniu
            this.Close();
        }
    }
}
