using xama.ViewsModels;
using Xamarin.Forms.Xaml;

namespace xama.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage
    {
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = new ProfileView();
        }
    }
}