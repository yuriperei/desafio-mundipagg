using AutoMapper;
using DesafioMundiPagg.Application.DTOs;
using DesafioMundiPagg.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Application.AutoMapper.MappingProfiles
{
    public class DTOToDomainMappingProfile : Profile
    {
        public DTOToDomainMappingProfile()
        {
            CreateMap<ContatoDTO, Contato>();
            CreateMap<EmprestimoDTO, Emprestimo>();
            CreateMap<ItemDTO, Item>();
            CreateMap<LocalizacaoDTO, Localizacao>();
            CreateMap<PessoaDTO, Pessoa>();
        }
    }
}
