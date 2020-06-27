using System;
using xama.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xama.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class LoginPage
  {
    public LoginPage()
    {
      InitializeComponent();
      BindingContext = new LoginView();
    }

    private async void Signup(object sender, EventArgs e)
    {
      Application.Current.MainPage = new RegistrationPage();
    }
  }
}