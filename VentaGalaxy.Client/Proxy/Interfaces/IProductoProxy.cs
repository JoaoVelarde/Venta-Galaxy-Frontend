using VentaGalaxy.Shared.Request;
using VentaGalaxy.Shared.Response;

namespace VentaGalaxy.Client.Proxy.Interfaces
{
    public interface IProductoProxy : ICrudRestHelper<ProductoDtoRequest, ProductoDtoResponse>
    {
        Task<PaginationResponse<ProductoDtoResponse>> ListAsync(BusquedaProductoRequest request);
    }
}
