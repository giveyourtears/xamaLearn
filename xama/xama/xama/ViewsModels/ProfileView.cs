using System.Windows.Input;
using xama.Services;
using xama.Views;
using xama.ViewsModels.Base;
using Xamarin.Forms;

namespace xama.ViewsModels
{
  class ProfileView : BaseViewModel
  {
    private readonly Service _api = new Service();
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    private string Password { get; set; }
    public ProfileView()
    {
      Username = (string)Application.Current.Properties["name"];
      FirstName = (string)Application.Current.Properties["first_name"];
      LastName = (string)Application.Current.Properties["last_name"];
    }

    private string _message;

    private string Message
    {
      get => _message;
      set
      {
        if (_message == value || value == null)
          return;
        _message = value;
        OnPropertyChanged();
      }
    }


    public ICommand UpdateProfile
    {
      get
      {
        return new Command(async () =>
        {
          var isSuccess = await _api.Update(FirstName, LastName, Username);
          Message = isSuccess ? "Profile updated" : "Retry again";
          if (isSuccess)
          {
            Application.Current.Properties["name"] = FirstName;
            Application.Current.Properties["first_name"] = FirstName;
            Application.Current.Properties["last_name"] = FirstName;
            DependencyService.Get<IToast>().Show(Message);
            Application.Current.MainPage = new MainProjectPage();
          }
          else
          {
            DependencyService.Get<IToast>().Show(Message);
          }
        });
      }
    }

    public ICommand Logout
    {
      get
      {
        return new Command(() =>
        {
          Application.Current.Properties["id"] = null;
          Application.Current.Properties["name"] = null;
          DependencyService.Get<IToast>().Show("Logout Successfully");
          Application.Current.MainPage = new LoginPage();
        });
      }
    }
  }
}
