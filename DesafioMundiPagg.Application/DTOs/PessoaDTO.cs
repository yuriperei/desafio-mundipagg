using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Application.DTOs
{
    public class PessoaDTO
    {
        public string PessoaId { get; set; }
        public string Nome { get; set; }

        #region Navigation
        public LocalizacaoDTO Localizacao { get; set; }
        public ContatoDTO Contato { get; set; }
        #endregion
    }
}
