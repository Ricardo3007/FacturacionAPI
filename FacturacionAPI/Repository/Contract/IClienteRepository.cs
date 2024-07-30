using FacturacionAPI.Domain.Entities;

namespace FacturacionAPI.Repository.Contract
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllClientesAsync();
    }
}
