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

    public string Message
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

    public ICommand RegisterAction
    {
      get
      {
        return new Command(async () =>
        {
          var isSuccess = await api.Register(FirstName, LastName, Username, Password);
          Message = isSuccess ? "Registered successfully" : "Retry again";
          if (isSuccess != null)
          {
            Application.Current.MainPage = new LoginPage();
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