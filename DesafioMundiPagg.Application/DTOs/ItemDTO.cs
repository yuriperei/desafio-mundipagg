using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Application.DTOs
{
    public class ItemDTO
    {
        public string ItemId { get; set; }
        public string Titulo { get; set; }
        public TipoItem TipoItem { get; set; }
        public bool IsEmprestado { get; set; }
    }
}
