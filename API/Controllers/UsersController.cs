using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetAllUsers()
    {
        var users = await _context.Users.ToListAsync();

        try
        {
            if (users == null || !users.Any())
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
    public async Task<ActionResult<AppUser>> GetSingleUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

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
