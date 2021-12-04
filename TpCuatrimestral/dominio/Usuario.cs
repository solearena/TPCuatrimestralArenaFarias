using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace dominio
{
    public enum TipoUsuario
    {
        NORMAL = 1,
        ADMIN = 2
    }
    public class Usuario
    {
        public int IdUsuario { get; set; }
        [DisplayName("Usario")]
        public string NombreUsuario { get; set; }
        [DisplayName("Contraseña")]
        public string Contrasenia { get; set; }

        public TipoUsuario TipoUsuario { get; set; }
        public Usuario Id { get; set; }

        public Usuario(string user,string pass, bool admin)
        {
            NombreUsuario = user;
            Contrasenia = pass;
            TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;

        }
    }
}
