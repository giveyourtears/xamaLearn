using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using xamApi.Helpers;
using xamApi.Models;
using xamApi.Services;

namespace xamApi.Controllers
{
  [Authorize]
  [Route("[controller]")]
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

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login([FromBody] AuthenticateModel model)
    {
      var user = _userService.LoginUser(model.Username, model.Password);

      if (user == null)
        return BadRequest(new { message = "Username or password is incorrect" });

      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSecretSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[]
        {
              new Claim(ClaimTypes.Name, user.Id.ToString())
        }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials =
          new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      var tokenString = tokenHandler.WriteToken(token);
      return Ok(new
      {
        user.Id,
        user.Username,
        user.FirstName,
        user.LastName,
        Token = tokenString
      });
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterModel model)
    {
      try
      {
        var user = _mapper.Map<UserModel>(model); 
        _userService.Create(user, model.Password);
        var loginModel = new AuthenticateModel()
        {
          Username = model.Username,
          Password = model.Password
        };
        var loginResult = Login(loginModel);
        if (loginResult != null)
        {
          return Ok();
        }

        return BadRequest("Error");
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