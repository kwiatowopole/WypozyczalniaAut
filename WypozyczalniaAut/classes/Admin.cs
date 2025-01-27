using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaAut
{
    public class Admin : Osoba
    {
        #region pola
        private static int idAdminstat = 1;
        private int idAdmin;
        private bool aktywny;
        #endregion
        #region wlasciwosci
        public bool Aktywny { get { return aktywny; } set { aktywny = value; } }
        #endregion
        public static List<Admin> ListaAdministratorow = new();
        public override string PobierzInformacje()
        {
            return $"Admin: {Imie} {Nazwisko}";
        }

    }
}
