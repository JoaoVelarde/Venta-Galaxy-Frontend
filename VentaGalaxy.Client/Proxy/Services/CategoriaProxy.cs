using VentaGalaxy.Client.Proxy.Interfaces;
using VentaGalaxy.Shared.Request;
using VentaGalaxy.Shared.Response;

namespace VentaGalaxy.Client.Proxy.Services
{
    public class CategoriaProxy : CrudRestHelperBase<CategoriaDtoRequest, CategoriaDtoResponse>, ICategoriaProxy
    {
        public CategoriaProxy(HttpClient httpClient)
            : base("api/Categorias", httpClient)
        {
        }
    }
}
