using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace LaugamaCorp.Shared.Models
{
    public class Suplidor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public  string Telefono { get; set; }
        public string RNC { get; set; }
    }
}
