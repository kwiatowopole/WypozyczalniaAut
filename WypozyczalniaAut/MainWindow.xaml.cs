using System.IO;
using System.Windows;
using System.Xml.Serialization;
using WypozyczalniaAut.classes;

namespace WypozyczalniaAut
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }



        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            ZamowienieWindow addOrderWindow = new ZamowienieWindow();
            addOrderWindow.ShowDialog(); // Otwieramy okno jako okno modalne
        }

        private void btnAddAdmin_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new();
            window1.Show();
            this.Hide();
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new();
            window2.Show();
            this.Hide();
        }

        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new();
            window3.Show();
            this.Hide();
        }
    }
}