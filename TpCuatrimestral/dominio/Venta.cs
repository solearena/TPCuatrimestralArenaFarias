using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace dominio
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public decimal Total { get; set; }
        [DisplayName("Fecha de Compra")]
        public string FechaCompra { get; set; }
        [DisplayName("Forma de Pago")]
        public FormaDePago FOP { get; set; }
    }
}
