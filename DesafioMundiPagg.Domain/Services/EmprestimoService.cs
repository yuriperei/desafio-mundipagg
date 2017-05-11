using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Repositories;
using DesafioMundiPagg.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Domain.Services
{
    public class EmprestimoService : ServiceBase<Emprestimo>, IEmprestimoService
    {
        public EmprestimoService(IEmprestimoRepository emprestimoRepository) : base(emprestimoRepository)
        {
        }
    }
}
