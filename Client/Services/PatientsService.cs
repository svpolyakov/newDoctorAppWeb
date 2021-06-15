using DoctorAppWeb.Shared.DataModel;
using DoctorAppWeb.Shared.DataModel.Application;

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

    }



    public class PatientsService: IPatientsService
    {
        private readonly IIndexedDbFactory _dbFactory;
        public PatientsService(IIndexedDbFactory dbFactory) {
            _dbFactory = dbFactory;
        }

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
                        NameButtonRu = "Поступившие",
                        Selected = false
                    });
                    person.CustomGroupPersons.Add(new CustomGroupPerson()
                    {
                        Id = 3,
                        NameButtonRu = "По отделениям",
                        Selected = false
                    });
                    person.CustomGroupPersons.Add(new CustomGroupPerson()
                    {
                        Id = 4,
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
