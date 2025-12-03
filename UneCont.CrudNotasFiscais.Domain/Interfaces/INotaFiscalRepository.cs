using UneCont.CrudNotasFiscais.Domain.Entities;

namespace UneCont.CrudNotasFiscais.Domain.Interfaces
{
    public interface INotaFiscalRepository
    {
        Task AddAsync(NotaFiscal nota);
        Task<IEnumerable<NotaFiscal>> GetAllAsync();
    }
}
