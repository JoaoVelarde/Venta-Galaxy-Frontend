using System.Net.Http.Json;
using VentaGalaxy.Client.Proxy.Interfaces;
using VentaGalaxy.Shared.Request;
using VentaGalaxy.Shared.Response;

namespace VentaGalaxy.Client.Proxy.Services;

public class HomeProxy : RestBase, IHomeProxy
{
    public HomeProxy(HttpClient httpClient)
        : base("api/Home", httpClient)
    {
    }

    public async Task<PaginationResponse<ProductoHomeDtoResponse>> ListarProductosHomeAsync(BusquedaProductoHomeRequest request)
    {

        var response = await HttpClient.GetFromJsonAsync<PaginationResponse<ProductoHomeDtoResponse>>($"{BaseUrl}?Nombre={request.Nombre}&CategoriaId={request.CategoriaId}&Pagina={request.Pagina}&Filas={request.Filas}");

        if (response is { Success: false })
            throw new ApplicationException(response.ErrorMessage);

        return response!;
    }

    public async Task<BaseResponseGeneric<ProductoHomeDtoResponse>> GetProductoHomeAsync(int id)
    {
        var response = await HttpClient.GetFromJsonAsync<BaseResponseGeneric<ProductoHomeDtoResponse>>($"{BaseUrl}/{id}");

        if (response is { Success: false })
            throw new ApplicationException(response.ErrorMessage);

        return response!;
    }
}