using ReadStack.API.Persistence;
using ReadStack.Application.Models;
using ReadStack.Application.Services.Loans;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ReadStack.API.Controllers;

[ApiController]
[Route("api/loans")]
public class LoansControllers : ControllerBase
{
    private readonly ILoansServices _services;

    public LoansControllers(ILoansServices services)
    {
        _services = services;
    }

    [HttpGet]
    public IActionResult GetAll(string search = "")
    {
        var results = _services.GetAll(search);
        
        return Ok(results);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _services.GetById(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateLoanInputModel model)
    {
        var result = _services.Post(model);

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateLoanInputModel model)
    {
        var result = _services.Put(id, model);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = _services.Delete(id);

        return NoContent();
    }

    [HttpPut("{idUser}/return-book")]
    public async Task<IActionResult> LoanReturned(int idUser, int idBook)
    {
        var result = _services.LoanReturned(idUser, idBook);
        
        return NoContent();
    }
}