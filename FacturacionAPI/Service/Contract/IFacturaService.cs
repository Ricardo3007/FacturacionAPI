using FacturacionAPI.Domain.Entities;
using FacturacionAPI.Helpers;

namespace FacturacionAPI.Service.Contract
{
    public interface IFacturaService
    {
        Task<Request<bool>> SaveFacturaAsync(Factura factura);

        Task<Request<List<Factura>>> GetFacturaByIdAsync(int? idCliente, int? numeroFactura);

    }
}
