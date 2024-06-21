using System.Globalization;
using VentaGalaxy.Client.Proxy.Interfaces;
using VentaGalaxy.Shared.Request;
using VentaGalaxy.Shared.Response;

namespace VentaGalaxy.Client.Proxy.Services
{
    public class ClienteProxy : CrudRestHelperBase<ClienteDtoRequest, ClienteDtoResponse>, IClienteProxy
    {
        public ClienteProxy(HttpClient httpClient)
            : base("api/Cliente", httpClient)
        {
        }

        public async Task<PaginationResponse<ClienteDtoResponse>> ListAsync(BusquedaClienteRequest request)
        {
            var response =
                await ListAsync(
                    $"?Cliente={request.Cliente}&ClienteId={request.ClienteId}&NroDocumento={request.NroDocumento}&pagina={request.Pagina}&filas={request.Filas}");

            if (response is { Success: true })
            {
                return response;
            }

            return await Task.FromResult(new PaginationResponse<ClienteDtoResponse>());
        }
    }
}
