using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        public string CalleNum { get; set; }
        public string CodPostal { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
    }
}
