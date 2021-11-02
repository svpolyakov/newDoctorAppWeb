using DoctorAppWeb.Shared.SharedServices;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PatientsWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class DataWCFServiceExtension
{
    public static IServiceCollection AddDataWCFService(this IServiceCollection service)
    {
        service.AddTransient<IDataWCFService, DataWCFService>();
        


        return service;
    }
}




namespace DoctorAppWeb.Shared.SharedServices
{

    


    /// <summary>
    /// 
    /// </summary>
    public class DataWCFService : IDataWCFService
    {
        private readonly ILogger<DataWCFService> _logger;
        private readonly InpatientDoctorClient _client;

        public DataWCFService(ILogger<DataWCFService> logger) {
            _logger = logger;
            _client = new InpatientDoctorClient();
            _logger.LogDebug("Create");
        }

        public Task<List<PatientDto>> GetPersonsAsync(FilterPersonTypeDto filterPersonType, string login)
        {
            _logger.LogDebug("GetPersonsAsync");
            return _client.GetPatientsAsync(new PersonQueryParamsDto {PersonQueryType = FilterPersonTypeDto.AllPatients }, login);
        }

        public Task<List<IndicantDto>> GetIndicantAsync(System.Guid id)
        {
            _logger.LogDebug("GetIndicantAsync");
            return _client.GetIndicantAsync(id);
        }

        public Task<Guid?> AuthorizeAsync(string login, string password)
        {
            _logger.LogDebug("AuthorizeAsync");
            return _client.AuthorizeAsync(login, password);
        }

        public Task<List<ActualDoctorDto>> GetAllActualDoctorsAsync()
        {
            _logger.LogDebug("GetAllActualDoctorsAsync");
            return _client.GetAllActualDoctorsAsync();
        }

        public Task<List<DepartmentDto>> GetAllDepartmentsAsync()
        {
            _logger.LogDebug("GetAllDepartmentsAsync");
            return _client.GetAllDepartmentsAsync();
        }
    }
}
