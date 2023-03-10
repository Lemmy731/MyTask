using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using Model.DTO;
using Infrastructure.Interface;

namespace ControllerApi.Controllers
{
    public class WorkFlowController
    {
        private readonly HttpClient _httpClient;
        public WorkFlowController(IWorkFlowService workFlowService)
        {
            _httpClient = new HttpClient();
           // _httpClient.BaseAddress = new Uri("https://your-api.com");

        }

        //public async Task<ApplicationForm> Create(ApplicationFormDTO applicationForm)
        //{
        //    var response = await _httpClient.PostAsJsonAsync("/application-forms", applicationForm);
        //    response.EnsureSuccessStatusCode();
        //    return await response.Content.ReadAsAsync<ApplicationForm>();
        //}
        public async Task<ApplicationWorkflowDTO> Read(int id)
        {
            var response = await _httpClient.GetAsync($"/application-forms/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ApplicationWorkflowDTO>();
        }
        public async Task<ApplicationWorkflowDTO> Update(int id, ApplicationFormDTO applicationForm)
        {
            var response = await _httpClient.PutAsJsonAsync($"/application-forms/{id}", applicationForm);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ApplicationWorkflowDTO>();
        }
        //public async Task Delete(int id)
        //{
        //    var response = await _httpClient.DeleteAsync($"/application-forms/{id}");
        //    response.EnsureSuccessStatusCode();
        //}

    }
}
