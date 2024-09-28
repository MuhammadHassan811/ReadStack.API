using ReadStack.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadStack.Application.Models;

namespace ReadStack.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersControllers : ControllerBase
{
    private readonly ReadStackDbContext _context;

    public UsersControllers(ReadStackDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult GetAll(string search = "")
    {
        var user = _context.Users
            .Include(u => u.Loans)
                .ThenInclude(b => b.Book)
            .Where(u => !u.IsDeleted)
            .ToList();

        var model = user.Select(UsersViewModel.FromEntity).ToList();
        
        return Ok(model);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _context.Users
            .Include(l => l.Loans)
                .ThenInclude(b => b.Book)
            .SingleOrDefault(u => u.Id == id);

        if (user is null)
        {
            return NotFound();
        }

        var model = UsersViewModel.FromEntity(user);
        return Ok(model);
    }

    [HttpPost]
    public IActionResult Post(CreateUserInputModel model)
    {
        var user = model.ToEntity();

        if (model == null)
        {
            return NotFound();
        }

        _context.Users.Add(user);
        _context.SaveChangesAsync();
        
        return NoContent();
    }
}