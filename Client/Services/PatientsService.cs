using DoctorAppWeb.Shared.DataModel;
using DoctorAppWeb.Shared.DataModel.Application;
using DoctorAppWeb.Shared.DataModel.MedOrganization;
using IndexedDB.Blazor;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppWeb.Client.Services
{


    public interface IPatientsService
    {
        public Task SelectCustomGroupPerson(long id);
        public Task<CustomPerson> GetCustomPerson();
        public Task<CustomGroupPerson> GetCustomGroupPerson();
        public Task<CustomGroupPerson[]> GetCustomGroupPersons();
        public List<Patient> AllPersons { get; set; }
        public long? FilterType { get; set; }
        public string UserName { get; set; }
        public Guid CurrentPatient { get; set; }
        public string CurrentPage { get; set; }
    }



    public class PatientsService: IPatientsService
    {
        public List<Patient> AllPersons { get; set; }
        public long? FilterType { get; set; }
        public string UserName { get; set; }
        public Guid CurrentPatient { get; set; }
        private readonly IIndexedDbFactory _dbFactory;        
        public PatientsService(IIndexedDbFactory dbFactory) {
            _dbFactory = dbFactory;
        }
        public string CurrentPage { get; set; }

        public async Task<CustomPerson> GetCustomPerson()
        {
            using (IndexedApplicationDb db = await this._dbFactory.Create<IndexedApplicationDb>())
            {
                var person = db.CustomPersons.FirstOrDefault();
                if(person != null)
                {
                    return person;
                }
                else
                {
                    person = new CustomPerson()
                    {
                        Id = 1,
                        DateUpdate = DateTime.Now
                    };

                    person.CustomGroupPersons = new List<CustomGroupPerson>();
                    person.CustomGroupPersons.Add(new CustomGroupPerson()
                    {
                        Id = 1,
                        NameButtonRu = "Мои пациенты",
                        Selected = true
                    });
                    person.CustomGroupPersons.Add(new CustomGroupPerson()
                    {
                        Id = 2,
                        NameButtonRu = "В приемном отделении",
                        Selected = false
                    });
                    person.CustomGroupPersons.Add(new CustomGroupPerson()
                    {
                        Id = 3,
                        NameButtonRu = "Поступившие за рабочие сутки",
                        Selected = false
                    });
                    person.CustomGroupPersons.Add(new CustomGroupPerson()
                    {
                        Id = 4,
                        NameButtonRu = "Поступившие на мои отделения",
                        Selected = false
                    });
                    person.CustomGroupPersons.Add(new CustomGroupPerson()
                    {
                        Id = 5,
                        NameButtonRu = "По врачам",
                        Selected = false
                    });
                    person.CustomGroupPersons.Add(new CustomGroupPerson()
                    {
                        Id = 6,
                        NameButtonRu = "По отделениям",
                        Selected = false
                    });
                    person.CustomGroupPersons.Add(new CustomGroupPerson()
                    {
                        Id = 7,
                        NameButtonRu = "Все пациенты",
                        Selected = false
                    });
                    db.CustomPersons.Add(person);
                    await db.SaveChanges();
                    return person;
                }                
            }
        }


        public async Task SelectCustomGroupPerson(long id )
        {
            FilterType = id;
            using (IndexedApplicationDb db = await this._dbFactory.Create<IndexedApplicationDb>())
            {             
                var person = await GetCustomPerson();
                person.DateUpdate = DateTime.Now;                                         
                var selection = person.CustomGroupPersons.Where(p => p.Selected == true).FirstOrDefault();
                if (selection != null)
                {
                    selection.Selected = false;
                }                    
                selection = person.CustomGroupPersons.Where(p => p.Id == id).FirstOrDefault();
                if (selection != null)
                {
                    selection.Selected = true;
                }
                db.CustomPersons.Remove(person);
                db.CustomPersons.Add(person);
                await db.SaveChanges();                                 
            }
        }


        public async Task<CustomGroupPerson> GetCustomGroupPerson()
        {
            using (IndexedApplicationDb db = await this._dbFactory.Create<IndexedApplicationDb>())
            {
                var person = await GetCustomPerson();
                return person.CustomGroupPersons.Where(g => g.Selected).FirstOrDefault();                 
            }
        }

        public async Task<CustomGroupPerson[]> GetCustomGroupPersons()
        {
            using (IndexedApplicationDb db = await this._dbFactory.Create<IndexedApplicationDb>())
            {
                var person = await GetCustomPerson();
                return person.CustomGroupPersons.ToArray();
            }
        }
    }
}
