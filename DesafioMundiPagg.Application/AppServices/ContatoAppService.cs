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
    public class ContatoAppService : IContatoAppService
    {
        private readonly IContatoService _contatoService;

        public ContatoAppService(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public void Adicionar(ContatoDTO contatoDto)
        {
            contatoDto.ContatoId = UtilService.GerarID();
            var contatoDomain = MapToDomain(contatoDto);
            _contatoService.Adicionar(contatoDomain, contatoDomain.ContatoId);
        }

        public void Alterar(ContatoDTO contatoDto)
        {
            var contatoDomain = MapToDomain(contatoDto);
            _contatoService.Alterar(contatoDomain, contatoDomain.ContatoId);
        }

        public ContatoDTO ObterPorId(string id)
        {
            var contatoDomain = _contatoService.ObterPorId(id);
            return MapToDTO(contatoDomain);
        }

        public IEnumerable<ContatoDTO> ObterTodos()
        {
            var contatosDomain = _contatoService.ObterTodos();
            return MapToDTOList(contatosDomain);
        }

        public void Remover(string id)
        {
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
