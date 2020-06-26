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
        private FilmModel _selectedItem;
        private Page _page;
        private ObservableCollection<FilmModel> _films;
        private ObservableCollection<FilmModel> Films
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

        //public FilmModel FilmSelected
        //{
        //    get => _selectedItem;
        //    set
        //    {
        //        if (_selectedItem == value || value == null)
        //            return;
        //        _selectedItem = value;
        //        OnPropertyChanged();
        //        _page.Navigation.PushAsync(new FilmViewPage(new OneFilmDetailView(value)));
        //    }
        //}

        public ICommand Logout
        {
            get
            {
                return new Command(() =>
                {
                    Application.Current.Properties["id"] = null;
                    Application.Current.Properties["name"] = null;
                    Application.Current.Properties["token"] = null;
                    Application.Current.Properties["first_name"] = null;
                    Application.Current.Properties["last_name"] = null;
                    DependencyService.Get<IToast>().Show("Logout Successfully");
                    Application.Current.MainPage = new LoginPage();
                });
            }
        }
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
    }
}
