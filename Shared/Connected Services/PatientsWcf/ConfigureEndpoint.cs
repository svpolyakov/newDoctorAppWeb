using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PatientsWcf
{
    public partial class InpatientDoctorClient : System.ServiceModel.ClientBase<PatientsWcf.IInpatientDoctor>, PatientsWcf.IInpatientDoctor
    {
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials)
        {
            serviceEndpoint.Address =
                new System.ServiceModel.EndpointAddress(new System.Uri(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DoctorAppService")["Endpoint"]),
                new System.ServiceModel.DnsEndpointIdentity(""));
        }
    }
}
