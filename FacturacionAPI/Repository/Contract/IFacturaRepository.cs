using FacturacionAPI.Domain.Entities;

namespace FacturacionAPI.Repository.Contract
{
    public interface IFacturaRepository
    {
        Task<List<Factura>> GetFacturaByIdAsync(int? idCliente, int? numeroFactura);
        Task<bool> SaveFacturaAsync(Factura factura);
    }
}
