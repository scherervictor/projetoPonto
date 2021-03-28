using ApiTeste.Domain.Entities;
using ApiTeste.Domain.Interfaces.Repository;
using ApiTeste.Infra.Configuration;
using Dapper;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTeste.Infra.MySQL
{
    public class MySQLPontoRepository : IPontoRepository
    {
        private readonly MySqlConnection _mySqlConnection;

        public MySQLPontoRepository(MySQLConfiguration configuration)
        {
            _mySqlConnection = new MySqlConnection(configuration.ConnectionString);
        }

        public async Task<ICollection<PontoColaborador>> ListarPontoColaborador()
        {
            using (var connection = _mySqlConnection)
            {
                var result = await connection.QueryAsync<PontoColaborador>(@"
                    SELECT rp.NomeColaborador, TIMEDIFF(rp2.HoraRegistroPonto, rp.HoraRegistroPonto) as HorasTrabalhadas, DAY(rp.HoraRegistroPonto) as Dia
                    FROM registroponto as rp
                    JOIN registroponto as rp2 ON rp.EntradaSaida != rp2.EntradaSaida
                    WHERE rp.EntradaSaida = 1
                    AND rp.IdColaborador = rp2.IdColaborador
                ");

                return result.ToList();
            }
        }

        public async Task SalvarRegistroPonto(RegistrarPonto registrarPonto)
        {
            using (var connection = _mySqlConnection)
            {
                await connection.ExecuteAsync(@"
                    INSERT RegistroPonto (IdColaborador, NomeColaborador, HoraRegistroPonto, EntradaSaida) 
                    VALUES (@ColaboradorId, @NomeColaborador, @HoraRegistroPonto, @EntradaSaida)
                ",
                new
                {
                    ColaboradorId = registrarPonto.ColaboradorId,
                    NomeColaborador = registrarPonto.NomeColaborador,
                    HoraRegistroPonto = registrarPonto.HoraRegistroPonto,
                    EntradaSaida = registrarPonto.EntradaSaida
                });
            }
        }
    }
}
