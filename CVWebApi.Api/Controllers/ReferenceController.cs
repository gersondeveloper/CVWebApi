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
    public class ReferenceController : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IValidator<Reference> _validator;


        public ReferenceController(IUnitOfWork unitOfWork, IValidator<Reference> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == Guid.Empty)
                return new BadRequestResult();


            var result = await _unitOfWork.Reference.GetFirstOrDefault(x => x.Id == id);
            return result != null ? new OkObjectResult(result) : new NotFoundResult();
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<Reference>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.Reference.GetAll();

            return result != null ? new OkObjectResult(result) : new NotFoundResult();
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(Reference), 201)]
        public async Task<IActionResult> Post([FromBody] Reference reference)
        {
            ValidationResult result = await _validator.ValidateAsync(reference);

            if (result.IsValid)
            {
                await _unitOfWork.Reference.Add(reference);
                _unitOfWork.Save();

                return new CreatedResult("Created", reference);
            }
            return new BadRequestResult();
        }
    }
}

