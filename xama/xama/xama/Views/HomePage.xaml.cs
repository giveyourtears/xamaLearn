using xama.ViewsModels;
using Xamarin.Forms.Xaml;

namespace xama.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage
    {
        private readonly FilmsView _filmsView;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = _filmsView = new FilmsView(this);
        }
    }
}