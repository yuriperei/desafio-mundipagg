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
    public class PessoaAppService : IPessoaAppService
    {
        private readonly IPessoaService _pessoaService;
        private readonly ILogger _logger;

        public PessoaAppService(IPessoaService pessoaService, ILogger<PessoaAppService> logger)
        {
            _pessoaService = pessoaService;
            _logger = logger;
        }

        public void Adicionar(PessoaDTO pessoaDto)
        {
            _logger.LogInformation(LoggingEvents.ADICIONA, "Pessoa {ID} adicionada", pessoaDto.PessoaId);
            pessoaDto.PessoaId = UtilService.GerarID();
            var pessoaDomain = MapToDomain(pessoaDto);
            _pessoaService.Adicionar(pessoaDomain, pessoaDomain.PessoaId);
        }

        public void Alterar(PessoaDTO pessoaDto)
        {
            _logger.LogInformation(LoggingEvents.ATUALIZAR, "Pessoa {ID} alterada", pessoaDto.PessoaId);
            var pessoaDomain = MapToDomain(pessoaDto);
            _pessoaService.Alterar(pessoaDomain, pessoaDomain.PessoaId);
        }

        public PessoaDTO ObterPorId(string id)
        {
            _logger.LogInformation(LoggingEvents.OBTER_POR_ID, "Obter Pessoa {ID}", id);
            var pessoaDomain = _pessoaService.ObterPorId(id);
            return MapToDTO(pessoaDomain);
        }

        public IEnumerable<PessoaDTO> ObterTodos()
        {
            _logger.LogInformation(LoggingEvents.LISTAR, "Obter todas as Pessoas");
            var pessoasDomain = _pessoaService.ObterTodos();
            return MapToDTOList(pessoasDomain);
        }

        public void Remover(string id)
        {
            _logger.LogInformation(LoggingEvents.REMOVER, "Remover Pessoa {ID}", id);
            _pessoaService.Remover(id);
        }

        private Pessoa MapToDomain(PessoaDTO dto)
        {
            return Mapper.Map<Pessoa>(dto);
        }

        private PessoaDTO MapToDTO(Pessoa domain)
        {
            return Mapper.Map<PessoaDTO>(domain);
        }

        private IEnumerable<Pessoa> MapToDomainList(IEnumerable<PessoaDTO> dto)
        {
            return Mapper.Map<IEnumerable<Pessoa>>(dto);
        }

        private IEnumerable<PessoaDTO> MapToDTOList(IEnumerable<Pessoa> domain)
        {
            return Mapper.Map<IEnumerable<PessoaDTO>>(domain);
        }
    }
}
