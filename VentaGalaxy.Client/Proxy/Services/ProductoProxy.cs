using VentaGalaxy.Client.Proxy.Interfaces;
using VentaGalaxy.Shared.Request;
using VentaGalaxy.Shared.Response;

namespace VentaGalaxy.Client.Proxy.Services
{
    public class ProductoProxy : CrudRestHelperBase<ProductoDtoRequest, ProductoDtoResponse>, IProductoProxy
    {
        public ProductoProxy(HttpClient httpClient)
            : base("api/Producto", httpClient)
        {
        }

        public async Task<PaginationResponse<ProductoDtoResponse>> ListAsync(BusquedaProductoRequest request)
        {
            var response =
                await ListAsync(
                    $"?Producto={request.Producto}&CategoriaId={request.CategoriaId}&pagina={request.Pagina}&filas={request.Filas}");

            if (response is { Success: true })
            {
                return response;
            }

            return await Task.FromResult(new PaginationResponse<ProductoDtoResponse>());
        }
    }
}
