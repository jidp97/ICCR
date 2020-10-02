using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text;

namespace LaugamaCorp.Shared.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Especifique el nombre del cliente")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Display(Name = "Teléfono de contacto")]
        public string Telefono { get; set; }
        [EmailAddress, Display(Name = "Correo Electrónico")]
        public string Correo { get; set; }
        [Display(Name = "Dirección")]
        public string Location { get; set; }
        [Display(Name = "Tipo de cliente"), Required(ErrorMessage ="Especifique  el tipo de cliente")]
        public string TipoCliente { get; set; }
        [Display(Name = "Tipo de Identificación")]
        public string TipoIdentificacion { get; set; }
        [Display(Name = "Identificación del cliente"),Required(ErrorMessage = "El campo {0} es requerido")]
        public string Identificacion { get; set; }
        [Display(Name = "Descuento preferencial")]
        public double Descuento { get; set; }

    }
}
