using System;
using System.Collections.Generic;
using System.Linq;
using xamaLibrary;
using xamApi.Helpers;

namespace xamApi.Services
{
  public interface IFilmService
  {
    FilmModel AddFilm(FilmModel film);
    FilmModel GetFilmById(int id);
    IEnumerable<FilmModel> GetAllFilms();
    void Delete(int id);
    void UpdateFilm(FilmModel film);
  }
  public class FilmService : IFilmService
  {
    private readonly DataContext _context;

    public FilmService(DataContext context)
    {
      _context = context;
    }

    public FilmModel AddFilm(FilmModel film)
    {
      try
      {
        _context.Films.Add(film);
        _context.SaveChanges();
        return film;
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error when add film: " + ex);
        return null;
      }
    }

    public IEnumerable<FilmModel> GetAllFilms()
    {
      return _context.Films;
    }

    public void Delete(int id)
    {
      var film = _context.Films.Find(id);
      if (film == null) return;
      _context.Films.Remove(film);
      _context.SaveChanges();
    }

    public FilmModel GetFilmById(int id)
    {
      return _context.Films.Find(id);
    }

    public void UpdateFilm(FilmModel filmModel)
    {
      var oldFilm = _context.Films.FirstOrDefault(t => t.Id == filmModel.Id);
      if (oldFilm != null)
      {
        oldFilm.Name = filmModel.Name;
        oldFilm.Description = filmModel.Description;
        oldFilm.DatePremier = filmModel.DatePremier;
        oldFilm.Duration = filmModel.Duration;
        oldFilm.Genre = filmModel.Genre;
        oldFilm.Starring = filmModel.Starring;
      }

      _context.SaveChanges();
    }
  }
}
