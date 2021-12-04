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
        public int Id { get; set; }
        public decimal Total { get; set; }
        [DisplayName("Fecha de Compra")]
        public DateTime FechaCompra { get; set; }
        [DisplayName("Forma de Pago")]
        public FormaDePago FOP { get; set; }
        public Cliente IdCliente { get; set; }
        public bool Despachado { get; set; } //0: sin despachar 1:despachado

    }
}
