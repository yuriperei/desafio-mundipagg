using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Application.DTOs
{
    public class LocalizacaoDTO
    {
        public string LocalizacaoId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
    }
}
