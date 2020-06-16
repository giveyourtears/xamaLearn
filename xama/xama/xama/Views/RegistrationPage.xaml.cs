using xama.ViewsModels;
using Xamarin.Forms.Xaml;

namespace xama.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class RegistrationPage
  {
    public RegistrationPage()
    {
      InitializeComponent();
      BindingContext = new RegisterView();
    }
  }
}