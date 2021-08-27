using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppWeb.Shared.DataModel.Application
{
    public class GridPersonCustomization
    {
        public List<List<object>> customGridPerson { get; set; }
    }

    public static class DefaultGridPersonCustomization
    {
        public static List<List<object>> GetDefaults()
        {
            DateTime dtUpdate = DateTime.Now;
            List<List<object>> defaults = new List<List<object>>();
            defaults.Add(new List<object>() { "Surname", "Фамилия", 0, true, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "Firstname", "Имя", 1, true, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "Patronymic", "Отчество", 2, true, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "Age", "Возраст", 3, true, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "ResponsibleDep", "Ответственное отделение", 4, true, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "StayDep", "Отделение пребывания", 5, true, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "Diagnos", "Диагноз", 6, true, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "Doctor", "Врач", 7, true, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "Room", "Палата", 8, true, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "Bed", "Койка", 9, false, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "ServiceCaseNumber", "Номер ИБ", 10, true, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "SDDepTreatmentCase", "Поступил в отделение", 11, true, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "SDInpatientServiceCase", "Поступил в стационар", 12, true, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "PhysicalRestraint", "МФС", 13, false, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "ObservationMode", "Режим", 14, false, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "ObservationType", "Вид наблюдения", 15, false, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "InResuscitation", "Реанимация", 16, true, false, true, true, dtUpdate });
            return defaults;
        }
    }

    public class GroupPersonCustomization
    {
        public List<List<object>> customGroupPerson { get; set; }
    }

    public static class DefaultGroupPersonCustomization
    {
        public static List<List<object>> GetDefaults()
        {
            DateTime dtUpdate = DateTime.Now;
            List<List<object>> defaults = new List<List<object>>();
            defaults.Add(new List<object>() { "MyPatient", "Мои пациенты", true, dtUpdate });
            defaults.Add(new List<object>() { "InEmergencyRoom", "В приемном", false, dtUpdate });
            defaults.Add(new List<object>() { "ToMyDepartments", "Поступившие", false, dtUpdate });
            defaults.Add(new List<object>() { "AllPatients", "Все пациенты", false, dtUpdate });
            return defaults;
        }
    }
}
