using System;

namespace ApiTeste.Domain.Entities
{
    public class PontoColaborador
    {
        public string NomeColaborador { get; private set; }

        public string Dia { get; private set; }

        public object HorasTrabalhadas { get; private set; }
    }
}
