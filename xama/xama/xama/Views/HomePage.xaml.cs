using xama.ViewsModels;
using xamaLibrary;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xama.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new FilmsView();
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
          var details = e.Item as FilmModel;
          await Navigation.PushAsync(new FilmDetailPage(details));
        }
    }
}