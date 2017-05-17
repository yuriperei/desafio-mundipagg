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

        public static string FormatarData(DateTime data)
        {
            string[] campos = data.ToString().Split(' ');
            return campos[0];
        }
    }
}
