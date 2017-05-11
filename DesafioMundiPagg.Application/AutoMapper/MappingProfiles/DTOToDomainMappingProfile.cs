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
            CreateMap<ItemDTO, Item>();
        }
    }
}
