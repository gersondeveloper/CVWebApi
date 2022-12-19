using CVWebApi.DataAccess.Repository;
using CVWebApi.DataAccess.Repository.IRepository;
using CVWebApi.Models.Entities;

namespace CvWebApi.DataAccess.Repository.IRepository;

public class EducationRepository : Repository<Education>, IEducationRepository
{

    private readonly CVDbContext _context;

    public EducationRepository(CVDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Education education)
    {

    }
}