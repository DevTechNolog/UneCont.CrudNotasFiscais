using Application.DTOs;
using Application.ViewModel;
using NotaFiscalApp.Domain.Entities;

namespace Application.Interfaces
{
    public interface INotaFiscalService
    {
        Task CadastrarAsync(NotaFiscalCreateDto dto);   
        Task<List<NotaFiscalViewModel>> ListarAsync(string? nomeCliente = null, string? numeroNota = null, bool? ordenarValor = null);
    }
}
