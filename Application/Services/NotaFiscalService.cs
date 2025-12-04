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
            await ValidacoesCreateAsync(dto);
            var entity = _mapper.Map<NotaFiscal>(dto);
            await _repository.AddAsync(entity);
        }

        private async Task ValidacoesCreateAsync(NotaFiscalCreateDto dto)
        {
            // Valida se o Numero da nota foi informado.
            if (string.IsNullOrWhiteSpace(dto.Numero))
                throw new Exception($"Numero da nota nao informado");

            // Valida se o Nome do Cliente foi informado.
            if (string.IsNullOrWhiteSpace(dto.Cliente))
                throw new Exception($"Nome do Cliente nao informado");

            // Valida se a Data de Emissão não é futura.
            if (dto.DataEmissao > DateTime.Now)
                throw new Exception("A Data de Emissão não pode ser futura.");

            // Valida se o Valor é maior que zero.
            if (dto.Valor <= 0)
                throw new Exception("O Valor da nota deve ser maior que zero.");

            // Valida se o Numero da nota já existe.
            var listaNotaExistente = await ListarAsync(numeroNota: dto.Numero);
            if (listaNotaExistente.Any())
                throw new Exception($"Já existe uma nota cadastrada com o Numero {dto.Numero}");
           
            dto.Cliente = dto.Cliente?.ToLower();    
        }

        public async Task<List<NotaFiscalViewModel>> ListarAsync(string? nomeCliente = null, string? numeroNota = null, bool? ordenarValor = null)
        {
            Func<NotaFiscal, bool> filtro = filtro = f => true;

            if (!string.IsNullOrWhiteSpace(nomeCliente))
                filtro = x => !string.IsNullOrWhiteSpace(x.Cliente) && x.Cliente.Contains(nomeCliente.ToLower());
            if (!string.IsNullOrWhiteSpace(numeroNota))
                filtro = x => x.Numero == numeroNota;

            var listNotasFiscais = await _repository.GetAllAsync(filtro);

            if (ordenarValor is not null)
                listNotasFiscais = ordenarValor == false ? listNotasFiscais.OrderBy(x => x.Valor).ToList() : listNotasFiscais.OrderByDescending(x => x.Valor).ToList();

            return _mapper.Map<List<NotaFiscalViewModel>>(listNotasFiscais);
        }
    }
}
