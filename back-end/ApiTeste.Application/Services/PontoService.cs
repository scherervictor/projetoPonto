using ApiTeste.Application.Dtos;
using ApiTeste.Application.Interfaces.Services;
using ApiTeste.Application.Mappers;
using ApiTeste.Domain.Entities;
using ApiTeste.Domain.Enum;
using ApiTeste.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTeste.Application.Services
{
    public class PontoService : IPontoService
    {
        private readonly IPontoRepository _pontoRepository;

        public PontoService(IPontoRepository pontoRepository)
        {
            _pontoRepository = pontoRepository;
        }

        public async Task<ICollection<PontoColaboradorDto>> ListarPontos()
        {
            var listaPontoColaboradores = await _pontoRepository.ListarPontoColaborador();

            var result = listaPontoColaboradores.Select(x => x.MapDto());

            return result.ToList();
        }

        public async Task RegistrarPonto(RegistrarPontoDto registrarPontoDto)
        {
            Enum.TryParse<EntradaSaida>(registrarPontoDto.EntradaSaida.ToString(),true, out var result);

            var registrarPonto = new RegistrarPonto(registrarPontoDto.ColaboradorId, registrarPontoDto.NomeColaborador, DateTime.Now, result);

            await _pontoRepository.SalvarRegistroPonto(registrarPonto);
        }
    }
}
