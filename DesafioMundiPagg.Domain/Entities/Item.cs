using DesafioMundiPagg.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Domain.Entities
{
    public class Item
    {
        public string ItemId { get; set; }
        public string Titulo { get; set; }
        public TipoItem TipoItem { get; set; }
        public bool IsEmprestado { get; set; }

        #region Foreing Key
        //public string LocalizacaoId { get; set; }
        //public string EmprestimoId { get; set; }
        #endregion

        #region Navigation 
        public Localizacao Localizacao { get; set; }
        public IEnumerable<Emprestimo> Emprestimos { get; set; }
        #endregion
    }
}
