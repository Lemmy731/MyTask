using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class ProgramService
    {
        private readonly HttpClient _httpClient;

        public ProgramService()
        {
            _httpClient = new HttpClient(); 
        }
        public async Task<ProgramDTO> Create(ProgramDTO applicationForm)
        {
            var response = await _httpClient.PostAsJsonAsync("/application-forms", applicationForm);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ProgramDTO>();
        }
        public async Task<ProgramDTO> Read(int id)
        {
            var response = await _httpClient.GetAsync($"/application-forms/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ProgramDTO>();
        }
        public async Task<ProgramDTO> Update(int id, ProgramDTO applicationForm)
        {
            var response = await _httpClient.PutAsJsonAsync($"/application-forms/{id}", applicationForm);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ProgramDTO>();
        }
    }
}
