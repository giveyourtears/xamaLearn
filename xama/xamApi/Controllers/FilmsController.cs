using System;
using Microsoft.AspNetCore.Mvc;
using xamaLibrary;
using xamApi.Services;

namespace xamApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FilmsController : ControllerBase
  {
    private IFilmService _filmService;

    public FilmsController(IFilmService filmService)
    {
      _filmService = filmService;
    }

    public IActionResult AddFilm([FromBody] FilmModel film)
    {
      var filmResult = _filmService.AddFilm(film);
      if (filmResult == null)
        return BadRequest(new {message = "Error when add film"});
      return Ok(new
      {
        filmResult.Id,
        filmResult.Name,
        filmResult.Description,
        filmResult.Duration,
        filmResult.Genre,
        filmResult.DatePremier,
        filmResult.Starring
      });
    }

    [HttpGet("{id}")]
    public IActionResult GetFilmById(int id)
    {
      var film = _filmService.GetFilmById(id);
      return Ok(film);
    }

    [HttpGet]
    public IActionResult GetAllFilms()
    {
      var films = _filmService.GetAllFilms();
      return Ok(films);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      try
      {
        _filmService.Delete(id);
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest("Error when: " + ex.Message);
      }
    }

    [HttpPut("{id}")]
    public void UpdateFilm([FromBody] FilmModel film)
    {
      _filmService.UpdateFilm(film);
    }
  }
}
