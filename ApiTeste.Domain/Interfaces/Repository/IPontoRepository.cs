using ApiTeste.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTeste.Domain.Interfaces.Repository
{
    public interface IPontoRepository
    {
        Task SalvarRegistroPonto(RegistrarPonto registrarPonto);

        Task<ICollection<PontoColaborador>> ListarPontoColaborador();
    }
}
