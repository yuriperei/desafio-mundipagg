﻿using System;
using System.Collections.Generic;

namespace DesafioMundiPagg.Domain.Entities
{
    public class Pessoa
    {
        public string PessoaId { get; set; }
        public string Nome { get; set; }

        #region Foreing Key
        //public string LocalizacaoId { get; set; }
        #endregion

        #region Navigation
        public Localizacao Localizacao { get; set; }
        public IEnumerable<Contato> Contatos { get; set; }
        public IEnumerable<Emprestimo> Emprestimos { get; set; }
        #endregion
    }
}