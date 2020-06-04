using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        UserModel user = _mapper.Map<UserModel>(model);

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
    }
}