using DesafioMundiPagg.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Domain.Entities
{
    public class Item
    {
        public int IdItem { get; set; }
        public string Titulo { get; set; }
        public TipoItem TipoItem { get; set; }
        public bool IsEmprestado { get; set; }

        #region Foreing Key
        public int IdLocalizacao { get; set; }
        public int IdEmprestimo { get; set; }
        #endregion

        #region Virtual 
        public virtual Localizacao Localizacao { get; set; }
        public virtual ICollection<Emprestimo> Emprestimo { get; set; }
        #endregion
    }
}
