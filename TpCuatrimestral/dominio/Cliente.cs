﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel

namespace dominio
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        [DisplayName("Fecha de Nacimiento")]
        public string FechaNacimiento { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
    }
}
