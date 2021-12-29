using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.Models
{
    public class Usuario
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string passw { get; set; }
        public string tokenR { get; set; }
    }
}