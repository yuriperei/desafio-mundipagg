namespace DesafioMundiPagg.Domain.Entities
{
    public class Contato
    {
        public int ContatoId { get; set; }
        public string Valor { get; set; }
        public string Tipo { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}