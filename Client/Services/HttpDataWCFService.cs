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



        public Task<Guid?> AuthorizeAsync(string login, string password)
        {
            throw new NotImplementedException($"Метод не определён, ищите его в {nameof(AuthService)}");
        }

        public async Task<PatientDto[]> GetPersonsAsync(FilterPersonTypeDto filterPersonType, string login)
        {
            _logger.LogDebug("GetPersonsAsync");
            return await _http.GetFromJsonAsync<PatientDto[]>("Persons");
        }

        public async Task<IndicantDto[]> GetIndicantAsync(Guid id)
        {
            _logger.LogDebug("GetIndicantAsync");
            return await _http.GetFromJsonAsync<IndicantDto[]>("Indicants");
        }

        public async Task<ActualDoctorDto[]> GetAllActualDoctorsAsync()
        {
            _logger.LogDebug("GetAllActualDoctorsAsync");
            return await _http.GetFromJsonAsync<ActualDoctorDto[]>("Doctors");
        }

        public async Task<DepartmentDto[]> GetAllDepartmentsAsync()
        {
            _logger.LogDebug("GetAllDepartmentsAsync");
            return await _http.GetFromJsonAsync<DepartmentDto[]>("Departments");
        }
    }
}
