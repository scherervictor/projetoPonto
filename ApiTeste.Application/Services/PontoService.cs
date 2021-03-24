using ApiTeste.Application.Dtos;
using ApiTeste.Application.Interfaces.Services;
using ApiTeste.Domain.Entities;
using ApiTeste.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
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

            var result = listaPontoColaboradores.MapDto();

            return result;
        }

        public async Task RegistrarPonto(RegistrarPontoDto registrarPontoDto)
        {
            var result = new RegistrarPonto();
        }
    }
}
