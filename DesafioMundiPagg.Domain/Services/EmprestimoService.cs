using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Repositories;
using DesafioMundiPagg.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Domain.Services
{
    public class EmprestimoService : ServiceBase<Emprestimo>, IEmprestimoService
    {
        public EmprestimoService(IEmprestimoRepository emprestimoRepository, ILogger<EmprestimoService> logger) : base(emprestimoRepository, logger){}
    }
}
