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
            //defaults.Add(new List<object>() { "Lastname", "Фамилия", 0, true, false, false, true, dtUpdate });
            //defaults.Add(new List<object>() { "Firstname", "Имя", 1, true, false, false, true, dtUpdate });
            //defaults.Add(new List<object>() { "Patronymic", "Отчество", 2, true, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "FIO", "ФИО", 0, true, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "Age", "Возраст", 1, true, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "ResponsibleDep", "Ответственное отделение", 2, true, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "StayDep", "Отделение пребывания", 3, true, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "Diagnos", "Диагноз", 4, true, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "Doctor", "Врач", 5, true, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "Room", "Палата", 6, true, true, false, true, dtUpdate });
            defaults.Add(new List<object>() { "Bed", "Койка", 7, false, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "ServiceCaseNumber", "Номер ИБ", 8, true, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "SDDepTreatmentCase", "Поступил в отделение", 9, true, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "SDInpatientServiceCase", "Поступил в стационар", 10, true, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "PhysicalRestraint", "МФС", 11, false, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "ObservationMode", "Режим", 12, false, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "ObservationType", "Вид наблюдения", 13, false, false, false, true, dtUpdate });
            defaults.Add(new List<object>() { "InResuscitation", "Реанимация", 14, true, false, true, true, dtUpdate });
            defaults.Add(new List<object>() { "AgeDescription", "Описание возраста", 15, false, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "Birthday", "Дата рождения", 16, false, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "SexEnum", "Пол", 17, false, false, false, false, dtUpdate });
            //defaults.Add(new List<object>() { "IsWorking", "Занятость", 20, false, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "HelpForm", "Форма помощи", 18, false, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "AdmissionInfo", "Поступил", 19, false, false, false, false, dtUpdate });
            //defaults.Add(new List<object>() { "IsDocsExist", "Отсутствие документов", 23, false, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "Benefits", "Льготы", 20, false, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "PatientCondition", "Состояние пациента", 21, false, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "BloodGroup", "Группа крови", 22, false, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "BloodRezus", "Резус", 23, false, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "HIV", "ВИЧ", 24, false, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "Syphilis", "Сифилис", 25, false, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "HepatitisB", "Гепатит B", 26, false, false, false, false, dtUpdate });
            defaults.Add(new List<object>() { "HepatitisC", "Гепатит C", 27, false, false, false, false, dtUpdate });
            //defaults.Add(new List<object>() { "Allergic", "Аллергия", 32, false, false, false, false, dtUpdate });
            //defaults.Add(new List<object>() { "DiagnosAnamnesisID", "Анамнез заболевания", 33, false, false, false, false, dtUpdate });
            //defaults.Add(new List<object>() { "PathologyАnamnesisID", "Анамнез заболевания пациента", 34, false, false, false, false, dtUpdate });
            //defaults.Add(new List<object>() { "LifeAnamnesisID", "Анамнез жизни", 35, false, false, false, false, dtUpdate });
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
