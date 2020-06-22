using System.Collections.Generic;
using xama.Services;
using xamaLibrary;

namespace xama.ViewsModels
{
    class FilmsView
    {
        private FilmService _filmService = new FilmService();

        public IList<FilmModel> GetFilms()
        {
            IList<FilmModel> films = _filmService.GetFilms();
            if (films == null)
            {
                return null;
            }
            return films;
        }
    }
}
