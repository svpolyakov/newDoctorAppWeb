using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppWeb.Shared.SharedServices
{
    public interface IEntitySearchableRepository<TEntity> : IEntityRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<TEntity[]> SearchText(string query);
        public Task<TEntity[]> SearchText(string query, int pageNumber, int pageSize);
        public Task<TEntity[]> GetPage(int pageNumber, int pageSize);
    }
}
