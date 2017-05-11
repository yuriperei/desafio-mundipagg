using System;

namespace DesafioMundiPagg.Domain.Entities
{
    public class Emprestimo
    {
        public string EmprestimoId { get; set; }
        public DateTime DateDevolucao { get; set; }
        public DateTime DataEmprestimo { get; set; }

        #region Foreing Key
        //public string ItemId { get; set; }
        //public string PessoaId { get; set; }
        #endregion

        #region Navigation
        public Item Item { get; set; }
        public Pessoa Pessoa { get; set; }
        #endregion
    }
}