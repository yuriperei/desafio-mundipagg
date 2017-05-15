using System;
using System.Collections.Generic;

namespace DesafioMundiPagg.Domain.Entities
{
    public class Pessoa
    {
        public string PessoaId { get; set; }
        public string Nome { get; set; }

        #region Navigation
        public Localizacao Localizacao { get; set; }
        public Contato Contato { get; set; }
        #endregion
    }
}