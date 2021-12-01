using PatientsWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppWeb.Shared.DataModel.Application
{
    public class InfoWindow
    {
        public string Admitted { get; set; }
        public string Allergic { get; set; }
        public string IsWorking { get; set; }
        public AnamnesisInfoDto LifeAnamnesis { get; set; }
        public AnamnesisInfoDto PathologyАnamnesis { get; set; }
        public AnamnesisInfoDto AnamnesisMKB { get; set; }
        public string Diet { get; set; }
    }
}
