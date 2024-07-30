using FacturacionAPI.Domain.Entities;
using FacturacionAPI.Helpers;
using FacturacionAPI.Repository;
using FacturacionAPI.Repository.Contract;
using FacturacionAPI.Service.Contract;

namespace FacturacionAPI.Service
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _facturaRepository;

        public FacturaService(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public async Task<Request<bool>> SaveFacturaAsync(Factura factura)
        {
            try
            {
                if (factura == null)
                {
                    return Request<bool>.NoSucces("Datos null");
                }

                var result = await _facturaRepository.SaveFacturaAsync(factura);

                if (result)
                {
                    return Request<bool>.Succes(true);
                }
                else
                {
                    return Request<bool>.NoSucces("Error");
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError("Exception en GetAllClientesAsync: " + ex);
                return Request<bool>.Error(ex.ToString());
            }
        }

        public async Task<Request<List<Factura>>> GetFacturaByIdAsync(int? idCliente, int? numeroFactura)
        {
            try
            {
                var clientesResponse = await _facturaRepository.GetFacturaByIdAsync(idCliente, numeroFactura);

                if (clientesResponse != null)
                {
                    return Request<List<Factura>>.Succes(clientesResponse);
                }
                else
                {
                    return Request<List<Factura>>.NoSucces("No existen Registros");
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError("Exception en GetAllClientesAsync: " + ex);
                return Request<List<Factura>>.Error(ex.ToString());
            }
        }

    }
}
