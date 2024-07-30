using FacturacionAPI.Domain.Entities;
using FacturacionAPI.Helpers;
using FacturacionAPI.Repository.Contract;
using FacturacionAPI.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/clientes
        [HttpGet("[action]")]
        public async Task<Request<IEnumerable<Cliente>>> GetAllClientes()
        {

            return await _clienteService.GetAllClientesAsync();

        }

    }
}
