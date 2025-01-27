using System;
using System.Collections.Generic;
using System.Text;

namespace WypozyczalniaAut.classes
{
    public class Zamowienie
    {
        #region Pola
        private DateTime pickupDate;
        private DateTime returnDate;
        private Klient klient;
        #endregion

        #region Właściwości
        public bool Zaplacony { get; set; }
        public bool Zaksiegowany { get; set; }
        public bool Zwrocony { get; set; }

        public DateTime PickupDate
        {
            get => pickupDate;
            set => pickupDate = value;
        }

        public DateTime ReturnDate
        {
            get => returnDate;
            set => returnDate = value;
        }

        public Klient Klient
        {
            get => klient;
            set => klient = value;
        }
        #endregion

        #region Konstruktor
        public Zamowienie(Klient klient, DateTime pickupDate, DateTime returnDate,
                          bool zaplacony = false, bool zaksiegowany = false, bool zwrocony = false)
        {
            this.Klient = klient ?? throw new ArgumentNullException(nameof(klient), "Klient nie może być null.");
            this.PickupDate = pickupDate;
            this.ReturnDate = returnDate;
            this.Zaplacony = zaplacony;
            this.Zaksiegowany = zaksiegowany;
            this.Zwrocony = zwrocony;
        }
        #endregion

        #region Metody
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Informacje o zamówieniu:");
            sb.AppendLine($"Klient: {klient?.Imie} {klient?.Nazwisko}");
            sb.AppendLine($"Data odbioru: {pickupDate:yyyy-MM-dd}");
            sb.AppendLine($"Data zwrotu: {returnDate:yyyy-MM-dd}");
            sb.AppendLine($"Zaplacony: {(Zaplacony ? "Tak" : "Nie")}");
            sb.AppendLine($"Zaksiegowany: {(Zaksiegowany ? "Tak" : "Nie")}");
            sb.AppendLine($"Zwrocony: {(Zwrocony ? "Tak" : "Nie")}");
            return sb.ToString();
        }
        #endregion
    }
}
