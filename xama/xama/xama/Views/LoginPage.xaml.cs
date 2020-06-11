using System;
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
    }

    async void Signup(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new NavigationPage(new RegistrationPage()));
    }

    void Login(object sender, EventArgs e)
    {
      Console.WriteLine("Login");
    }
  }
}