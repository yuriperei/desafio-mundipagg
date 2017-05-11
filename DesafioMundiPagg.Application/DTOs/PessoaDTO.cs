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

        #region Foreing Key
        //public string LocalizacaoId { get; set; }
        #endregion

        #region Navigation
        public LocalizacaoDTO Localizacao { get; set; }
        public IEnumerable<ContatoDTO> Contatos { get; set; }
        [JsonIgnore]
        public IEnumerable<EmprestimoDTO> Emprestimos { get; set; }
        #endregion
    }
}
