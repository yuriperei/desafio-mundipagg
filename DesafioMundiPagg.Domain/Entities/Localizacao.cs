namespace DesafioMundiPagg.Domain.Entities
{
    public class Localizacao
    {
        public int LocalizacaoId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
    }
}