using DesafioMundiPagg.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Domain.Entities
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Titulo { get; set; }
        public TipoItem TipoItem { get; set; }
        public bool IsEmprestado { get; set; }

        #region Foreing Key
        public int LocalizacaoId { get; set; }
        public int EmprestimoId { get; set; }
        #endregion

        #region Virtual 
        public virtual Localizacao Localizacao { get; set; }
        public virtual ICollection<Emprestimo> Emprestimo { get; set; }
        #endregion
    }
}
