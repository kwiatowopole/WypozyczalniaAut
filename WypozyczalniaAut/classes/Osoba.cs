using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaAut
{
    public abstract class Osoba : IEquatable<Osoba>
    {
        #region pola

        string imie;
        string nazwisko;
        string pesel;
        DateTime dataUrodzenia;
        string numerTel;
        enum Plec;
        #endregion
        #region wlasciwosci
        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        public string NumerTel { get => numerTel; set
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"\d{9}")) //opcjonalnie prawym przyciskiem w szybkie akcje i uzywaj namespacu
                {
                    throw new ArgumentException("Numer telefonu musi skladac sie z 9 znakow!");
                }
                numerTel = value; } }
            
        public string Pesel
        {
            get => pesel;
            set
            {
                //if (value.Length != 11 && typeof)
                if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"\d{11}")) //opcjonalnie prawym przyciskiem w szybkie akcje i uzywaj namespacu
                {
                    throw new ArgumentException("Pesel musi skladac sie z 11 znakow!");
                }
                pesel = value;
            }
        }
        #endregion
        public bool Equals(Osoba? other)
        {
            if (other is null) return false; // Dodano obsługę null
            return Pesel.Equals(other.Pesel);    // Prostsze i czytelniejsze porównanie Eguals a równa równa się - obie opcje tu poprawne,
            //Bo nie są typami referencyjnymi. 
        }
        public virtual string PobierzInformacje()
        {
            return $"Osoba: {Imie} {Nazwisko}";
        }

    }
}
