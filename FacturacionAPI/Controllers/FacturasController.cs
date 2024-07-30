using FacturacionAPI.Domain.Entities;
using FacturacionAPI.Helpers;
using FacturacionAPI.Repository.Contract;
using FacturacionAPI.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly IFacturaService _facturaService;

        public FacturasController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }


        // GET: api/facturas/{id}
        [HttpGet("[action]")]
        public async Task<Request<List<Factura>>> GetFactura(int? idCliente, int? numeroFactura)
        {
              return await _facturaService.GetFacturaByIdAsync(idCliente, numeroFactura);

        }

        // POST: api/facturas
        [HttpPost("[action]")]
        public async Task<Request<bool>> CreateFactura([FromBody] Factura factura)
        {

            return await _facturaService.SaveFacturaAsync(factura);

        }
    }
}
