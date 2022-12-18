using CVWebApi.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CVWebApi.Controllers;

public class ExperienceController : Controller
{
    public readonly IUnitOfWork _unitOfWork;


    public ExperienceController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult Upsert([FromBody] Experience experience)
    {
        //create
        if (experience == null)
        {
            
        }

        //update
    }
}