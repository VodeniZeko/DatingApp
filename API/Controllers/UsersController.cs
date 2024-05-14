using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
        var users = _context.Users.ToList();

        try
        {
        if(users == null || !users.Any())
        {
            throw new Exception("No users found.");
        }

        return users;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return Ok(Enumerable.Empty<AppUser>());
        }
    }

    [HttpGet("{id}")]
    public ActionResult<AppUser> GetSingleUser(int id)
    {
        var user = _context.Users.Find(id);

        try
        {
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return Ok(Enumerable.Empty<AppUser>());

        }
    }
}
