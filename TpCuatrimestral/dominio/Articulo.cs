using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        [DisplayName("Imagen Url")]
        public string UrlImagen { get; set; }
        public bool Estado { get; set; }
        [DisplayName("Categoría")]
        public Categoria DescripcionCategoria { get; set; }
        public Categoria IdCategoria{ get; set; }
        public Stock Stock { get; set; }
        public Stock Talle { get; set; }
    }
}
