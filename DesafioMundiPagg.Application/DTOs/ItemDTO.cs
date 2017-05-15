using DesafioMundiPagg.Domain.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Application.DTOs
{
    public class ItemDTO
    {
        public string ItemId { get; set; }
        public string Titulo { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TipoItem TipoItem { get; set; }
        public bool IsEmprestado { get; set; }
        public string EmprestimoId { get; set; }

        #region Navigation 
        public LocalizacaoDTO Localizacao { get; set; }
        public LocalizacaoDTO PessoaLocalizacao { get; set; }
        #endregion
    }
}
