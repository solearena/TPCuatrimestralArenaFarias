using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Carrito
    {
        public int Id { get; set; }
        public Venta IdVenta { get; set; }
        public List<ElementoCarrito> elementosCarrito { get; set; }
    }
}
