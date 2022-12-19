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
        Experience obj = new Experience();

        obj = _context.Experiences.FirstOrDefault(x => x.Id == experience.Id);

        //update
        if (obj != null)
        {
            obj.UpdateExperience(experience.Id, experience.CompanyName, experience.Role, experience.StartDate, experience.FinishDate, experience.RoleDescription, experience.TechnologiesList);
            _context.SaveChanges();
        }
    }
}