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
    public class EmprestimoAppService : IEmprestimoAppService
    {
        private readonly IEmprestimoService _emprestimoService;

        public EmprestimoAppService(IEmprestimoService emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }

        public void Adicionar(EmprestimoDTO emprestimoDto)
        {
            emprestimoDto.EmprestimoId = UtilService.GerarID();
            var emprestimoDomain = MapToDomain(emprestimoDto);
            _emprestimoService.Adicionar(emprestimoDomain, emprestimoDomain.EmprestimoId);
        }

        public void Alterar(EmprestimoDTO emprestimoDto)
        {
            var emprestimoDomain = MapToDomain(emprestimoDto);
            _emprestimoService.Alterar(emprestimoDomain, emprestimoDomain.EmprestimoId);
        }

        public EmprestimoDTO ObterPorId(string id)
        {
            var emprestimoDomain = _emprestimoService.ObterPorId(id);
            return MapToDTO(emprestimoDomain);
        }

        public IEnumerable<EmprestimoDTO> ObterTodos()
        {
            var emprestimosDomain = _emprestimoService.ObterTodos();
            return MapToDTOList(emprestimosDomain);
        }

        public void Remover(string id)
        {
            _emprestimoService.Remover(id);
        }

        private Emprestimo MapToDomain(EmprestimoDTO dto)
        {
            return Mapper.Map<Emprestimo>(dto);
        }

        private EmprestimoDTO MapToDTO(Emprestimo domain)
        {
            return Mapper.Map<EmprestimoDTO>(domain);
        }

        private IEnumerable<Emprestimo> MapToDomainList(IEnumerable<EmprestimoDTO> dto)
        {
            return Mapper.Map<IEnumerable<Emprestimo>>(dto);
        }

        private IEnumerable<EmprestimoDTO> MapToDTOList(IEnumerable<Emprestimo> domain)
        {
            return Mapper.Map<IEnumerable<EmprestimoDTO>>(domain);
        }
    }
}
