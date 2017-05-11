using System;

namespace DesafioMundiPagg.Infra.CrossCutting.Logger
{
    public class LoggingEvents
    {
        public const int LISTAR = 1000;
        public const int OBTER_POR_ID = 1001;
        public const int ADICIONA = 1002;
        public const int ATUALIZAR = 1003;
        public const int REMOVER = 1004;

        public const int OBTER_POR_ID_NOTFOUND = 4000;
    }
}
