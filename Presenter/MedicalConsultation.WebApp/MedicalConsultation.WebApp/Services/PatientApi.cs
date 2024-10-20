using MedicalConsultation.Shared;
using Newtonsoft.Json;
using System.Text;

namespace MedicalConsultation.WebApp.Services
{
    public class PatientApi
    {
        private readonly HttpClient _httpClient;

        public PatientApi(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("PatientAPI");
        }

        public async Task<PatientDao> GetClienteAsync(string email)
        {
            var ret = await _httpClient.GetFromJsonAsync<PatientDao>($"patient/{email}");
            if (ret != null)
                return Task<PatientDao>.Factory.StartNew(() => ret).Result;
            else
                throw new Exception("Paciente não localizado!");
        }

        public async Task<PatientDao> PostClienteAsync(PatientDao cliente)
        {
            string url = $"patient/cadastrar/";
            var json = JsonConvert.SerializeObject(cliente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var ret = await _httpClient.PostAsync(url, content);

            if (ret.IsSuccessStatusCode)
            {
                var x = await ret.Content.ReadFromJsonAsync<PatientDao>();
                return Task<PatientDao>.Factory.StartNew(() => x).Result;
            }
            else
                throw new Exception(ret.StatusCode.ToString());
        }

        public async Task<PatientDao> PutClienteAsync(PatientDao cliente)
        {
            string url = $"patient/alterar/";
            var json = JsonConvert.SerializeObject(cliente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var ret = await _httpClient.PutAsync(url, content);

            if (ret.IsSuccessStatusCode)
            {
                var x = await ret.Content.ReadFromJsonAsync<PatientDao>();
                return Task<PatientDao>.Factory.StartNew(() => x).Result;
            }
            else
                throw new Exception(ret.StatusCode.ToString());
        }
    }
}
