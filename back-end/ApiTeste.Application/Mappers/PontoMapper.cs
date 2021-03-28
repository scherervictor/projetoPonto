using ApiTeste.Application.Dtos;
using ApiTeste.Domain.Entities;

namespace ApiTeste.Application.Mappers
{
    public static class PontoMapper
    {
        public static PontoColaboradorDto MapDto(this PontoColaborador pontoColaborador) =>
            new PontoColaboradorDto
            {
                Dia = pontoColaborador.Dia,
                HorasTrabalhadas = pontoColaborador.HorasTrabalhadas.ToString(),
                NomeColaborador = pontoColaborador.NomeColaborador
            };
    }
}
