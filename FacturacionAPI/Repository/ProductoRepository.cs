using Dapper;
using FacturacionAPI.Domain.Entities;
using FacturacionAPI.Repository.Contract;
using Microsoft.Data.SqlClient;

namespace FacturacionAPI.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;

        public ProductoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Producto>> GetAllProductosAsync()
        {
            const string query = "SELECT * FROM CatProductos";
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Producto>(query);
            }
        }

    }
}
