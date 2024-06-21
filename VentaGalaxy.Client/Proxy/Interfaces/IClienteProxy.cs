using VentaGalaxy.Shared.Request;
using VentaGalaxy.Shared.Response;

namespace VentaGalaxy.Client.Proxy.Interfaces
{
    public interface IClienteProxy : ICrudRestHelper<ClienteDtoRequest, ClienteDtoResponse>
    {
        Task<PaginationResponse<ClienteDtoResponse>> ListAsync(BusquedaClienteRequest request);
    }
}
