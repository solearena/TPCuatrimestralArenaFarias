using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Stock
    {
        //public int Id { get; set; }
        public Articulo IdArticulo { get; set; }
        public int StockArticulo { get; set; }
        public string Talle { get; set; }
        public override string ToString()
        {
            return Talle;
        }
    }
}
