using System.Collections.Generic;
using xama.Services;
using xamaLibrary;
using Xamarin.Forms.Xaml;

namespace xama.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage
    {
         IList<FilmModel> Films { get; set; }
        public HomePage()
        {
            Films = new List<FilmModel>();
            FilmService service = new FilmService();
            InitializeComponent();
            var data = service.GetFilms();
            foreach(var item in data)
            {
                Films.Add(item);
            }
            BindingContext = this;
        }
    }
}