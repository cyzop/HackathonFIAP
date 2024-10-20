using MedicalConsultation.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MedicalConsultation.WebApp.Services
{
    public class MedicalDoctorApi
    {
        private readonly HttpClient _httpClient;

        public MedicalDoctorApi(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("MedicalDoctorApi");
        }

        [HttpGet]
        public async Task<List<MedicalDoctorDao>> GetMedicalDoctors()
        {
            var medicos = await _httpClient.GetFromJsonAsync<ICollection<MedicalDoctorDao>>($"medicaldoctor/listar");
            if(medicos != null ) 
                return Task<List<MedicalDoctorDao>>.Factory.StartNew(() => medicos.ToList()).Result;
            else
                throw new Exception("Medicos não encontrados!");
        }

        public async Task<MedicalDoctorDao> GetAsync(string email)
        {
            var ret = await _httpClient.GetFromJsonAsync<MedicalDoctorDao>($"medicaldoctor/{email}");
            if (ret!= null)
                return Task<MedicalDoctorDao>.Factory.StartNew(() => ret).Result;
            else
                throw new Exception("Medico não localizado!");
        }

        public async Task<MedicalDoctorDao> PostClienteAsync(MedicalDoctorDao medico)
        {
            string url = $"medicaldoctor/cadastrar/";
            var json = JsonConvert.SerializeObject(medico);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var ret = await _httpClient.PostAsync(url, content);

            if (ret.IsSuccessStatusCode)
            {
                var x = await ret.Content.ReadFromJsonAsync<MedicalDoctorDao>();
                return Task<MedicalDoctorDao>.Factory.StartNew(() => x).Result;
            }
            else
                throw new Exception(ret.StatusCode.ToString());
        }

        public async Task<MedicalDoctorDao> PutClienteAsync(MedicalDoctorDao medico)
        {
            string url = $"medicaldoctor/alterar/";
            var json = JsonConvert.SerializeObject(medico);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var ret = await _httpClient.PutAsync(url, content);

            if (ret.IsSuccessStatusCode)
            {
                var x = await ret.Content.ReadFromJsonAsync<MedicalDoctorDao>();
                return Task<MedicalDoctorDao>.Factory.StartNew(() => x).Result;
            }
            else
                throw new Exception(ret.StatusCode.ToString());
        }
    }
}
