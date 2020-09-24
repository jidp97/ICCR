using System.ComponentModel.DataAnnotations;

namespace LaugamaCorp.Shared.Models
{
    public class Persona
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Indique su nombre, por favor.")]
        public string Nombre { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un estado")]
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
     
    }
}
