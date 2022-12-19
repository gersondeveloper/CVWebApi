using CvWebApi.DataAccess.Repository.IRepository;

namespace CVWebApi.DataAccess.Repository.IRepository;

public class UnitOfWork : IUnitOfWork
{
    private CVDbContext _dbContext;

    public UnitOfWork(CVDbContext dbContext)
    {
        _dbContext = dbContext;
        Experience = new ExperienceRepository(_dbContext);
        Education = new EducationRepository(_dbContext);
        PersonalData = new PersonalDataRepository(_dbContext);
        Reference = new ReferenceRepository(_dbContext);
        Skill = new SkillRepository(_dbContext);
    }

    public IEducationRepository Education { get; private set;}
    public IExperienceRepository Experience { get; private set;}
    public IPersonalDataRepository PersonalData {get; private set; }
    public IReferenceRepository Reference { get; private set;}
    public ISkillRepository Skill { get; private set;}

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}