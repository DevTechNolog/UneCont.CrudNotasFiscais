using Application.DTOs;
using Application.Services;
using AutoMapper;
using Moq;
using NotaFiscalApp.Domain.Entities;
using NotaFiscalApp.Domain.Interfaces;
using Xunit;

namespace Tests
{
    public class NotaServiceTests
    {
        [Fact]
        public async Task CadastrarAsync_DeveChamarAddAsyncComEntidadeMapeada()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var repoMock = new Mock<INotaFiscalRepository>();

            var dto = new NotaFiscalCreateDto
            {
                Numero = "123",
                Cliente = "Igor",
                Valor = 100,
                DataEmissao = DateTime.Now
            };

            var entityMapeada = new NotaFiscal
            {
                Numero = dto.Numero,
                Cliente = dto.Cliente,
                Valor = dto.Valor,
                DataEmissao = dto.DataEmissao
            };

            mapperMock.Setup(m => m.Map<NotaFiscal>(dto))
                      .Returns(entityMapeada);

            var service = new NotaFiscalService(mapperMock.Object, repoMock.Object);

            // Act
            await service.CadastrarAsync(dto);

            // Assert
            repoMock.Verify(r => r.AddAsync(It.Is<NotaFiscal>(n =>
                n.Numero == dto.Numero &&
                n.Cliente == dto.Cliente &&
                n.Valor == dto.Valor &&
                n.DataEmissao == dto.DataEmissao
            )), Times.Once);

            mapperMock.Verify(m => m.Map<NotaFiscal>(dto), Times.Once);
        }
    }
}
