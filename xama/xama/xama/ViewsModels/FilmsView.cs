using System.Collections.ObjectModel;
using System.Windows.Input;
using xama.Services;
using xama.Views;
using xama.ViewsModels.Base;
using xamaLibrary;
using Xamarin.Forms;

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

        public ICommand Logout
        {
          get
          {
            return new Command(async () =>
            {
                Application.Current.Properties["id"] = null;
                Application.Current.Properties["name"] = null;
                DependencyService.Get<IToast>().Show("Logout Successfully");
                Application.Current.MainPage = new LoginPage();
            });
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
