
using VentaGalaxy.Shared.Request;
using VentaGalaxy.Shared.Response;

namespace VentaGalaxy.Client.Proxy.Interfaces
{
    public interface IUserProxy
    {
        Task<LoginDtoResponse> Login(LoginDtoRequest request);

        Task<HttpResponseMessage> Register(RegistrarUsuarioDto request);

        Task SendTokenToResetPassword(GenerateTokenToResetDtoRequest request);

        Task ResetPassword(ResetPasswordDtoRequest request);
    }
}
