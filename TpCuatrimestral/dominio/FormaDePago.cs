using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class FormaDePago
    {
        public int IdFP { get; set; }
        public string Tipo { get; set; }
        public override string ToString()
        {
            return Tipo;
        }
    }
}
