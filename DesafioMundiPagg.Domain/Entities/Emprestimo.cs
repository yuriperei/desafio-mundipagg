using System;

namespace DesafioMundiPagg.Domain.Entities
{
    public class Emprestimo
    {
        public int EmprestimoId { get; set; }
        public DateTime DateDevolucao { get; set; }
        public DateTime DataEmprestimo { get; set; }

        #region Foreing Key
        public int ItemId { get; set; }
        public int PessoaId { get; set; }
        #endregion

        #region Virual
        public virtual Item Item { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        #endregion
    }
}