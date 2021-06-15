using DoctorAppWeb.Shared.SharedServices;

using Microsoft.Extensions.Logging;

using PatientsWcf;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DoctorAppWeb.Client.Services
{
    public class HttpDataWCFService: IDataWCFService
    {
        private readonly HttpClient _http;
        private readonly ILogger<HttpDataWCFService> _logger;

        public HttpDataWCFService(ILogger<HttpDataWCFService> logger, HttpClient http)
        {
            _http = http;
            _logger = logger;
            _logger.LogDebug("Create");
        }



        public Task<AuthResultDto> AuthorizeAsync(string login, string password)
        {
            throw new NotImplementedException($"Метод не определён, ищите его в {nameof(AuthService)}");
        }

        public async Task<List<PersonDto>> GetPersonsAsync()
        {
            _logger.LogDebug("GetPersonsAsync");
            return await _http.GetFromJsonAsync<List<PersonDto>>("Persons");
        }

        public async Task<List<IndicantDto>> GetIndicantAsync(Guid id)
        {
            _logger.LogDebug("GetIndicantAsync");
            return await _http.GetFromJsonAsync<List<IndicantDto>>("Indicants");
        }

        public async Task<List<ActualDoctorDto>> GetAllActualDoctorsAsync()
        {
            _logger.LogDebug("GetAllActualDoctorsAsync");
            return await _http.GetFromJsonAsync<List<ActualDoctorDto>>("Doctors");
        }

        public async Task<List<DepartmentDto>> GetAllDepartmentsAsync()
        {
            _logger.LogDebug("GetAllDepartmentsAsync");
            return await _http.GetFromJsonAsync<List<DepartmentDto>>("Departments");
        }
    }
}
