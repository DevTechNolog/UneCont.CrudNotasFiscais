using NotaFiscalApp.Domain.Entities;

namespace NotaFiscalApp.Domain.Interfaces
{
    public interface INotaFiscalRepository
    {
        Task AddAsync(NotaFiscal nota);
        Task<IEnumerable<NotaFiscal>> GetAllAsync();
    }
}
