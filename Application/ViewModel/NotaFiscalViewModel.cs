namespace Application.ViewModel
{
    public class NotaFiscalViewModel
    {
        public Guid Id { get; set; }
        public string? Numero { get; set; }
        public string? Cliente { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
