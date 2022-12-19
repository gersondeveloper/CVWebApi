using CVWebApi.DataAccess.Repository;
using CVWebApi.DataAccess.Repository.IRepository;
using CVWebApi.Models.Entities;

namespace CvWebApi.DataAccess.Repository.IRepository;

public class PersonalDataRepository : Repository<PersonalData>, IPersonalDataRepository
{

    private readonly CVDbContext _context;

    public PersonalDataRepository(CVDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(PersonalData personalData)
    {

    }
}