using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class ElementoCarrito
    {
        public Articulo IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public string Talle { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
