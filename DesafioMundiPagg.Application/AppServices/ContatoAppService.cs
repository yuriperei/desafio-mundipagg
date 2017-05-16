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
    public class ContatoAppService : IContatoAppService
    {
        private readonly IContatoService _contatoService;
        private readonly ILogger _logger;

        public ContatoAppService(IContatoService contatoService, ILogger<ContatoAppService> logger)
        {
            _contatoService = contatoService;
            _logger = logger;
        }

        public void Adicionar(ContatoDTO contatoDto)
        {
            _logger.LogInformation(LoggingEvents.ADICIONA, "Contato {ID} adicionado", contatoDto.ContatoId);
            contatoDto.ContatoId = UtilService.GerarID();
            var contatoDomain = MapToDomain(contatoDto);
            _contatoService.Adicionar(contatoDomain, contatoDomain.ContatoId);
        }

        public void Alterar(ContatoDTO contatoDto)
        {
            _logger.LogInformation(LoggingEvents.ATUALIZAR, "Contato {ID} alterado", contatoDto.ContatoId);
            var contatoDomain = MapToDomain(contatoDto);
            _contatoService.Alterar(contatoDomain, contatoDomain.ContatoId);
        }

        public ContatoDTO ObterPorId(string id)
        {
            _logger.LogInformation(LoggingEvents.OBTER_POR_ID, "Obter Contato {ID}", id);
            var contatoDomain = _contatoService.ObterPorId(id);
            return MapToDTO(contatoDomain);
        }

        public IEnumerable<ContatoDTO> ObterTodos()
        {
            _logger.LogInformation(LoggingEvents.LISTAR, "Obter todos os Contatos");
            var contatosDomain = _contatoService.ObterTodos();
            return MapToDTOList(contatosDomain);
        }

        public void Remover(string id)
        {
            _logger.LogInformation(LoggingEvents.REMOVER, "Remover Contato {ID}", id);
            _contatoService.Remover(id);
        }

        private Contato MapToDomain(ContatoDTO dto)
        {
            return Mapper.Map<Contato>(dto);
        }

        private ContatoDTO MapToDTO(Contato domain)
        {
            return Mapper.Map<ContatoDTO>(domain);
        }

        private IEnumerable<Contato> MapToDomainList(IEnumerable<ContatoDTO> dto)
        {
            return Mapper.Map<IEnumerable<Contato>>(dto);
        }

        private IEnumerable<ContatoDTO> MapToDTOList(IEnumerable<Contato> domain)
        {
            return Mapper.Map<IEnumerable<ContatoDTO>>(domain);
        }
    }
}
