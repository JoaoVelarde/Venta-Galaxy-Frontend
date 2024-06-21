using VentaGalaxy.Shared.Request;
using VentaGalaxy.Shared.Response;

namespace VentaGalaxy.Client.Proxy.Interfaces;

public interface IHomeProxy
{
    Task<PaginationResponse<ProductoHomeDtoResponse>> ListarProductosHomeAsync(BusquedaProductoHomeRequest request);

    Task<BaseResponseGeneric<ProductoHomeDtoResponse>> GetProductoHomeAsync(int id);
}