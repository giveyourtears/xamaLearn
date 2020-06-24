using System.Collections.ObjectModel;
using xama.Services;
using xama.ViewsModels.Base;
using xamaLibrary;

namespace xama.ViewsModels
{
    class FilmsView : BaseViewModel
    {
        private readonly FilmService _filmService = new FilmService();
        //string _title = "";
        //public string Title
        //{
        //    get => _title;
        //    set => SetProperty(ref _title, value);
        //}
        private ObservableCollection<FilmModel> _films;
        public ObservableCollection<FilmModel> Films
        {
            get => _films;
            set
            {
                if (_films == value)
                    return;
                _films = value;
                OnPropertyChanged();
            }
        }
        //public Command LoadFilmsCommand { get; }
        public FilmsView()
        {
            //Title = "Movie List";
            Films = new ObservableCollection<FilmModel>();
            var data = _filmService.GetFilms();
            foreach (var film in data)
            {
                Films.Add(film);
            }

        }
        //public List<FilmModel> GetFilms()
        //{
        //    Films = new List<FilmModel>();
        //    var data = _filmService.GetFilms();
        //    foreach (var item in data)
        //    {
        //        Films.Add(item);
        //    }
        //    return Films;
        //}
    }
}
