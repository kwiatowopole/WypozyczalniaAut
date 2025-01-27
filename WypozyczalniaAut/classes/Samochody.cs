using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WypozyczalniaAut.classes
{

    [XmlRoot("Samochody")]
    public class Samochody
    {

        public List<Samochod> listaSamochodow;

        [XmlElement("Samochod")]
        public List<Samochod> ListaSamochodow { get => listaSamochodow; set => listaSamochodow=value; }
        public Samochody() { ListaSamochodow = new List<Samochod>(); }
    }
}