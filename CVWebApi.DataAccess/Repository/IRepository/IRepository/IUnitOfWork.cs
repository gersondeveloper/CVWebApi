using CVWebApi.DataAccess.Repository.IRepository;

namespace CVWebApi.DataAccess.Repository.IRepository;

public interface IUnitOfWork: IDisposable
{
    IEducationRepository Education { get; }
    IExperienceRepository Experience { get; }
    IPersonalDataRepository PersonalData { get; }
    IReferenceRepository Reference { get; }
    ISkillRepository Skill { get; }
    void Save();
}