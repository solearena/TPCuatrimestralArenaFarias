using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace dominio
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        [DisplayName("Usario")]
        public string NombreUsuario { get; set; }
        [DisplayName("Contraseña")]
        public string Contrasenia { get; set; }
    }
}
