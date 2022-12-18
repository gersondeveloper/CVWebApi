using CVWebApi.Models.Entities;

namespace CVWebApi.DataAccess.Repository.IRepository
{
    public interface IEducationRepository : IRepository<Education> {
        void Update(Education education);
    }
}