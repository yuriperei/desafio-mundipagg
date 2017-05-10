using System;

namespace DesafioMundiPagg.Domain.Entities
{
    public class Contato
    {
        public string ContatoId { get; set; }
        public string Valor { get; set; }
        public string Tipo { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}