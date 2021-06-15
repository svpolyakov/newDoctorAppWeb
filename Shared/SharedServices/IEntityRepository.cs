using System.Threading.Tasks;

namespace DoctorAppWeb.Shared.SharedServices
{
    public interface IEntityRepository<TEntity> where TEntity: BaseEntity
    {    
        public Task<int> Create(TEntity entity);
        public Task<int> Update(TEntity entity);
        public Task<TEntity[]> GetAll();
        public Task<int> Delete(TEntity entity);
    }    
}
