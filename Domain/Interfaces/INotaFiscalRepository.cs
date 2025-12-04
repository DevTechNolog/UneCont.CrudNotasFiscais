using NotaFiscalApp.Domain.Entities;
using System;

namespace NotaFiscalApp.Domain.Interfaces
{
    public interface INotaFiscalRepository
    {
        Task AddAsync(NotaFiscal nota);
        Task<List<NotaFiscal>> GetAllAsync(Func<NotaFiscal, bool>? filtro = null);
    }
}
