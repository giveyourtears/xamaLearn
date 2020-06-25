using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using xama.Services;
using xama.Views;
using Xamarin.Forms;

namespace xama.ViewsModels
{
  class RegisterView : INotifyPropertyChanged
  {
    Service api = new Service();
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    private string _message;

    private string Message
    {
      set
      {
        if (_message == value || value == null)
          return;
        _message = value;
        OnPropertyChanged();
      }
    }

    public ICommand RegisterAction
    {
      get
      {
        return new Command(async () =>
        {
          var isSuccess = await api.Register(FirstName, LastName, Username, Password);
          Message = isSuccess ? "Registered successfully" : "Retry again";
          if (isSuccess)
          {
              Application.Current.Properties["name"] = FirstName; 
              DependencyService.Get<IToast>().Show("Register Successfully");
              Application.Current.MainPage = new MainProjectPage();
          }
          else
          {
            DependencyService.Get<IToast>().Show("Register Unsuccessfully. Try again!");
          }
        });
      }
    }


    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
      var changed = PropertyChanged;

      changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
  }
}