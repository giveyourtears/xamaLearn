using System.Windows.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using xama.Services;
using xama.Views;
using Xamarin.Forms;

namespace xama.ViewsModels
{
  class RegisterView
  {
    Service api = new Service();
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Message { get; set; }

    public ICommand RegisterAction
    {
      get
      {
        return new Command(async() =>
        {
          var isSuccess = await api.Register(FirstName, LastName, Username, Password);
          Message = isSuccess ? "Registered successfully" : "Retry again";
        });
      }
    }
  }
}
