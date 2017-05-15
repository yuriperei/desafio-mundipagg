using System;

namespace DesafioMundiPagg.Domain.Entities
{
    public class Emprestimo
    {
        public string EmprestimoId { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataEmprestimo { get; set; }

        #region Navigation
        public Item Item { get; set; }
        public Pessoa Pessoa { get; set; }
        #endregion
    }
}