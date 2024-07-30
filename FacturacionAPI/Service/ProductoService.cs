using FacturacionAPI.Domain.Entities;
using FacturacionAPI.Helpers;
using FacturacionAPI.Repository.Contract;
using FacturacionAPI.Service.Contract;

namespace FacturacionAPI.Service
{
    public class ProductoService : IProductoService
    {

        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<Request<IEnumerable<Producto>>> GetAllProductosAsync()
        {
            try
            {
                var productosResponse = await _productoRepository.GetAllProductosAsync();

                if (productosResponse != null)
                {
                    return Request<IEnumerable<Producto>>.Succes(productosResponse);
                }
                else
                {
                    return Request<IEnumerable<Producto>>.NoSucces("No existen Registros");
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError("Exception en GetAllClientesAsync: " + ex);
                return Request<IEnumerable<Producto>>.Error(ex.ToString());
            }
        }

    }
}
