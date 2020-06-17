using System.Windows.Input;
using xama.Services;
using xama.Views;
using Xamarin.Forms;

namespace xama.ViewsModels
{
  class LoginView
  {
    Service service = new Service();

    public string Username { get; set; }
    public string Password { get; set; }

    public ICommand Login 
    {
      get
      {
        return new Command(async () =>
        {
          var login = await service.Login(Username, Password);
          if (login != null)
          {
            Application.Current.MainPage = new HomePage();
          }
        });
      }
    }
  }
}
