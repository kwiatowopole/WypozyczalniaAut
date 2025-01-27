using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class UnderageClientException : Exception
{
    public int Wiek { get; }

    public UnderageClientException(int wiek)
        : base($"Klient musi mieć co najmniej 18 lat. Podano wiek: {wiek}.")
    {
        Wiek = wiek;
    }
}

namespace WypozyczalniaAut
{
    public class Klient : Osoba, IComparable<Klient>
    {
        #region pola
        public static int idKlientastat = 1;
        private int idKlienta;
        private string numerPrawaJazdy;
        public static List<Klient> ListaKlientow = new List<Klient>();
        public int wiek;
        #endregion
        #region wlasciwosci
        public string NumerPrawaJazdy { get => numerPrawaJazdy; set
            {
                if (!Regex.IsMatch(value, @"^[A-Z]{2}\d{3}/\d{5}$"))
                {
                    throw new ArgumentException("Prawo jazdy musi składać sie zgodnie z formatem: XY123/45678.");
                }
                NumerPrawaJazdy = value;
            } }
        public int Wiek
        {
            get
            {
                // Obliczanie wieku na podstawie daty urodzenia
                int wiek = DateTime.Now.Year - DataUrodzenia.Year;
                if (DateTime.Now < DataUrodzenia.AddYears(wiek))
                {
                    wiek--;
                }
                return wiek;
            }
        }
        #endregion

        public int CompareTo(Klient? other)
        {
            if (other is null)
            {
                return 1;
            }

            int cmp = Nazwisko.CompareTo(other.Nazwisko);
            if (cmp != 0)
            {
                return cmp;
            }

            return Imie.CompareTo(other.Imie);
        }
        public static void DodajKlienta(Klient klient)
        {
            if (klient == null)
            {
                throw new ArgumentNullException(nameof(klient), "Klient nie może być null.");
            }
            if (klient.Wiek < 18)
            {
                throw new UnderageClientException(klient.Wiek);
            }
            ListaKlientow.Add(klient);
            Console.WriteLine($"Dodano klienta: {klient.PobierzInformacje()}");
        }

        public static void UsunKlienta(string numerPrawaJazdy)
        {
           
            Klient? klientDoUsuniecia = ListaKlientow.Find(k => k.NumerPrawaJazdy == numerPrawaJazdy);

            if (klientDoUsuniecia != null)
            {
                ListaKlientow.Remove(klientDoUsuniecia);
                Console.WriteLine($"Usunięto klienta: {klientDoUsuniecia.PobierzInformacje()}");
            }
            else
            {
                Console.WriteLine($"Nie znaleziono klienta z numerem prawa jazdy: {numerPrawaJazdy}");
            }
        }


        public static void WyswietlWszystkichKlientow()
        {
            Console.WriteLine("Lista klientów:");
            foreach (var klient in ListaKlientow)
            {
                Console.WriteLine(klient.PobierzInformacje());
            }
        }
    }
}
