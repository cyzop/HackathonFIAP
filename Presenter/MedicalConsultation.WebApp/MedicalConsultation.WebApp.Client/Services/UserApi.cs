using MedicalConsultation.Shared;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace MedicalConsultation.WebApp.Services
{
    public class UserApi
    {
        private readonly HttpClient _httpClient;

        public UserApi(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("UserAPI");
        }

        public async Task<UserDao> GetClienteAsync(string email)
        {
            var ret = await _httpClient.GetFromJsonAsync<UserDao>($"user/{email}");
            if (ret != null)
                return Task<UserDao>.Factory.StartNew(() => ret).Result;
            else
                throw new Exception("Paciente não localizado!");
        }

        public async Task<UserDao> PostClienteAsync(UserDao cliente)
        {
            string url = $"user/cadastrar/";
            var json = JsonConvert.SerializeObject(cliente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var ret = await _httpClient.PostAsync(url, content);

            if (ret.IsSuccessStatusCode)
            {
                var x = await ret.Content.ReadFromJsonAsync<UserDao>();
                return Task<UserDao>.Factory.StartNew(() => x).Result;
            }
            else
                throw new Exception(ret.StatusCode.ToString());
        }

        public async Task<UserDao> PutClienteAsync(UserDao cliente)
        {
            string url = $"user/alterar/";
            var json = JsonConvert.SerializeObject(cliente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var ret = await _httpClient.PutAsync(url, content);

            if (ret.IsSuccessStatusCode)
            {
                var x = await ret.Content.ReadFromJsonAsync<UserDao>();
                return Task<UserDao>.Factory.StartNew(() => x).Result;
            }
            else
                throw new Exception(ret.StatusCode.ToString());
        }
    }
}
