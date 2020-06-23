using System.Collections.Generic;
using System.Collections.ObjectModel;
using xama.Services;
using xamaLibrary;
using Xamarin.Forms;
using Xamarin.ViewModels.Base;

namespace xama.ViewsModels
{
    class FilmsView : BaseViewModel
    {
        private readonly FilmService _filmService = new FilmService();
        string _title = "";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
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
        public FilmsView(Page page)
        {
            Title = "Movie List";
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
