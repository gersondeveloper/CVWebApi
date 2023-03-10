using CVWebApi.Models.Entities;

namespace CVWebApi.DataAccess.Repository.IRepository
{
    public interface IReferenceRepository : IRepository<Reference> {
        void Update(Reference reference);
    }
}