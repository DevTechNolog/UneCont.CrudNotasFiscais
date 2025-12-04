using Domain.Entities;

namespace NotaFiscalApp.Domain.Entities
{
    public class NotaFiscal : DomainBase
    {
        public string? Numero { get; set; }
        public string? Cliente { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
