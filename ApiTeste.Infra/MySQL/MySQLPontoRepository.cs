using System.Collections.Generic;
using System.Threading.Tasks;
using ApiTeste.Domain.Entities;
using ApiTeste.Domain.Interfaces.Repository;
using MySqlConnector;

namespace ApiTeste.Infra.MySQL
{
    public class MySQLPontoRepository : IPontoRepository
    {
        private readonly MySqlConnection _mySqlConnection;

        public MySQLPontoRepository(MySqlConnection mySqlConnection)
        {
            _mySqlConnection = mySqlConnection;
        }

        public Task<ICollection<PontoColaborador>> ListarPontoColaborador()
        {
            using (var connection = _mySqlConnection)
            {
                connection.Query<>
            }
        }

        public Task SalvarRegistroPonto(RegistrarPonto registrarPonto)
        {
            throw new System.NotImplementedException();
        }
    }
}
