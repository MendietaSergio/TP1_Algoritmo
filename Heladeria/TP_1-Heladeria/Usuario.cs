using System;
using System.Collections.Generic;
using System.Text;

namespace TP_1_Heladeria
{
    public class Usuario
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int Genero { get; set; }
        public int TipoUsuario { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Nacionalidad { get; set; }
        public int Provincia { get; set; }
        public int Municipio { get; set; }
        public int Localidad { get; set; }
        public string CodigoPostal { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public int Piso { get; set; }
        public string Departamento { get; set; }
        public string UsuarioBase { get; set; }
        public string Pass { get; set; }
        public bool PrimerInicio { get; set; }
        public string UsuarioCompleto { get; set; }
    }
}
