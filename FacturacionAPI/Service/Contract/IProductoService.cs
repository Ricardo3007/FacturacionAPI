using FacturacionAPI.Domain.Entities;
using FacturacionAPI.Helpers;

namespace FacturacionAPI.Service.Contract
{
    public interface IProductoService
    {
        Task<Request<IEnumerable<Producto>>> GetAllProductosAsync();
    }
}
