using System.Net.Http.Json;
using VentaGalaxy.Client.Proxy.Interfaces;
using VentaGalaxy.Shared.Request;
using VentaGalaxy.Shared.Response;

namespace VentaGalaxy.Client.Proxy.Services
{
    public class VentaProxy  : CrudRestHelperBase<VentaDtoRequest, VentaDetalleDtoResponse>, IVentaProxy
    {
        public VentaProxy(HttpClient httpClient)
            : base("api/Venta", httpClient)
        {
        }

        public async Task<PaginationResponse<VentaDetalleDtoResponse>> ListAsync(BusquedaVentaRequest request)
        {
            var response =
                await ListAsync(
                    $"?NroVenta={request.NroVenta}&Cliente={request.Cliente}&Producto={request.Producto}&pagina={request.Pagina}&filas={request.Filas}");

            if (response is { Success: true })
            {
                return response;
            }

            return await Task.FromResult(new PaginationResponse<VentaDetalleDtoResponse>());
        }

        public async Task<string> VentaMasivaAsync(VentaMasivaDtoRequest request)
        {
            var response = await HttpClient.PostAsJsonAsync($"{BaseUrl}/masiva", request);
            var result = await response.Content.ReadFromJsonAsync<BaseResponse>();
            if (result is { Success: false })
            {
                throw new InvalidOperationException(result.ErrorMessage);
            }
            return result?.ErrorMessage ?? throw new InvalidOperationException("Número de venta no disponible");
        }
    }
}
