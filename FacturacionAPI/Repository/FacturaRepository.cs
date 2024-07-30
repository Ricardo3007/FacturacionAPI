using Dapper;
using FacturacionAPI.Domain.Entities;
using FacturacionAPI.Repository.Contract;
using Microsoft.Data.SqlClient;

namespace FacturacionAPI.Repository
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly string _connectionString;

        public FacturaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public async Task<List<Factura>> GetFacturaByIdAsync(int? idCliente, int? numeroFactura)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query;
                object parameters;

                if (idCliente.HasValue && idCliente.Value != 0)
                {
                    query = "SELECT * FROM TblFacturas WHERE IdCliente = @IdCliente";
                    parameters = new { IdCliente = idCliente.Value };
                }
                else if (numeroFactura.HasValue)
                {
                    query = "SELECT * FROM TblFacturas WHERE NumeroFactura = @NumeroFactura";
                    parameters = new { NumeroFactura = numeroFactura.Value };
                }
                else
                {
                    return new List<Factura>(); // Devuelve una lista vacía en lugar de null.
                }

                var facturas = await connection.QueryAsync<Factura>(query, parameters);
                return facturas.ToList(); 
            }
        }


        public async Task<bool> SaveFacturaAsync(Factura factura)
        {
            const string insertFacturaQuery = @"
                INSERT INTO TblFacturas (FechaEmisionFactura, IdCliente, NumeroFactura, NumeroTotalArticulos, SubTotalFacturas, TotalImpuestos, TotalFactura)
                VALUES (@FechaEmisionFactura, @IdCliente, @NumeroFactura, @NumeroTotalArticulos, @SubTotalFacturas, @TotalImpuestos, @TotalFactura);
                SELECT CAST(SCOPE_IDENTITY() as int)"; // Obtiene el ID generado de la factura

            const string insertDetalleFacturaQuery = @"
                INSERT INTO TblDetallesFactura (IdFactura, IdProducto, CantidadDeProducto, PrecioUnitarioProducto, SubtotalProducto, Notas)
                VALUES (@IdFactura, @IdProducto, @CantidadDeProducto, @PrecioUnitarioProducto, @SubtotalProducto, @Notas)";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var facturaId = await connection.QuerySingleAsync<int>(insertFacturaQuery, factura, transaction);

                        foreach (var detalle in factura.Detalles)
                        {
                            detalle.IdFactura = facturaId; // Asignamos el ID de la factura a los detalles
                            await connection.ExecuteAsync(insertDetalleFacturaQuery, detalle, transaction);
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}
