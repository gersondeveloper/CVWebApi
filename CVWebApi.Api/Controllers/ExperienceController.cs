using AutoMapper;
using CVWebApi.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CVWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExperienceController : Controller
{
    public readonly IUnitOfWork _unitOfWork;
    public readonly IMapper _mapper;


    public ExperienceController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Get([FromBody] Experience experience)
    {
        Experience obj = new Experience();

        //create
        if (experience.Id == null)
        {
            obj.AddExperience(experience.CompanyName, experience.Role, experience.StartDate, experience.RoleDescription, experience.TechnologiesList);
            _unitOfWork.Experience.Add(obj);
            _unitOfWork.Save();
        }

        return null;
        //update
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(List<Experience>), 200)]
    [ProducesResponseType(404)]
    public IActionResult GetAll()
    {
        var result = _unitOfWork.Experience.GetAll();

        if(result != null)
        {
            /*var mapped = _mapper.Map<Experience, ExperienceViewModel>(result);*/
            return new OkObjectResult(result);
        }

        return new NotFoundResult();
    }
}