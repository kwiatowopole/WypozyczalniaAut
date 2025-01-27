using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using WypozyczalniaAut;
using WypozyczalniaAut.classes.enums;
using WypozyczalniaAut.classes;


namespace WypozyczalniaAut
{
    public partial class Window3 : Window
    {
        private List<Samochod> samochody;
        private List<Samochod> filtrowaneSamochody;

        public Window3()
        {
            InitializeComponent();
            InicjalizujSamochody();
            InicjalizujFiltry();
            WyswietlSamochody();
        }

        private void InicjalizujSamochody()
        {
            try
            {
                string xmlFilePath = "C:\\Users\\iaros\\Downloads\\Nowy folder\\WypozyczalniaAut\\Samochody.xml";

                if (!File.Exists(xmlFilePath))
                {
                    MessageBox.Show("Plik XML z danymi samochodów nie został znaleziony.",
                        "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    samochody = new List<Samochod>();
                    return;
                }

                // Użyj klasy Samochody do deserializacji
                XmlSerializer serializer = new XmlSerializer(typeof(Samochody));

                using (FileStream fs = new FileStream(xmlFilePath, FileMode.Open))
                {
                    Samochody samochodyOpakowane = (Samochody)serializer.Deserialize(fs);
                    samochody = samochodyOpakowane.ListaSamochodow;
                }

                // Logowanie dla sprawdzenia, czy samochody są poprawnie wczytane
                if (samochody == null || !samochody.Any())
                {
                    MessageBox.Show("Lista samochodów jest pusta po deserializacji.",
                        "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                filtrowaneSamochody = new List<Samochod>(samochody); // Przypisanie listy filtrowanej
            }
            catch (Exception ex)
            {
                // Debugowanie: wyświetl pełny stack trace błędu
                MessageBox.Show($"Wystąpił błąd podczas wczytywania danych z pliku XML: {ex.ToString()}",
                    "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InicjalizujFiltry()
        {
            cmbTransmissionType.ItemsSource = Enum.GetValues(typeof(TypTransmisji)).Cast<TypTransmisji>();
            cmbTransmissionType.SelectedIndex = -1;

            cmbFuelType.ItemsSource = Enum.GetValues(typeof(TypPaliwa)).Cast<TypPaliwa>();
            cmbFuelType.SelectedIndex = -1;

            cmbCarType.ItemsSource = Enum.GetValues(typeof(typSamochodu)).Cast<typSamochodu>();
            cmbCarType.SelectedIndex = -1;
        }

        private void WyswietlSamochody()
        {
            lstCars.Items.Clear();
            foreach (var samochod in filtrowaneSamochody)
            {
                lstCars.Items.Add($"{samochod.Marka} {samochod.Model} ({samochod.Typ}, {samochod.RokWydania})");
            }
        }

        private void FilterCars(object sender, SelectionChangedEventArgs e)
        {
            var selectedTransmission = cmbTransmissionType.SelectedItem as TypTransmisji?;
            var selectedFuel = cmbFuelType.SelectedItem as TypPaliwa?;
            var selectedCarType = cmbCarType.SelectedItem as typSamochodu?;

            filtrowaneSamochody = samochody.Where(s =>
                (!selectedTransmission.HasValue || s.TypTransmisji == selectedTransmission.Value) &&
                (!selectedFuel.HasValue || s.TypPaliwa == selectedFuel.Value) &&
                (!selectedCarType.HasValue || s.Typ == selectedCarType.Value)
            ).ToList();

            WyswietlSamochody();
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
        private void btnClearFilters_Click(object sender, RoutedEventArgs e)
        {
            // Czyszczenie wyborów w filtrach
            cmbTransmissionType.SelectedIndex = -1;
            cmbFuelType.SelectedIndex = -1;
            cmbCarType.SelectedIndex = -1;

            // Przywrócenie wszystkich samochodów do widoku
            filtrowaneSamochody = new List<Samochod>(samochody);

            // Odświeżenie listy samochodów
            WyswietlSamochody();
        }
    }
}
