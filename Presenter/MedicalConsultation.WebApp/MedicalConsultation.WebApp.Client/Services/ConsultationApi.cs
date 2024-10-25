using MedicalConsultation.Shared;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace MedicalConsultation.WebApp.Services
{
    public class ConsultationApi
    {
        private readonly HttpClient _httpClient;

        public  ConsultationApi(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("ConsultationAPI");
        }

        public async Task<ConsultationDao> GetConsulta(int id)
        {
            var consulta = await _httpClient.GetFromJsonAsync<ConsultationDao>($"consultation/{id}");
            return consulta;
        }
        public async Task<ICollection<ConsultationDao>> GetConsultasPaciente(int pacienteId)
        {
            var consultas = await _httpClient.GetFromJsonAsync<ICollection<ConsultationDao>>($"consultation/listarporpaciente/{pacienteId}");
            return consultas;
        }

        public async Task<ICollection<ConsultationDao>> GetConsultasMedico(int medicoId)
        {
            var consultas = await _httpClient.GetFromJsonAsync<ICollection<ConsultationDao>>($"consultation/listarpormedico/{medicoId}");
            return consultas;
        }

        public async Task<ConsultationDao> PostAsync(ConsultationDao consulta)
        {
            var json = JsonConvert.SerializeObject(consulta);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var ret = await _httpClient.PostAsync("consultation/cadastrar", content);

            if (ret.IsSuccessStatusCode)
            {
                var x = await ret.Content.ReadFromJsonAsync<ConsultationDao>();
                return Task<ConsultationDao>.Factory.StartNew(() => x).Result;
            }
            else
                throw new Exception(ret.StatusCode.ToString());
        }

        public async Task<ConsultationDao> PutAsync(ConsultationDao consulta)
        {

            var json = JsonConvert.SerializeObject(consulta);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var ret = await _httpClient.PutAsync("consultation/alterar", content);

            if (ret.IsSuccessStatusCode)
            {
                var x = await ret.Content.ReadFromJsonAsync<ConsultationDao>();
                return Task<ConsultationDao>.Factory.StartNew(() => x).Result;
            }
            else
                throw new Exception(ret.StatusCode.ToString());

        }
        
    }
}
