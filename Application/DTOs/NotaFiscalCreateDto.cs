namespace Application.DTOs
{
    public class NotaFiscalCreateDto
    {
        public string? Numero { get; set; }
        public string? Cliente { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataEmissao { get; set; }
    }
}
