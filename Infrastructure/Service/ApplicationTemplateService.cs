using Infrastructure.Interface;
using Microsoft.Extensions.Logging;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class ApplicationTemplateService: IApplicationTemplateService
    {
        private readonly HttpClient _httpClient;

        public ApplicationTemplateService()
        {
            _httpClient = new HttpClient(); 
        }
        public async Task<ApplicationFormDTO> Read(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/application-forms/{id}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<ApplicationFormDTO>();
            }
            catch (Exception ex)            
            {
                var loggerFactory = LoggerFactory.Create(builder =>
                {
                    builder.AddConsole();
                });

                var logger = loggerFactory.CreateLogger<ApplicationTemplateService>();
                logger.LogError(ex, "Error reading application form with id {id}", id);
                r
            }
           
        }
        public async Task<ApplicationFormDTO> Update(int id, ApplicationFormDTO applicationForm)
        {
            var response = await _httpClient.PutAsJsonAsync($"/application-forms/{id}", applicationForm);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ApplicationFormDTO>();
        }
    }
}
