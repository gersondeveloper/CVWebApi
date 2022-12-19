using CVWebApi.DataAccess.Repository;
using CVWebApi.DataAccess.Repository.IRepository;
using CVWebApi.Models.Entities;

namespace CvWebApi.DataAccess.Repository.IRepository;

public class SkillRepository : Repository<Skill>, ISkillRepository
{

    private readonly CVDbContext _context;

    public SkillRepository(CVDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Skill skill)
    {

    }
}