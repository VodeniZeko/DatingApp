using API.Controllers;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API;

public class BuggyController : BaseApiController
{
  private readonly DataContext _context;
  public BuggyController(DataContext context)
  {
    _context = context;
  }

  [Authorize]
  [HttpGet("auth")]
  public ActionResult<string> GetSecret()
  {
    return "secret text";
  }

  [HttpGet("not-found")]
  public ActionResult<AppUser> GetNotFound()
  {
    var test = _context.Users.Find(-1);

    if (test == null) return NotFound();

    return test;
  }

  [HttpGet("server-error")]
  public ActionResult<string> GetServerError()
  {
    var test = _context.Users.Find(-1);

    var thingToReturn = test.ToString();

    return thingToReturn;
  }

  [HttpGet("bad-request")]
  public ActionResult<string> GetBadRequest()
  {
    return BadRequest("this is a bad request");
  }
}
