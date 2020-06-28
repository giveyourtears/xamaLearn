using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using xamaLibrary;

namespace xama.ViewsModels
{
  public class FilmDetailView
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string Starring { get; set; }
    public int Duration { get; set; }
    public string Genre { get; set; }
    public int Id { get; set; }

    public FilmDetailView()
    {

    }
    public FilmDetailView(FilmModel model)
    {
      Id = model.Id;
      Name = model.Name;
      Description = model.Description;
      Starring = model.Starring;
      Duration = model.Duration;
      Genre = model.Genre;
    }

  }
}
