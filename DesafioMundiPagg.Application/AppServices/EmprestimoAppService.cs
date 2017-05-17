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
    public class EmprestimoAppService : IEmprestimoAppService
    {
        private readonly IEmprestimoService _emprestimoService;
        private readonly ILogger _logger;

        public EmprestimoAppService(IEmprestimoService emprestimoService, ILogger<EmprestimoAppService> logger)
        {
            _emprestimoService = emprestimoService;
            _logger = logger;
        }

        public void Adicionar(EmprestimoDTO emprestimoDto)
        {
            _logger.LogInformation(LoggingEvents.ADICIONA, "Emprestimo {ID} adicionado", emprestimoDto.EmprestimoId);
            emprestimoDto.EmprestimoId = UtilService.GerarID();
            var emprestimoDomain = MapToDomain(emprestimoDto);
            _emprestimoService.Adicionar(emprestimoDomain, emprestimoDomain.EmprestimoId);
        }

        public void Alterar(EmprestimoDTO emprestimoDto)
        {
            _logger.LogInformation(LoggingEvents.ATUALIZAR, "Emprestimo {ID} alterado", emprestimoDto.EmprestimoId);
            var emprestimoDomain = MapToDomain(emprestimoDto);
            _emprestimoService.Alterar(emprestimoDomain, emprestimoDomain.EmprestimoId);
        }

        public EmprestimoDTO ObterPorId(string id)
        {
            _logger.LogInformation(LoggingEvents.OBTER_POR_ID, "Obter Emprestimo {ID}", id);
            var emprestimoDomain = _emprestimoService.ObterPorId(id);
            return MapToDTO(emprestimoDomain);
        }

        public IEnumerable<EmprestimoDTO> ObterTodos()
        {
            _logger.LogInformation(LoggingEvents.LISTAR, "Obter todos os Emprestimos");
            var emprestimosDomain = _emprestimoService.ObterTodos();
            return MapToDTOList(emprestimosDomain);
        }

        public void Remover(string id)
        {
            _logger.LogInformation(LoggingEvents.REMOVER, "Remover Emprestimo {ID}", id);
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
