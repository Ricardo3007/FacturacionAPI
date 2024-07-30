using FacturacionAPI.Domain.Entities;
using FacturacionAPI.Helpers;
using FacturacionAPI.Repository.Contract;
using FacturacionAPI.Service.Contract;

namespace FacturacionAPI.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Request<IEnumerable<Cliente>>> GetAllClientesAsync()
        {
            try
            {
                var clientesResponse = await _clienteRepository.GetAllClientesAsync();

                if (clientesResponse != null)
                {
                    return Request<IEnumerable<Cliente>>.Succes(clientesResponse);
                }
                else
                {
                    return Request<IEnumerable<Cliente>>.NoSucces("No existen Registros");
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError("Exception en GetAllClientesAsync: " + ex);
                return Request<IEnumerable<Cliente>>.Error(ex.ToString());
            }
        }

    }
}
