using System;
using xama.ViewsModels;
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

    public async void Signup(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new RegistrationPage());
    }

    void Login(object sender, EventArgs e)
    {
      Console.WriteLine("Login");
    }
  }
}