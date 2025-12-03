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

        public async Task<List<NotaFiscalViewModel>> ListarAsync()
        {
            var listNotasFiscais = await _repository.GetAllAsync();
            return _mapper.Map<List<NotaFiscalViewModel>>(listNotasFiscais);                     
        }
    }
}
