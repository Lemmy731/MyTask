using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ControllerApi.Controllers
{
    public class ApplicationWorkflowController
    {
        private readonly HttpClient _httpClient;

        public ApplicationWorkflowController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://your-api.com");
        }
        public async Task<ApplicationWorkflow> Create(ApplicationWorkflow applicationWorkflow)
        {
            var response = await _httpClient.PostAsJsonAsync("/application-workflows", applicationWorkflow);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ApplicationWorkflow>();
        }
    }
}
