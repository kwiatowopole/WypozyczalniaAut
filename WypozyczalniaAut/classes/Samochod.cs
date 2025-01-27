using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WypozyczalniaAut.classes.enums;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace WypozyczalniaAut 
{
    public class Samochod : IEquatable<Samochod>, ICloneable
    {
        #region pola

        private string model;

        private string marka;

        private int liczbaMiejsc;

        private double? cena;

        private int? rokWydania;

        private bool klimatyzacja;

        private double? konsumpcjaPaliwaZaKm;

        private string imageName;
        public static int id_static = 1;

        private int id;

        private string numerPlyty;

        private TypTransmisji typTransm;

        private TypPaliwa typPaliwa;

        private typSamochodu typ;

        private bool dostepnosc;
        #endregion

        #region wlasciwosci
        [XmlElement("NumerPlyty")]
        public string NumerPlyty
        {
            get => numerPlyty;
            set
            {
                if (!Regex.IsMatch(value, @"^(?:[A-Z]{3} \d{3}[A-Z]{2}|[A-Z]{2} \d{4}[A-Z]{1}|[A-Z]{3} [A-Z]{2}\d{2})$"))
                {
                    throw new ArgumentException("Tablica rejestracyjna musi składać sie zgodnie z formatem: XYZ 123AC, XY 1234A lub XYZ AC12.");
                }
                numerPlyty = value;
            }
        }
        [XmlElement("Dostepnosc")]
        public bool Dostepnosc
        {
            get => dostepnosc;
            set
            {
                dostepnosc = value;
            }
        }
        [XmlElement("Id")]
        public int Id
        {
            get => id;
            set
            {
                id = value;
            }
        }
        [XmlElement("ImageName")]
        public string ImageName
        {
            get => imageName;
            set
            {
                imageName = value;
            }
        }
        [XmlElement("Klimatyzacja")]
        public bool Klimatyzacja
        {
            get => klimatyzacja;
            set
            {
                klimatyzacja = value;
            }
        }

        [XmlElement("Model")]
        public string Model
        {
            get => model;
            set
            {
                model = value;
            }
        }
        [XmlElement("LiczbaMiejsc")]
        public int LiczbaMiejsc
        {
            get => liczbaMiejsc;
            set
            {
                liczbaMiejsc = value;
            }
        }
        [XmlElement("Cena")]
        public double? Cena 
        {
            get => cena;
            set
            {
                cena = value;
            }
        }
        [XmlElement("KonsumpcjaPaliwaZaKm")]
        public double? KonsumpcjaPaliwaZaKm
        {
            get => konsumpcjaPaliwaZaKm;
            set
            {
                konsumpcjaPaliwaZaKm = value;
            }
        }
        [XmlElement("RokWydania")]
        public int? RokWydania
        {
            get => rokWydania;

            set
            {
                rokWydania = value;
            }
        }
        [XmlElement("Marka")]
        public string Marka
        {
            get => marka;
            set
            {
                marka = value;
            }
        }
        [XmlElement("TypTransmisji")]
        public TypTransmisji TypTransmisji
        {
            get => typTransm;
            set
            {
                typTransm = value;
            }
        }
        [XmlElement("TypPaliwa")]
        public TypPaliwa TypPaliwa
        {
            get => typPaliwa;
            set
            {
                typPaliwa = value;
            }
        }
        [XmlElement("Typ")]
        public typSamochodu Typ
        {
            get => typ;
            set
            {
                typ = value;
            }
        }
        public string BrandAndModel => Marka + " " + Model;
        #endregion
        public Samochod() { }

        public Samochod(TypPaliwa typPaliwa, string marka, int rokWydania,
            double cena, int liczbaMiejsc,
            double konsumpcjaPaliwaZaKm,
            string model, typSamochodu typ,
            TypTransmisji typTransm, bool klimatyzacja, string imageName, string numerPlyty)
        {
            this.Model = model;
            this.Typ = typ;
            this.Marka = marka;
            this.RokWydania = rokWydania;
            this.Cena = cena;
            this.LiczbaMiejsc = liczbaMiejsc;
            this.KonsumpcjaPaliwaZaKm = konsumpcjaPaliwaZaKm;
            this.TypPaliwa = typPaliwa;
            this.TypTransmisji = typTransm;
            this.Klimatyzacja = klimatyzacja;
            this.ImageName = imageName;
            this.NumerPlyty = numerPlyty;
        }
        public bool Equals(Samochod? other)
        {
            if (other is null) return false;
            return NumerPlyty.Equals(other.NumerPlyty);
        }

        public object Clone()
        {
            return new Samochod(
                this.TypPaliwa,
                this.Marka,
                this.RokWydania.GetValueOrDefault(),
                this.Cena.GetValueOrDefault(),
                this.LiczbaMiejsc,
                this.KonsumpcjaPaliwaZaKm.GetValueOrDefault(),
                this.Model,
                this.Typ,
                this.TypTransmisji,
                this.Klimatyzacja,
                this.imageName,
                this.NumerPlyty)
            {
                Klimatyzacja = this.Klimatyzacja,
                NumerPlyty = this.NumerPlyty,
                Dostepnosc = this.Dostepnosc,
                ImageName = this.ImageName
            };
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();

            toString.AppendLine("Informacja o samochodie");
            toString.AppendLine();
            toString.AppendFormat(" Marka samochodu - {0}", this.Marka);
            toString.AppendLine();
            toString.AppendFormat(" Typ samochodu - {0}", this.Typ);
            toString.AppendLine();
            toString.AppendFormat(" Rok wydania - {0}", this.RokWydania);
            toString.AppendLine();
            toString.AppendFormat(" Typ paliwa - {0}", this.TypPaliwa);
            toString.AppendLine();
            toString.AppendFormat(" Typ transmisji - {0}", this.TypTransmisji);
            toString.AppendLine();
            toString.AppendFormat(" Liczba miejsc - {0}", this.LiczbaMiejsc);
            toString.AppendLine();
            toString.AppendFormat(" Konsumpcja paliwa za 100 km - {0}", this.KonsumpcjaPaliwaZaKm);
            toString.AppendLine();
            toString.AppendFormat(" Cena dobowa - {0:$}", this.Cena);

            return toString.ToString();
        }
        
    }
}
