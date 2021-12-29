using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.Models
{
    public class Empleado
    {
        public Int64 dpi { get; set; }
        public string nombreCompleto { get; set; }
        public int cantidadHijos { get; set; }
        public double salarioBase { get; set; }
        public double salarioLiquido { get; set; }
        public string usuarioCreacion { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}