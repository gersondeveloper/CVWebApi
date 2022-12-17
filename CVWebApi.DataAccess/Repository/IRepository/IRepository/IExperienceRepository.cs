namespace CVWebApi.DataAccess.Repository.IRepository;

public interface IExperienceRepository: IRepository<Experience> {
    void Update(Experience experience);
}