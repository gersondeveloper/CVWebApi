using AutoMapper;
using CVWebApi.DataAccess.Repository.IRepository;
using CVWebApi.ViewModel;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CVWebApi.Controllers;

[Route("api/[controller]")]
[Produces("application/json")]
[ApiController]
public class ExperienceController : Controller
{
    public readonly IUnitOfWork _unitOfWork;
    public readonly IMapper _mapper;
    public readonly IValidator<Experience> _validator;


    public ExperienceController(IUnitOfWork unitOfWork, IMapper mapper, IValidator<Experience> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    [HttpGet()]
    public IActionResult GetById([FromQuery] Guid id)
    {
        var result = _unitOfWork.Experience.Get(id);
        return result != null ? new OkObjectResult(result) : new NotFoundResult();
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

    [HttpPost]
    [ProducesResponseType(403)]
    [ProducesResponseType(typeof(Experience), 201)]
    public IActionResult Post([FromBody] ExperienceViewModel experienceViewModel)
    {
        var experience = _mapper.Map<Experience>(experienceViewModel);

        ValidationResult result = _validator.Validate(experience);
        
        if (result.IsValid)
        {
            _unitOfWork.Experience.Add(experience);
            _unitOfWork.Save();
            
            return new CreatedResult("Created", experience);
        }
        return new BadRequestResult();
    }

}