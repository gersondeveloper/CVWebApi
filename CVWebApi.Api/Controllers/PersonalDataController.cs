using CVWebApi.DataAccess.Repository.IRepository;
using CVWebApi.Models.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CVWebApi.Controllers;

[Route("api/[controller]")]
[Produces("application/json")]
[ApiController]
public class PersonalDataController : ControllerBase
{
    public readonly IUnitOfWork _unitOfWork;
    public readonly IValidator<PersonalData> _validator;


    public PersonalDataController(IUnitOfWork unitOfWork, IValidator<PersonalData> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Experience), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(Guid id)
    {
        if (id == Guid.Empty)
            return new BadRequestResult();


        var result = await _unitOfWork.Experience.GetFirstOrDefault(x => x.Id == id);
        return result != null ? new OkObjectResult(result) : new NotFoundResult();
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(PersonalData), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _unitOfWork.PersonalData.GetAll();

        if(result != null)
        {
            return new OkObjectResult(result);
        }

        return new NotFoundResult();
    }


    [HttpPost]
    [ProducesResponseType(400)]
    [ProducesResponseType(typeof(PersonalData), 201)]
    public async Task<IActionResult> Post([FromBody] PersonalData personalData)
    {
        ValidationResult result = await _validator.ValidateAsync(personalData);

        if (result.IsValid)
        {
            await _unitOfWork.PersonalData.Add(personalData);
            _unitOfWork.Save();

            return new CreatedResult("Created", personalData);
        }
        return new BadRequestResult();
    }
}