using System;
using System.Collections.Generic;
using System.Text;

namespace LaugamaCorp.Shared.Models
{
    public class PaginationModel
    {
        public int Pagina { get; set; } = 1;
        public int CantidadAMostrar { get; set; } = 10;
    }
}
