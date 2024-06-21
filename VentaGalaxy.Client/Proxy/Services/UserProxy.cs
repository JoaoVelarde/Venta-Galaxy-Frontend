using System.Net.Http.Json;
using VentaGalaxy.Client.Proxy.Interfaces;
using VentaGalaxy.Shared.Request;
using VentaGalaxy.Shared.Response;

namespace VentaGalaxy.Client.Proxy.Services
{
    public class UserProxy : IUserProxy
    {
        private readonly HttpClient _httpClient;

        public UserProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginDtoResponse> Login(LoginDtoRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Users/Login", request);
            var loginResponse = await response.Content.ReadFromJsonAsync<LoginDtoResponse>();

            return loginResponse!;
        }

        public async Task<HttpResponseMessage> Register(RegistrarUsuarioDto request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Users/Register", request);

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadFromJsonAsync<BaseResponse>();
                if (resultado != null && resultado.Success == false)
                    throw new InvalidOperationException(resultado.ErrorMessage);
            }
            else
            {
                throw new InvalidOperationException(response.ReasonPhrase);
            }

            return response;
        }

        public async Task SendTokenToResetPassword(GenerateTokenToResetDtoRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Users/SendTokenToResetPassword", request);
            if (!response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadFromJsonAsync<BaseResponse>();
                throw new InvalidOperationException(jsonResponse!.ErrorMessage);
            }
        }

        public async Task ResetPassword(ResetPasswordDtoRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Users/ResetPassword", request);
            if (!response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadFromJsonAsync<BaseResponse>();
                throw new InvalidOperationException(jsonResponse!.ErrorMessage);
            }
        }
    }
}
