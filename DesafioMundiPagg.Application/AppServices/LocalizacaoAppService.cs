using AutoMapper;
using DesafioMundiPagg.Application.DTOs;
using DesafioMundiPagg.Application.Interfaces.AppServices;
using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Services;
using DesafioMundiPagg.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Application.AppServices
{
    public class LocalizacaoAppService : ILocalizacaoAppService
    {
        private readonly ILocalizacaoService _localizacaoService;

        public LocalizacaoAppService(ILocalizacaoService localizacaoService)
        {
            _localizacaoService = localizacaoService;
        }

        public void Adicionar(LocalizacaoDTO localizacaoDto)
        {
            localizacaoDto.LocalizacaoId = UtilService.GerarID();
            var localizacaoDomain = MapToDomain(localizacaoDto);
            _localizacaoService.Adicionar(localizacaoDomain, localizacaoDomain.LocalizacaoId);
        }

        public void Alterar(LocalizacaoDTO localizacaoDto)
        {
            var localizacaoDomain = MapToDomain(localizacaoDto);
            _localizacaoService.Alterar(localizacaoDomain, localizacaoDomain.LocalizacaoId);
        }

        public LocalizacaoDTO ObterPorId(string id)
        {
            var localizacaoDomain = _localizacaoService.ObterPorId(id);
            return MapToDTO(localizacaoDomain);
        }

        public IEnumerable<LocalizacaoDTO> ObterTodos()
        {
            var localizacoesDomain = _localizacaoService.ObterTodos();
            return MapToDTOList(localizacoesDomain);
        }

        public void Remover(string id)
        {
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
