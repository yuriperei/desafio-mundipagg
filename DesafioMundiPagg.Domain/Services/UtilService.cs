using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Domain.Services
{
    public class UtilService
    {
        public static string GerarID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
