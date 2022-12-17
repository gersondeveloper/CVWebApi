using CVWebApi.DataAccess.Repository.IRepository;
using CVWebApi.Models;

namespace CVWebApi.DataAccess.Repository.IRepository;

public interface ISkillRepository : IRepository<Skill> {
    void Update(Skill skill);
}