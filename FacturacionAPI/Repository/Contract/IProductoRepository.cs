using FacturacionAPI.Domain.Entities;

namespace FacturacionAPI.Repository.Contract
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllProductosAsync();
    }
}
