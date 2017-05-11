using AutoMapper;
using DesafioMundiPagg.Application.AutoMapper.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(c =>
            {
                c.AddProfile<DomainToDTOMappingProfile>();
                c.AddProfile<DTOToDomainMappingProfile>();
            });
        }
    }
}
