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
    public class PessoaAppService : IPessoaAppService
    {
        private readonly IPessoaService _pessoaService;

        public PessoaAppService(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public void Adicionar(PessoaDTO pessoaDto)
        {
            pessoaDto.PessoaId = UtilService.GerarID();
            var pessoaDomain = MapToDomain(pessoaDto);
            _pessoaService.Adicionar(pessoaDomain, pessoaDomain.PessoaId);
        }

        public void Alterar(PessoaDTO pessoaDto)
        {
            var pessoaDomain = MapToDomain(pessoaDto);
            _pessoaService.Alterar(pessoaDomain, pessoaDomain.PessoaId);
        }

        public PessoaDTO ObterPorId(string id)
        {
            var pessoaDomain = _pessoaService.ObterPorId(id);
            return MapToDTO(pessoaDomain);
        }

        public IEnumerable<PessoaDTO> ObterTodos()
        {
            var pessoasDomain = _pessoaService.ObterTodos();
            return MapToDTOList(pessoasDomain);
        }

        public void Remover(string id)
        {
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
