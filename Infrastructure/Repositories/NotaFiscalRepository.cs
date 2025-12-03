using NotaFiscalApp.Domain.Entities;
using NotaFiscalApp.Domain.Interfaces;

namespace NotaFiscalApp.Infrastructure.Data.Repositories
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private static readonly List<NotaFiscal> _notas = new();

        public Task AddAsync(NotaFiscal nota)
        {
            _notas.Add(nota);
            return Task.CompletedTask;
        }

        public Task<List<NotaFiscal>> GetAllAsync()
        {
            return Task.FromResult(_notas.AsEnumerable().ToList());
        }
    }
}
