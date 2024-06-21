using VentaGalaxy.Shared.Request;
using VentaGalaxy.Shared.Response;

namespace VentaGalaxy.Client.Proxy.Interfaces
{
    public interface IVentaProxy : ICrudRestHelper<VentaDtoRequest, VentaDetalleDtoResponse>
    {
        Task<PaginationResponse<VentaDetalleDtoResponse>> ListAsync(BusquedaVentaRequest request);
        Task<string> VentaMasivaAsync(VentaMasivaDtoRequest request);
    }
}
