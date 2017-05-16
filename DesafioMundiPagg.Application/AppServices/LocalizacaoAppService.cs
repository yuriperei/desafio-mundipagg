using AutoMapper;
using DesafioMundiPagg.Application.DTOs;
using DesafioMundiPagg.Application.Interfaces.AppServices;
using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Services;
using DesafioMundiPagg.Domain.Services;
using DesafioMundiPagg.Infra.CrossCutting.Logger;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Application.AppServices
{
    public class LocalizacaoAppService : ILocalizacaoAppService
    {
        private readonly ILocalizacaoService _localizacaoService;
        private readonly ILogger _logger;

        public LocalizacaoAppService(ILocalizacaoService localizacaoService, ILogger<LocalizacaoAppService> logger)
        {
            _localizacaoService = localizacaoService;
            _logger = logger;
        }

        public void Adicionar(LocalizacaoDTO localizacaoDto)
        {
            _logger.LogInformation(LoggingEvents.ADICIONA, "Localização {ID} adicionada", localizacaoDto.LocalizacaoId);
            localizacaoDto.LocalizacaoId = UtilService.GerarID();
            var localizacaoDomain = MapToDomain(localizacaoDto);
            _localizacaoService.Adicionar(localizacaoDomain, localizacaoDomain.LocalizacaoId);
        }

        public void Alterar(LocalizacaoDTO localizacaoDto)
        {
            _logger.LogInformation(LoggingEvents.ATUALIZAR, "Localização {ID} alterada", localizacaoDto.LocalizacaoId);
            var localizacaoDomain = MapToDomain(localizacaoDto);
            _localizacaoService.Alterar(localizacaoDomain, localizacaoDomain.LocalizacaoId);
        }

        public LocalizacaoDTO ObterPorId(string id)
        {
            _logger.LogInformation(LoggingEvents.OBTER_POR_ID, "Obter Localização {ID}", id);
            var localizacaoDomain = _localizacaoService.ObterPorId(id);
            return MapToDTO(localizacaoDomain);
        }

        public IEnumerable<LocalizacaoDTO> ObterTodos()
        {
            _logger.LogInformation(LoggingEvents.LISTAR, "Obter todas as Localizações");
            var localizacaosDomain = _localizacaoService.ObterTodos();
            return MapToDTOList(localizacaosDomain);
        }

        public void Remover(string id)
        {
            _logger.LogInformation(LoggingEvents.REMOVER, "Remover Localização {ID}", id);
            _localizacaoService.Remover(id);
        }

        private Localizacao MapToDomain(LocalizacaoDTO dto)
        {
            return Mapper.Map<Localizacao>(dto);
        }

        private LocalizacaoDTO MapToDTO(Localizacao domain)
        {
            return Mapper.Map<LocalizacaoDTO>(domain);
        }

        private IEnumerable<Localizacao> MapToDomainList(IEnumerable<LocalizacaoDTO> dto)
        {
            return Mapper.Map<IEnumerable<Localizacao>>(dto);
        }

        private IEnumerable<LocalizacaoDTO> MapToDTOList(IEnumerable<Localizacao> domain)
        {
            return Mapper.Map<IEnumerable<LocalizacaoDTO>>(domain);
        }
    }
}
