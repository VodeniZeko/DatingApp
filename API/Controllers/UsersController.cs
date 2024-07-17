
using API.Dto;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UsersController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetAllUsers()
    {
        var users = await _userRepository.GetMembersAsync();

        return Ok(users);

    }

    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetSingleUser(string username)
    {
        return await _userRepository.GetMemberByUsernameAsync(username);
    }
}
