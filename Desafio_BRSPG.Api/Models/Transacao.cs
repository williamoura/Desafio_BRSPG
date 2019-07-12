namespace Desafio_BRSPG.Api.Models
{
    public class Transacao
    {
        public decimal Valor { get; set; }
        public string Adquirente { get; set; }
        public string Bandeira { get; set; }
        public string Tipo { get; set; }
    }
}
