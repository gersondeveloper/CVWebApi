using CVWebApi.DataAccess.Repository.IRepository;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CVWebApi.Controllers;

[Route("api/[controller]")]
[Produces("application/json")]
[ApiController]
public class ExperienceController : Controller
{
    public readonly IUnitOfWork _unitOfWork;
    public readonly IValidator<Experience> _validator;


    public ExperienceController(IUnitOfWork unitOfWork, IValidator<Experience> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    [HttpGet()]
    public IActionResult GetById([FromQuery] Guid id)
    {
        if (id == Guid.Empty)
            return new BadRequestResult();


        var result = _unitOfWork.Experience.GetFirstOrDefault(x => x.Id == id);
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
            return new OkObjectResult(result);
        }

        return new NotFoundResult();
    }

    [HttpPost]
    [ProducesResponseType(403)]
    [ProducesResponseType(typeof(Experience), 201)]
    public IActionResult Post([FromBody] Experience experience)
    {       
        if (ModelState.IsValid)
        {
            _unitOfWork.Experience.Add(experience);
            _unitOfWork.Save();
            
            return new CreatedResult("Created", experience);
        }
        return new BadRequestResult();
    }

}