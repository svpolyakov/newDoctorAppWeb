using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppWeb.Shared.Models
{
    public class Patient
    {
        public int ID { get; set; }
        public string PersonID { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }

        /// <summary>
        /// Ответственное отделение
        /// </summary>
        public string ResponsibleDep { get; set; }

        /// <summary>
        /// Отделение пребывания
        /// </summary>
        public string StayDep { get; set; }
        public string Diagnos { get; set; }
        public string Doctor { get; set; }

        /// <summary>
        /// Палата(Помещение)
        /// </summary>
        public string Room { get; set; }


        public string Bed { get; set; }

        /// <summary>
        /// Номер ИБ
        /// </summary>
        public string ServiceCaseNumber { get; set; }

        /// <summary>
        /// Поступил в отделение
        /// </summary>
        public DateTime? SDDepTreatmentCase { get; set; }


        /// <summary>
        /// Поступил в стационар
        /// </summary>
        public DateTime? SDInpatientServiceCase { get; set; }


        /// <summary>
        /// Реанимация
        /// </summary>
        public bool? InResuscitation { get; set; }


        /// <summary>
        /// Меры физического стеснения(МФС)
        /// </summary>
        public string PhysicalRestraint { get; set; }

        /// <summary>
        /// Режим
        /// </summary>
        public string ObservationMode { get; set; }

        /// <summary>
        /// Вид наблюдения
        /// </summary>
        public string ObservationType { get; set; }

        /// <summary>
        /// Было изменено
        /// </summary>
        public bool? IsChanged { get; set; }
   
      
        public string VersionID { get; set; }

    }
}
