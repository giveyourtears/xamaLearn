using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using xamApi.Helpers;
using xamApi.Models;
using xamApi.Services;

namespace xamApi.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private IUserService _userService;
    private IMapper _mapper;
    private readonly SecretSettings _appSecretSettings;

    public UsersController(IUserService userService, IMapper mapper, IOptions<SecretSettings> secretSettings)
    {
      _userService = userService;
      _mapper = mapper;
      _appSecretSettings = secretSettings.Value;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterModel model)
    {
      var user = _mapper.Map<UserModel>(model);

      try
      {
        _userService.Create(user, model.Password);
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest("Error in " + ex.Message);
      }
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var user = _userService.GetById(id);
      var model = _mapper.Map<User>(user);
      return Ok(model);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      try
      {
        _userService.Delete(id);
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest("Error in " + ex.Message);
      }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateModel model)
    {
      var user = _mapper.Map<UserModel>(model);
      user.Id = id;

      try
      {
        _userService.UpdateUser(user, model.Password);
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(new { message = ex.Message });
      }
    }
  }
}