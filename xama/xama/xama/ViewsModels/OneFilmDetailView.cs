using xama.ViewsModels.Base;
using xamaLibrary;

namespace xama.ViewsModels
{
    class OneFilmDetailView : BaseViewModel
    {
        public FilmModel Film { get; private set; }

        public OneFilmDetailView(FilmModel film = null)
        {
            Title = film?.Name;
            Film = film;
        }
    }
}
