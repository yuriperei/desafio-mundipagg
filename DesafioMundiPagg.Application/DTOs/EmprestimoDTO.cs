using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Application.DTOs
{
    public class EmprestimoDTO
    {
        public string EmprestimoId { get; set; }
        public string DataDevolucao { get; set; }
        public string DataEmprestimo { get; set; }

        #region Foreing Key
        //public string ItemId { get; set; }
        //public string PessoaId { get; set; }
        #endregion

        #region Navigation
        public ItemDTO Item { get; set; }
        public PessoaDTO Pessoa { get; set; }
        #endregion
    }
}
