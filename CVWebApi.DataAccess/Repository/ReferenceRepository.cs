using CVWebApi.DataAccess.Repository;
using CVWebApi.DataAccess.Repository.IRepository;
using CVWebApi.Models.Entities;

namespace CvWebApi.DataAccess.Repository.IRepository;

public class ReferenceRepository : Repository<Reference>, IReferenceRepository
{

    private readonly CVDbContext _context;

    public ReferenceRepository(CVDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Reference reference)
    {

    }
}