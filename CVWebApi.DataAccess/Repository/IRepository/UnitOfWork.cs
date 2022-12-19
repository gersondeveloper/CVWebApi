namespace CVWebApi.DataAccess.Repository.IRepository;

public class UnitOfWork : IUnitOfWork
{
    private readonly CVDbContext _dbContext;

    public UnitOfWork(CVDbContext dbContext)
    {
        _dbContext = dbContext;
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