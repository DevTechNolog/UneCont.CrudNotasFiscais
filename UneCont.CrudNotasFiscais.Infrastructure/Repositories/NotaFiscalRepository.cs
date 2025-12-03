using UneCont.CrudNotasFiscais.Domain.Entities;
using UneCont.CrudNotasFiscais.Domain.Interfaces;

namespace UneCont.CrudNotasFiscais.Infrastructure.Data.Repositories
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private static readonly List<NotaFiscal> _notas = new();


        public Task AddAsync(NotaFiscal nota)
        {
            _notas.Add(nota);
            return Task.CompletedTask;
        }


        public Task<IEnumerable<NotaFiscal>> GetAllAsync()
        {
            return Task.FromResult(_notas.AsEnumerable());
        }
    }
}
