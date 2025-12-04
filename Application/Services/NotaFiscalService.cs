using Application.DTOs;
using Application.Interfaces;
using Application.ViewModel;
using AutoMapper;
using NotaFiscalApp.Domain.Entities;
using NotaFiscalApp.Domain.Interfaces;

namespace Application.Services
{
    public class NotaFiscalService : INotaFiscalService
    {
        private readonly IMapper _mapper;
        private readonly INotaFiscalRepository _repository;

        public NotaFiscalService(
            IMapper mapper,
            INotaFiscalRepository repository
            )
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task CadastrarAsync(NotaFiscalCreateDto dto)
        {
            var entity = _mapper.Map<NotaFiscal>(dto);
            await _repository.AddAsync(entity);
        }

        public async Task<List<NotaFiscalViewModel>> ListarAsync(string? nomeCliente, bool ordenarValor = false)
        {
            Func<NotaFiscal, bool> filtro = filtro = f => true;

            if (!string.IsNullOrWhiteSpace(nomeCliente))            
                filtro = x => x.Cliente == nomeCliente;        

            var listNotasFiscais = await _repository.GetAllAsync(filtro);
      
            if (ordenarValor)
                listNotasFiscais = listNotasFiscais.OrderBy(x => x.Valor).ToList();

            return _mapper.Map<List<NotaFiscalViewModel>>(listNotasFiscais);                     
        }
    }
}
