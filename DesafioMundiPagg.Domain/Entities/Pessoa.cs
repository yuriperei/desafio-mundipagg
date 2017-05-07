using System.Collections.Generic;

namespace DesafioMundiPagg.Domain.Entities
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }

        #region Foreing Key
        public int IdLocalizacao { get; set; }
        #endregion

        #region Virual
        public virtual Localizacao Localizacao { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
        #endregion
    }
}