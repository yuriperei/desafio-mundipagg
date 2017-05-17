using AutoMapper;
using DesafioMundiPagg.Application.DTOs;
using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Application.AutoMapper.MappingProfiles
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Contato, ContatoDTO>();
            CreateMap<Emprestimo, EmprestimoDTO>()
                .ForMember(dest => dest.DataEmprestimo, opt => opt.MapFrom(src =>
                UtilService.FormatarData(src.DataEmprestimo)
                )).ForMember(dest => dest.DataDevolucao, opt => opt.MapFrom(src =>
                UtilService.FormatarData(src.DataDevolucao)
                ));
            CreateMap<Item, ItemDTO>();
            CreateMap<Localizacao, LocalizacaoDTO>();
            CreateMap<Pessoa, PessoaDTO>();
        }
    }
}
