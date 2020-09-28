using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace LaugamaCorp.Shared.Models
{
    public class Producto
    {
        
        public int id { get; set; }
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido"), Display(Name = "Producto", Description ="Descripcion del producto", Prompt ="Ingrese la descripcion del producto")]
        public string Articulo { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una categoria")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Debe especificar el suplidor de este artículo")]
        public int SuplidorId { get; set; }

        public Suplidor Suplidor { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debe especificar la cantidad")]
        public int Cantidad { get; set; }   
        public decimal PrecioAlquiler { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioReposicion { get; set; }
        public DateTime FechaRegistro { get; set; }



    }
}
