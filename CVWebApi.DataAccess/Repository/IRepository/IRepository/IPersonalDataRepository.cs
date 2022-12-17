using CVWebApi.Models;

namespace CVWebApi.DataAccess.Repository.IRepository;

public interface IPersonalDataRepository: IRepository<PersonalData> {
    void Update(PersonalData personalData);
}