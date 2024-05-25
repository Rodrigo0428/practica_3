using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A.Integration.dto;


namespace A.Integration
{
    public class ListarUnUsuario
    {
        private readonly ILogger<ListarUnUsuario> _logger;

        private const string API_URL = "https://reqres.in/api/users/";
        private readonly HttpClient httpClient;

        public ListarUnUsuario(ILogger<ListarUnUsuario> logger)
        {
            _logger = logger;
            httpClient = new HttpClient();

        }

        public async Task<Usuario> GetUser(int Id)
        {

            string requestUrl =  $"{API_URL}{Id}";
            Usuario usuario = new Usuario();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();
                    if (apiResponse != null)
                    {
                        usuario = apiResponse.Data ?? new Usuario();
                    }
                }
            }
            catch(Exception ex){
                _logger.LogDebug($"Error al llamar a la API: {ex.Message}");
            }
            return usuario;

        }
        class ApiResponse
        {
            public Usuario Data { get; set; }
            public Support Support { get; set; }
        }
    }
}