using Application.DTOs;
using Application.ViewModel;
using AutoMapper;
using NotaFiscalApp.Domain.Entities;

namespace NotaFiscalApp.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<NotaFiscal, NotaFiscalCreateDto>().ReverseMap();
            CreateMap<NotaFiscal, NotaFiscalViewModel>().ReverseMap();
        }
    }
}
