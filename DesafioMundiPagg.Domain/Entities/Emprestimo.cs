using System;

namespace DesafioMundiPagg.Domain.Entities
{
    public class Emprestimo
    {
        public int IdEmprestimo { get; set; }
        public DateTime DateDevolucao { get; set; }
        public DateTime DataEmprestimo { get; set; }

        #region Foreing Key
        public int IdItem { get; set; }
        public int IdPessoa { get; set; }
        #endregion

        #region Virual
        public virtual Item Item { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        #endregion
    }
}