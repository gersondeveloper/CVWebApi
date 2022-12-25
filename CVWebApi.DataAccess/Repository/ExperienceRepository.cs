using CVWebApi.DataAccess.Repository;
using CVWebApi.DataAccess.Repository.IRepository;

namespace CvWebApi.DataAccess.Repository.IRepository;

public class ExperienceRepository : Repository<Experience>, IExperienceRepository
{

    private readonly CVDbContext _context;

    public ExperienceRepository(CVDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Experience experience)
    {
        _context.Update(experience);

    }
}