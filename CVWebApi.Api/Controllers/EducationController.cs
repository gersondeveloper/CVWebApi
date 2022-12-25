using System;
using CVWebApi.DataAccess.Repository.IRepository;
using CVWebApi.Models.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CVWebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EducationController : ControllerBase
	{
        public readonly IUnitOfWork _unitOfWork;
        public readonly IValidator<Education> _validator;


        public EducationController(IUnitOfWork unitOfWork, IValidator<Education> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Education), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(Guid id)
        {
            if (id == Guid.Empty)
                return new BadRequestResult();


            var result = _unitOfWork.Education.GetFirstOrDefault(x => x.Id == id);
            return result != null ? new OkObjectResult(result) : new NotFoundResult();
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<Education>), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetAll()
        {
            var result = _unitOfWork.Education.GetAll();

            if (result != null)
            {
                return new OkObjectResult(result);
            }

            return new NotFoundResult();
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(Education), 201)]
        public async Task<IActionResult> Post([FromBody] Education education)
        {
            ValidationResult result = await _validator.ValidateAsync(education);

            if (result.IsValid)
            {
                _unitOfWork.Education.Add(education);
                _unitOfWork.Save();

                return new CreatedResult("Created", education);
            }
            return new BadRequestResult();
        }
    }
}

