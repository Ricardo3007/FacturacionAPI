using FacturacionAPI.Domain.Entities;
using FacturacionAPI.Helpers;

namespace FacturacionAPI.Service.Contract
{
    public interface IClienteService
    {
        Task<Request<IEnumerable<Cliente>>> GetAllClientesAsync();
    }
}
