using ApiTeste.Domain.Enum;
using System;

namespace ApiTeste.Domain.Entities
{
    public class RegistrarPonto
    {
        public int ColaboradorId { get; private set; }

        public string NomeColaborador { get; private set; }

        public DateTime HoraRegistroPonto { get; private set; }

        public EntradaSaida EntradaSaida { get; private set; }

        public RegistrarPonto(int colaboradorId, string nomeColaborador, DateTime horaRegistroPonto, EntradaSaida entradaSaida)
        {
            ColaboradorId = colaboradorId;
            NomeColaborador = nomeColaborador;
            HoraRegistroPonto = horaRegistroPonto;
            EntradaSaida = entradaSaida;
        }
    }
}
