using Dapper;
using FacturacionAPI.Domain.Entities;
using FacturacionAPI.Repository.Contract;
using Microsoft.Data.SqlClient;

namespace FacturacionAPI.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Cliente>("SELECT * FROM TblClientes");
            }
        }

    }
}
