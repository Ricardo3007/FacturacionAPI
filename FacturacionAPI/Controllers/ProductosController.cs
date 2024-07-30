using FacturacionAPI.Domain.Entities;
using FacturacionAPI.Helpers;
using FacturacionAPI.Repository.Contract;
using FacturacionAPI.Service.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/productos
        [HttpGet("[action]")]
        public async Task<Request<IEnumerable<Producto>>> GetAllProductos()
        {

                return await _productoService.GetAllProductosAsync();

        }

       
    }
}
