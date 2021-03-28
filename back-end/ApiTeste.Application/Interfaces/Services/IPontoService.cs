using ApiTeste.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTeste.Application.Interfaces.Services
{
    public interface IPontoService
    {
        Task RegistrarPonto(RegistrarPontoDto registrarPontoDto);

        Task<ICollection<PontoColaboradorDto>> ListarPontos();
    }
}
